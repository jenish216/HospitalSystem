function DeletePatient() {
    var userData = {
        PatientID: $("#PatientID").val(),
        PatientName: $("#PatientName").val(),
      

    }
    $.ajax({
        type: "POST",
        url: "/Patient/Delete",
        data: { patientViewModel: userData },
        success: function () {
            alert("Success");
            window.location.href = "/Patient/AllPatients"
        },
        error: function () {
            alert("Fail");
            window.location.href = "/Patient/Delete"
        }
    })
    console.log(userData);
}