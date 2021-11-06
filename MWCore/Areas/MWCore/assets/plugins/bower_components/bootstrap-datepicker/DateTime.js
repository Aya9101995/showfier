$(document).ready(function () {
    
   


    $(function DateFunctionCheck() {
        
        var date = new Date();

        $('#DateFrom').datetimepicker({
            format: 'MM/DD/YYYY',
            useCurrent: false, //Important! See issue #1075
        });
        $('#DateTo').datetimepicker({
            format: 'MM/DD/YYYY',
            useCurrent: false, //Important! See issue #1075
        });
        //$("DateFrom").datetimepicker({ dateFormat: "MM/DD/YYYY" }).datetimepicker("setDate", date);
        //$("DateTo").datetimepicker({ dateFormat: "MM/DD/YYYY" }).datetimepicker("setDate", date);

        var DateFrom = $('#DateFrom').val();
        if (DateFrom) {
            $('#DateTo').data("DateTimePicker").minDate(DateFrom);
        }
        var DateTo = $('#DateTo').val();
        if (DateTo) {
            $('#DateFrom').data("DateTimePicker").maxDate(DateTo);
        }
        $("#DateFrom").on("dp.change", function (e) {
            $('#DateTo').data("DateTimePicker").minDate(e.date);
        });
        $("#DateTo").on("dp.change", function (e) {
            $('#DateFrom').data("DateTimePicker").maxDate(e.date);
        });
    });
});


