$(function () {
    // Initiating the datepickers
    $('.date').datetimepicker({
        pickTime: false,
        format: "DD/MM/YYYY"
    });

    // Add required to all required fields
    $('.required').each(function (i, ele) {
        
        $(ele).prepend('<span>*</span> ');

        $(ele).find('span').tooltip({
            title: "This is a required field"
        });
    });

    // Overriding the default validation of dates with the moment.js implementation using the DateTime formats we'll be using
    $.validator.addMethod('date', function (value, element, params) {
        if (this.optional(element)) {
            return true;
        }
        var result = false;
        try {
            var m1 = new moment(value, ["DD/MM/YYYY"]);
            result = m1.isValid();
        } catch (err) {
            console.log(err);
            result = false;
        }
        return result;
    });

    // Get a list of the parent tab panes of an field validation error classes (fields with an error)
    var errorPanes = $('.field-validation-error').parents('.tab-pane');

    if (errorPanes.length > 0) {
        // Go through the form nav tabs and compare the href of the a element to the id of the tab panes
        $('.nav-tabs li a').each(function (i, a) {
            var continuing = true;
            errorPanes.each(function (i, t) {
                if ($(a).attr('href') == '#' + $(t).attr('id')) {
                    // show tab pane
                    $(a).tab('show');
                    // Set continuing to false so we break out
                    continuing = false;
                }
                return continuing;
            });
            return continuing;
        });
    }
});