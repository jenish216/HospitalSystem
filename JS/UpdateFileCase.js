function updateFileCase() {
    var userData = {
        CaseID: $("#CaseID").val(),
        PatientID: $("#patientID").val(),
        RelativeName: $("#Relativename").val(),
        DiseaseID: $("#DiseaseID").val(),
        Status: $("#Status").val(),
        Relative_Relation: $("#relativerelation").val(),
        Contact: $("#Contact").val(),
        AlternateNumber: $("#AlternateNumber").val(),
        Symptoms: $("#Symptoms").val(),
        RoomID: $("#RoomID").val(),
    }
    console.log(userData);
    $.ajax({
        url: "/Home/Edit",
        data: { fileCaseViewModel: userData },
        type: "POST",
        success: function () {
            alert("Success");
            window.location.href = "/Home/GetFileList"
        },
        error: function () {
            alert("Fail");
            window.location.href = "/Home/Edit"
        }
    })

}