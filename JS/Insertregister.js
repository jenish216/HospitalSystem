function Insertregister() {
    var userData = {
        UserID: $("#UserID").val(),
        EmailAddress: $("#Email").val(),
        UserName: $("#UserName").val(),
        Password: $("#Password").val(),

    }
    $.ajax({
        type: "POST",
        url: "/User/Register",
        data: { userViewModel: userData },
        success: function () {
            alert("Success");
            window.location.href = "/User/Login"
        },
        error: function () {
            alert("Fail");
            window.location.href = "/User/Register"
        }
    })
    console.log(userData);
}





//function validateEmail(email) {
//    const re = /^(([^<>()\[\]\\.,;:\s@"]+(\.[^<>()\[\]\\.,;:\s@"]+)*)|(".+"))@((\[[0-9]{1,3}\.[0-9]{1,3}\.[0-9]{1,3}\.[0-9]{1,3}\])|(([a-zA-Z\-0-9]+\.)+[a-zA-Z]{2,}))$/;
//    return re.test(String(email).toLowerCase());
//}
//function validateName() {
//    var name = $('#Name').val();
//    if (name == null || name == "") {
//        return false;
//    } else {
//        return true;
//    }
//}

//function RegistrationvalidateEmail() {
//    let Regemail = $('#EmailId').val();
//    var check = validateEmail(Regemail);
//    if (check === true) {
//        return true;
//    }
//    else {
//        return false;
//    }
//}

//function ValidateRegForm() {
//    if (validateName()) {
//        $('#reg_btn ').prop('disabled', false);
//    }
//    else {
//        $('#reg_btn ').prop('disabled', true);
//        return;
//    }
//    if (RegistrationvalidateEmail()) {
//        $('#reg_btn ').prop('disabled', false);
//    }
//    else {
//        $('#reg_btn ').prop('disabled', true);
//        return;
//    }
//}





