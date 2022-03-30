function DeleteMasterData() {
    var masterData = {

        ID: $("#ID").val()
    }
    console.log(masterData)
    $.ajax({
        type: "POST",
        url: "/Master/Delete",
        data: { masterClassViewModel: masterData },
        success: function () {
            alert("Success");
            window.location.href = "/Master/GetList"
        },
        error: function () {
            alert("Fail");
            window.location.href = "/Master/Delete"
        }

    })
}