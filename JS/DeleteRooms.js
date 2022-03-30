function DeleteRooms() {
    var userData = {
        RoomID: $("#RoomID").val(),
     


    }
    $.ajax({
        type: "POST",
        url: "/Room/Delete",
        data: { roomViewModel: userData },
        success: function () {
            alert("Success");
            window.location.href = "/Room/AllotedRooms"
        },
        error: function () {
            alert("Fail");
            window.location.href = "/Room/Delete"
        }
    })
    console.log(userData);
}