function DeleteFileCase() {
    var userData = {
        CaseID: $("#CaseID").val(),
       
  }
 
    $.ajax({
        url: "/Home/Delete",
        data: { fileCaseViewModel: userData },
        type: "POST",
        success: function () {
            alert("Success");
            window.location.href = "/Home/GetFileList"
        },
        error: function () {
            alert("Fail");
            window.location.href = "/Home/Delete"
        }
    })
    console.log(userData);
}