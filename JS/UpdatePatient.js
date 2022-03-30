function UpdatePatient() {
    var radioValue = $('input[name="Gender"]:checked').val();
    var userData = {
        PatientName: $("#PatientName").val(),
        DOB: $("#DOB").val(),
        Gender: radioValue,
        Email: $("#Email").val(),
        Age: $("#Age").val(),
        Contact: $("#Contact").val(),
        Address: $("#Address").val(),
        PatientID: $("#PatientID").val()
    }
    $.ajax({
        type: "POST",
        url: "/Patient/Update",
        data: { patientViewModel: userData },
        success: function () {
            alert("Success");
            window.location.href = "/Patient/AllPatients"
        },
        error: function () {
            alert("Fail");
            window.location.href = "/Patient/Update"
        }
    })
    console.log(userData);
}