function insertMasterData() {
    var masterData = {
        MasterCodeID: $("#MasterCodeName").val(),
        DisplayText: $("#DisplayText").val(),
        ID: $("#ID").val()
    }
    $.ajax({
        type: "POST",
        url: "/Master/Insert",
        data: { masterClassViewModel: masterData },
        success: function () {
            alert("Success");
            window.location.href = "/Master/GetList"
        },
        error: function () {
            alert("Fail");
            window.location.href = "/Master/Insert"
        }
    })
}