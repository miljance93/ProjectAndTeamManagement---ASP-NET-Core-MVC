// Please see documentation at https://docs.microsoft.com/aspnet/core/client-side/bundling-and-minification
// for details on configuring this project to bundle and minify static web assets.

// Write your JavaScript code.

$(document).ready(function () {
    $(":input[date-picker]").datepicker({
        dateFormat: "yy/mm/dd",
    });
    $(":input[datetime-picker]").datetimepicker({
        dateFormat: "yy/mm/dd",
        timeFormat: "HH:mm:ss"
    });
    $(":input[time-picker]").timepicker({
        timeFormat: "HH:mm:ss"
    });
})
