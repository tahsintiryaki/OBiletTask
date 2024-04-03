$(document).ready(function () {

    var readedLocalStorage = JSON.parse(localStorage.getItem("SearchedJourneyData"));
    var newFormatDepartureDate = moment(readedLocalStorage.date, "DD.MM.YYYY").format("YYYY.MM.DD");

    $.ajax({
        method: "POST",
        url: '/Home/GetBusJourneys',

        data: { originid: readedLocalStorage.originId, destinationid: readedLocalStorage.destinationId, departuredate: newFormatDepartureDate },
        beforeSend: function () {
            $.blockUI.defaults.css = {
                padding: 0,
                margin: 0,
                width: '30%',
                top: '40%',
                left: '35%',
                textAlign: 'center',
                cursor: 'wait'
            };
            $.blockUI({ message: $('#load') });
        }
    }).done(function (d) {
        debugger;
        if (d.failed == true) {
            swal({
                title: "",
                text: d.message,
                icon: "error",
                button: "Ok",
            }).then((value) => { window.location.href = "/Home/Index" });

        } else {

            if (readedLocalStorage != null) {
                $("#txtLocation").text(readedLocalStorage.origin + "-" + readedLocalStorage.destination);


                var formattedDate = moment(readedLocalStorage.date, "DD.MM.YYYY").locale('tr').format("DD MMMM dddd");

                $("#txtDate").text(formattedDate);
            }
            $("#_partialJourneyList").html(d);
        }

    }).fail(function (xhr) {
        debugger;
        swal({
            title: "Hata",
            text: "Beklenmedik bir hata oluştu, lütfen tekrar deneyiniz!",
            icon: "error",
            button: "Ok",
        }).then((value) => { window.location.href = "/Home/Index" });

         
    }).always(function () {
        $.unblockUI();
    });

});