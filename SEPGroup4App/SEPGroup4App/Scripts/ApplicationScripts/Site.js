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
});