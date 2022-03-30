function insertDoctor() {
    var userData = {
        DoctorID: $("#DoctorID").val(),
        DoctorName: $("#DoctorName").val(),
        DoctorExpertise: $("#DoctorExpertise").val(),
        DoctorDegree: $("#DegreeName").val(),
        
    }
    $.ajax({
        type: "POST",
        url: "/Doctor/Insert",
        data: { doctorViewModel: userData },
        success: function () {
             alert("Success");
            window.location.href = "/Doctor/AllDoctor"
        },
        error: function () {
            alert("Fail");
            window.location.href = "/Doctor/Insert"
        }
    })
    console.log(userData);
}
