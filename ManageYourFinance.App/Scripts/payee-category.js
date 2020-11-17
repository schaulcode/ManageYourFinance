$("#PayeeID").change(function () {
    $.get("/api/Payee/" + $(this).val(), function (data) {
        (data != 0)? $("#CategoryID").val(data): $("#CategoryID").val(0);
        
        $.get("/api/Category/" + data, function (data) {
            if (data == "Income") $("#category-add-on").css("background-color", "green");
            if (data == "Expense") $("#category-add-on").css("background-color", "red");
        })
    })
})