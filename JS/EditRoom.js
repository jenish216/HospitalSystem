function EditRoom() {
    var Room = {
        RoomID: $("#RoomID").val(),
        RoomType: $("#RoomType").val(),
        Charge: $("#Charge").val(),
        TotalRoom: $("#TotalRoom").val(),

    }
    $.ajax({
        type: "POST",
        url: "/Room/EditRoom",
        data: { roomViewModel: Room },
        success: function () {
            alert("Success");
            window.location.href = "/Room/AllotedRooms"
        },
        error: function () {
            alert("Fail");
            window.location.href = "/Room/EditRoom"
        }
    })
    console.log(Room);
}