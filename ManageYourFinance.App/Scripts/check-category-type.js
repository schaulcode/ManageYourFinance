$("document").ready(function () {
    var respond = $.get("/api/Category/" + $("#CategoryID").val(), function (data) {
        if (data == "Income") {
            $("#category-add-on").css("background-color", "green");
        }
        if (data == "Expense") {
            $("#category-add-on").css("background-color", "red");
        }
    });
})
$("#CategoryID").change(function () {
    var respond = $.get("/api/Category/" + $(this).val(), function (data) {
        if (data == "Income") {
            $("#category-add-on").css("background-color", "green");
        }
        if (data == "Expense") {
            $("#category-add-on").css("background-color", "red");
        }
    });
    
})