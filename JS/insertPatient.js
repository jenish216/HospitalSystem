function insertPatient() {
    var radioValue = $('input[name="Gender"]:checked').val();
    var userData = {
        PatientID: $("#PatientID").val(),
        PatientName: $("#PatientName").val(),
        DOB: $("#DOB").val(),
        Gender: radioValue,
        Email: $("#Email").val(),
        Age: $("#Age").val(),
        Contact: $("#Contact").val(),
        Address: $("#Address").val(),
     
    }
    $.ajax({
        type: "POST",
        url: "/Patient/Insert",
        data: { patientViewModel: userData },
        success: function () {
            alert("Success");
            window.location.href = "/Patient/AllPatients"
        },
        error: function () {
            alert("Fail");
            window.location.href = "/Patient/Insert"
        }
    })
    console.log(userData);
}