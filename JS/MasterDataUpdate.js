function EditMasterData() {
    var masterData = {
        MasterCodeID: $("#MasterCodeName").val(),
        DisplayText: $("#DisplayText").val(),
        ID: $("#ID").val()
    }
    console.log(masterData);
    $.ajax({
        type: "POST",
        url: "/Master/Edit",
        data: { masterClassViewModel: masterData },
        success: function () {
            alert("Success");
            window.location.href = "/Master/GetList"
        },
        error: function () {
            alert("Fail");
            window.location.href = "/Master/Edit"
        }
    })
}