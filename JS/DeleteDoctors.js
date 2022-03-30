function DeleteDoctors() {
    var userData = {
        DoctorName: $("#DoctorName").val(),
        DoctorExpertise: $("#DoctorExpertise").val(),
        DoctorDegree: $("#DegreeName").val(),

    }
    $.ajax({
        type: "POST",
        url: "/Doctor/Delete",
        data: { doctorViewModel: userData },
        success: function () {
            alert("Success");
            window.location.href = "/Doctor/AllDoctor"
        },
        error: function () {
            alert("Fail");
            window.location.href = "/Doctor/Delete"
        }
    })
    console.log(userData);
}