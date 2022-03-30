function Insertlogin() {
    var userData = {
        UserName: $("#UserName").val(),
        Password: $("#Password").val(),

    }

    $.ajax({
        type: "POST",
        url: "/User/Login",
        data: { userViewModel: userData },

        success: function (data) {
            console.log(data)
            if (data.IsSuccess == true) {
                alert("Success");
                window.location.href = "/User/UserList"
            }
            else {
                alert("User name or password wrong!");
                window.location.href = "/User/Register"
            }

        },
    
    })
}