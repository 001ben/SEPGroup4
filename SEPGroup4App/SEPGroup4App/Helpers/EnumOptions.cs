using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Dynamic;
using System.Linq;
using System.Linq.Expressions;
using System.Reflection;
using System.Web;
using System.Web.Mvc;
using System.Web.Mvc.Html;

namespace SEPGroup4App.Helpers
{
    /// <summary>
    /// Holds the name and value of an Enum type
    /// </summary>
    public class EnumOption
    {
        public string Name { get; set; }
        public int Value { get; set; }
    }

    /// <summary>
    /// Constructs a list of name/value pairs for a specified enum type (only works for enums with 'int' values currently)
    /// </summary>
    /// <typeparam name="TEnum">The type of enum to get a list of names/values for</typeparam>
    public class EnumOptionList<TEnum> : List<EnumOption>
    {
        /// <summary>
        /// Instantiate the EnumOptionList object with names/values for all options in the enum
        /// </summary>
        /// <param name="except">A collection of enum values to be excluded from resulting list</param>
        public EnumOptionList(ICollection<TEnum> except = null, Type type = null)
        {
            if(type != null && type.IsEnum)
            {   }
            else if(typeof(TEnum).IsEnum)
            {
                type = typeof(TEnum);
            }
            else if (typeof(TEnum).Name == typeof(Nullable<>).Name && Nullable.GetUnderlyingType(typeof(TEnum)).IsEnum)
            {
                type = Nullable.GetUnderlyingType(typeof(TEnum));
            }
            else 
            {
                throw new ShowMessageException("Cannot call EnumRadioButtonsFor for a non enum property");
            }

            // Get names/values for all options in an Enum
            var names = Enum.GetNames(type);
            var values = Enum.GetValues(type);

            // Get an enumerator so values array may be iterated through
            var enumerator = values.GetEnumerator();

            // Iterate through names array increasing values enumerator in each iteration
            foreach (var name in names)
            {
                enumerator.MoveNext();

                // Add enum options to this list if no except parameter was passed,
                // or if the current name doesn't match any of the names specified
                // in the 'except' collection
                if (except == null || !except.Any(e => e.ToString() == name))
                {
                    this.Add(new EnumOption
                    {
                        Name = name,
                        Value = (int)enumerator.Current // Case the enumerator value to int type
                    });
                }
            }
        }
    }

    public static class EnumOptionExtension
    {
        public static MvcHtmlString EnumRadioButtonsFor<TModel, TProperty>(this HtmlHelper<TModel> htmlHelper, Expression<Func<TModel, TProperty>> expression)
        {
            return EnumOptionsFor(htmlHelper, expression, InputType.RadioInline);
        }

        public static MvcHtmlString EnumCheckboxesFor<TModel, TProperty>(this HtmlHelper<TModel> htmlHelper, Expression<Func<TModel, TProperty>> expression)
        {
            return EnumOptionsFor(htmlHelper, expression, InputType.CheckboxInline);
        }

        private enum InputType
        {
            RadioInline,
            CheckboxInline
        }

        private static string getInputClass(InputType inputType)
        {
            switch(inputType)
            {
                case InputType.RadioInline:
                    return "radio-inline";
                case InputType.CheckboxInline:
                    return "checkbox-inline";
                default:
                    return "";
            }
        }

        private static string GetInputFor<TModel, TProperty>(HtmlHelper<TModel> htmlHelper, Expression<Func<TModel, TProperty>> expression, string propertyName, InputType inputType, EnumOption enumValue, Type nullableType = null)
        {
            string inputString = "<input type=\"{0}\" id=\"{1}\" name=\"{2}\" value=\"{3}\"{4}>";

            switch(inputType)
            {
                case InputType.CheckboxInline:
                    TProperty checkboxValue = expression.Compile()(htmlHelper.ViewData.Model);
                    Enum checkEnum = (checkboxValue as Enum);
                    TProperty prop = (TProperty)Enum.Parse(nullableType, enumValue.Name.ToString());
                    Enum valEnum = (prop as Enum);
                    bool checkStuff = checkEnum == null ? false : checkEnum.HasFlag(valEnum);

                    return string.Format(
                        inputString, 
                        "checkbox", 
                        propertyName + "-" + enumValue.Name, 
                        propertyName + "[]", 
                        enumValue.Value,
                        checkStuff ? " checked=\"checked\"" : "");
                case InputType.RadioInline:
                    return string.Format(
                        inputString,
                        "radio",
                        propertyName + "-" + enumValue.Name,
                        propertyName,
                        enumValue.Value,
                        expression.Compile()(htmlHelper.ViewData.Model).ToString() == enumValue.Name ? " checked=\"checked\"" : "");
                default:
                    return "";
            }
        }

        private static MvcHtmlString EnumOptionsFor<TModel, TProperty>(this HtmlHelper<TModel> htmlHelper, Expression<Func<TModel, TProperty>> expression, InputType inputType)
        {
            bool nonEnum = !typeof(TProperty).IsEnum;

            string radioString = "<label class=\"" + getInputClass(inputType) + "\">\n{0} {1}\n</label>";
            string propName = GetExpressionMemberName(expression);
            Type type;

            if (typeof(TProperty).IsEnum)
            {
                type = typeof(TProperty);
            }
            else if (typeof(TProperty).Name == typeof(Nullable<>).Name && Nullable.GetUnderlyingType(typeof(TProperty)).IsEnum)
            {
                type = Nullable.GetUnderlyingType(typeof(TProperty));
            }
            else
            {
                throw new ShowMessageException("Cannot call EnumRadioButtonsFor for a non enum property");
            }

            string returnValue = new EnumOptionList<TProperty>(type: type)
                .Select(e => {
                    return string.Format(
                        radioString,
                        //htmlHelper.RadioButtonFor(expression, e.Value, obj).ToHtmlString(),
                        GetInputFor(htmlHelper, expression, propName, inputType, e, type),
                        GetEnumValueDisplayName(type, e.Name)
                    );
                })
                .Aggregate((a, b) => a + "\n\n" + b);

            return new MvcHtmlString(returnValue);
        }

        private static string GetExpressionMemberName<TModel, TProperty>(Expression<Func<TModel, TProperty>> expression)
        {

            LambdaExpression lambda = expression as LambdaExpression;
            if (lambda == null)
                return "";

            MemberExpression memberExpr = null;

            if (lambda.Body.NodeType == ExpressionType.Convert)
            {
                memberExpr =
                    ((UnaryExpression)lambda.Body).Operand as MemberExpression;
            }
            else if (lambda.Body.NodeType == ExpressionType.MemberAccess)
            {
                memberExpr = lambda.Body as MemberExpression;
            }

            if (memberExpr == null)
                return "";

            return memberExpr.Member.Name;
        }

        private static string GetEnumValueDisplayName(Type type, string propertyName)
        {
            var field = type.GetMember(propertyName);
            if(field.Length < 1)
            {
                return propertyName;
            }
            var attributes = field[0].GetCustomAttributes(typeof(DisplayAttribute), false);
            if(attributes.Length < 1)
            {
                return propertyName;
            }
            return (attributes[0] as DisplayAttribute).Name;
        }
    }
}