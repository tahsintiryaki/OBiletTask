﻿function SwapLocation() {
    var originId = $("#originId").val();
    var origintext = $("#origin").val();
    var destinationId = $("#destinationId").val();
    var destinationtext = $("#destination").val();
    if (originId != null && origintext != null && destinationId != null && destinationtext != null) {

        $("#originId").val(destinationId);
        $("#origin").val(destinationtext);
        $("#destinationId").val(originId);
        $("#destination").val(origintext);



    } else {
        swal({
            title: "İşlem başarısız",
            text: "",
            icon: "error",
            button: "Ok",
        });
    }
}

 // Tarih bugün ve yarından farklı seçilirse.
$('#datepicker').datepicker({
    language: 'tr', 
    autoclose: true, 
    startDate: 'today' 
}).on('changeDate', function (e) {

    var selectedDate = moment(e.format(), 'DD.MM.YYYY');

    var today = moment().startOf('day');


    var tomorrow = moment().add(1, 'days').startOf('day');


    if (selectedDate.isSame(today, 'day')) {
        $("#today").prop("checked", true);
    } else if (selectedDate.isSame(tomorrow, 'day')) {
        $("#tomorrow").prop("checked", true);
    } else {
        $("#today").prop("checked", false);
        $("#tomorrow").prop("checked", false);
    }
});



function datepickerInit() {

    var tomorrow = new Date();
    tomorrow.setDate(tomorrow.getDate() + 1);

    $('#datepicker').datepicker({
        language: 'tr', 
        autoclose: true, 
        startDate: 'today' 
    });

    // Bugün ve Yarın radio düğmelerine tıklandığında ilgili tarih seçilsin
    $('#today').click(function () {
        $('#datepicker').datepicker('setDate', new Date());
    });

    $('#tomorrow').click(function () {
        $('#datepicker').datepicker('setDate', tomorrow);
    });

    document.getElementById('tomorrow').checked = true;

    $('#datepicker').datepicker('setDate', tomorrow);
    $("#datepicker").prop('readonly', true);
}


$(document).on('click', function (event) {
    console.log('Tıklanan öğe:', event.target);
    // Origin result ve Destination result listelerini kapat
    if (!$(event.target).closest('#originresult, #destinationresult, #origin, #destination').length) {

        $("#originresult").hide();
        $("#destinationresult").hide();
    }
});

$('#origin').on('click', function () {

    $('#originresult').show();
});


//Aynı şehir seçilemez kontrolü.
function CompareOriginandDestinationText(origin, destination) {
    if (origin == destination) {

        swal({
            title: "Uyarı",
            text: "Kalkış ve varış noktası aynı seçilemez",
            icon: "warning",
            button: "Ok",
        });
        return false;
    }
    return true;
}

//Origin result listesinden item seçilirse çalışır.
$('#originresult').on('click', 'li', function () {


    var clickedText = $(this).text();
    var originId = $(this).attr('id');
    $("#originId").val(originId);
    var destinationText = $("#destination").val();
    debugger;
    if (CompareOriginandDestinationText(clickedText, destinationText)) {
        debugger;
        $('#origin').val($.trim(clickedText));

    } else {
        $("#originId").val('');
        $("#origin").val('');
    }


    $("#originresult").hide();
});

$('#destination').on('click', function () {
    $('#destinationresult').show();
});

//Destination result listesinden item seçilirse çalışır.
$('#destinationresult').on('click', 'li', function () {
    var clickedtext = $(this).text();
    var destinationId = $(this).attr('id');
    $("#destinationId").val(destinationId);
    var originText = $("#origin").val();
    if (CompareOriginandDestinationText(originText, clickedtext)) {

        $('#destination').val($.trim(clickedtext));

    } else {
        $("#destinationId").val('');
        $("#destination").val('');
    }

    $("#destinationresult").hide();
});
//Sayfa yüklendiğinde
$(document).ready(function () {

    datepickerInit();

    var storageData = JSON.parse(localStorage.getItem("SearchedJourneyData"));
    if (storageData != null) {



        var listItem = '<li class="list-group-item link-class" id="' + storageData.originId + '">';
        listItem += storageData.origin;

        listItem += '</li>';
        $('#originresult').append(listItem);
        $('#origin').val(storageData.origin);
        $("#originresult").hide();
        $('#originId').val(storageData.originId);





        var listItem2 = '<li class="list-group-item link-class" id="' + storageData.destinationId + '">';
        listItem2 += storageData.destination;

        listItem2 += '</li>';
        $('#destinationresult').append(listItem2);
        $('#destination').val(storageData.destination);
        $("#destinationresult").hide();
        $('#destinationId').val(storageData.destinationId);

        $("#datepicker").val(storageData.date);
        var selectedDate = moment(storageData.date);
        var today = moment();
        var tomorrow = moment().add(1, 'days');

        var radioButton = document.getElementById("radioButton");


        if (selectedDate.isSame(today, 'day') || selectedDate.isSame(tomorrow, 'day')) {
            
        } else {
        
            $("#today").prop("checked", false);
            $("#tomorrow").prop("checked", false);
        }
 

    } else {
        $.ajax({
            method: "POST",
            url: '/Home/GetAllBusLocations',
            contentType: 'application/x-www-form-urlencoded; charset=UTF-8',
            data: {},
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

            if (d.failed == false) {
                $.each(d.data, function (index, item) {



                    var listItem = '<li class="list-group-item link-class" id="' + item.id + '">';
                    listItem += item.name;

                    listItem += '</li>';
                    $('#originresult').append(listItem);
                    $('#origin').val(d.data[0].name);
                    $('#originId').val(d.data[0].id);
                    $("#originresult").hide();



                    $('#destinationresult').append(listItem);
                    $('#destination').val(d.data[2].name);
                    $('#destinationId').val(d.data[2].id);
                    $("#destinationresult").hide();



                });


            } else {
                swal({
                    title: "Hata",
                    text: d.message,
                    icon: "error",
                    button: "Ok",
                });
            }

        }).fail(function (xhr) {

            swal({
                title: "Hata",
                text: "Bir hata oluştu, lütfen tekrar deneyiniz!",
                icon: "error",
                button: "Ok",
            });
        }).always(function () {
            $.unblockUI();
        });
    }


});
//Kalkış noktası arama işlemi
$('#origin').on('input', function () {

    var searchText = $(this).val();



    $.ajax({
        method: "POST",
        url: '/Home/GetBusLocationByText',
        contentType: 'application/x-www-form-urlencoded; charset=UTF-8',
        data: { searchText: searchText },
        beforeSend: function () {

        }
    }).done(function (d) {

        if (d.failed == false) {
            $("#originresult").empty();
            $.each(d.data, function (index, item) {




                var listItem = '<li class="list-group-item link-class" id="' + item.id + '">';
                listItem += item.name;

                listItem += '</li>';
                $('#originresult').append(listItem);


            });


        } else {
            swal({
                title: "",
                text: d.message,
                icon: "error",
                button: "Ok",
            });
        }

    }).fail(function (xhr) {

        swal({
            title: "Hata",
            text: "Bir hata oluştu, lütfen tekrar deneyiniz!",
            icon: "error",
            button: "Ok",
        });
    }).always(function () {

        $("#originId").val('');
    });
});


//Varış noktası arama işlemi
$('#destination').on('input', function () {

    var searchText = $(this).val();



    $.ajax({
        method: "POST",
        url: '/Home/GetBusLocationByText',
        contentType: 'application/x-www-form-urlencoded; charset=UTF-8',
        data: { searchText: searchText },
        beforeSend: function () {

        }
    }).done(function (d) {

        if (d.failed == false) {
            $("#destinationresult").empty();
            $.each(d.data, function (index, item) {


                var listItem = '<li class="list-group-item link-class" id="' + item.id + '">';
                listItem += item.name;

                listItem += '</li>';
                $('#destinationresult').append(listItem);


            });


        } else {
            swal({
                title: "",
                text: d.message,
                icon: "error",
                button: "Ok",
            });
        }

    }).fail(function (xhr) {

        swal({
            title: "Hata",
            text: "Bir hata oluştu, lütfen tekrar deneyiniz!",
            icon: "error",
            button: "Ok",
        });
    }).always(function () {
        $("#destinationId").val('');
    });
});
function GetBusJourneys() {

    var originId = $("#originId").val();
    var originName = $("#origin").val();
    var destinationId = $("#destinationId").val();
    var destinationName = $("#destination").val();
    var date = $("#datepicker").val();
    debugger;
    if (originId != "" && destinationId != "" && date != "") {



        var SearchedJourneyData = {
            originId: originId,
            origin: originName,
            destinationId: destinationId,
            destination: destinationName,
            date: date,

        };

        //Arama sonuçlarını client tarafında localStorage'de tuttum.
        localStorage.setItem("SearchedJourneyData", JSON.stringify(SearchedJourneyData));


        window.location.href = '/Home/Journeys';
    } else {
        swal({
            title: "Uyarı",
            text: "Lütfen * ile işaretli alanları doldurunuz",
            icon: "warning",
            button: "Ok",
        });
    }


}