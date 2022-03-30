function insertUserRoleData() {
    var userData = {
        UserRoleID: $("#UserRoleID").val(),
        RoleID: $("#RoleName").val(),
        UserID: $("#UserName").val(),



    }
    $.ajax({
        type: "POST",
        url: "/UserRole/AddUserRole",
        data: { userRoleViewModel: userData },
        success: function () {

            alert("Success");
            window.location.href = "/UserRole/GetUserRoleList"
        },
        error: function () {
            alert("Fail");
            window.location.href = "/UserRole/AddUserRole"
        }
    })
    console.log(userData);
}

function UpdateUserRoleData() {
    var userData = {
        UserRoleID: $("#UserRoleID").val(),
        RoleID: $("#RoleName").val(),
        UserID: $("#UserName").val(),



    }
    $.ajax({
        type: "POST",
        url: "/UserRole/UpdateUserRole",
        data: { userRoleViewModel: userData },
        success: function () {
            alert("Success");
            window.location.href = "/UserRole/GetUserRoleList"
        },
        error: function () {
            alert("Fail");
            window.location.href = "/UserRole/UpdateUserRole"
        }
    })
    console.log(userData);
}

function delUserRoleData() {
    var UserData = {
        UserRoleID: $("#UserRoleID").val(),
    }
    $.ajax({
        type: "POST",
        url: "/UserRole/Delete",
        data: { userRoleViewModel: UserData },
        success: function () {
            alert("Success");
            window.location.href = "/UserRole/GetUserRoleList"
        },
        error: function () {
            alert("Fail");
            window.location.href = "/UserRole/Delete"
        }
    })
    console.log(UserData);
}