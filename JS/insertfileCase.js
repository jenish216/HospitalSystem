function insertFileCase() {
    var userData = {
        PatientID: $("#patientID").val(),
        RelativeName: $("#Relativename").val(),
        DiseaseID: $("#DiseaseID").val(),
        Status: $("#Status").val(),
        Relative_Relation: $("#relativerelation").val(),
        Contact: $("#Contact").val(),
        AlternateNumber: $("#AlternateNumber").val(),
        Symptoms: $("#Symptoms").val(),
        RoomID: $("#RoomID").val()
    }
    $.ajax({
        type: "POST",
        url: "/Home/Insert",
        data: { fileCaseViewModel: userData },   
        success: function () {
            alert("Success");
            window.location.href = "/Home/GetFileList"
        },
        error: function () {
            alert("Fail");
            window.location.href = "/Home/Insert"
        }
    })
    

}