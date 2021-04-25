var toValidate; // variable holding form validator
var customerConfirmation = false;
var addedAddresses = 0;
var addresses = [];
var locationId = 0;

//$(document).ajaxStop($.unblockUI);

var states = ['Alabama', 'Alaska', 'Arizona', 'Arkansas', 'California',
    'Colorado', 'Connecticut', 'Delaware', "District of Columbia", 'Florida', 'Georgia', 'Hawaii',
    'Idaho', 'Illinois', 'Indiana', 'Iowa', 'Kansas', 'Kentucky', 'Louisiana',
    'Maine', 'Maryland', 'Massachusetts', 'Michigan', 'Minnesota',
    'Mississippi', 'Missouri', 'Montana', 'Nebraska', 'Nevada', 'New Hampshire',
    'New Jersey', 'New Mexico', 'New York', 'North Carolina', 'North Dakota',
    'Ohio', 'Oklahoma', 'Oregon', 'Pennsylvania', 'Rhode Island',
    'South Carolina', 'South Dakota', 'Tennessee', 'Texas', 'Utah', 'Vermont',
    'Virginia', 'Washington', 'West Virginia', 'Wisconsin', 'Wyoming'
];

var houseStories = [
    '1-2 Stories', '1-3 Stories', '1-4 Stories', '1-5 Stories', '1-6 Stories'
];

var currentFloorApt = [];
for (var i = 1; i < 100; i++) {
    currentFloorApt.push(i);
}

var bedrooms = [];
for (var i = 1; i < 50; i++) {
    bedrooms.push(i);
}

var boxCount = [
    "0",
    "10 - 20",
    "20 - 30",
    "30 - 40",
    "40 - 50",
    "50 - 75",
    "75 - 100",
    "100+"
];

var locationTypes = ["Starting Location", "Ending Location", "Additional Stop"];

$(document).ready(function () {

    $("html body").on("click", function () {
        var values = $("input")
            .map(function () { return $(this).attr("id"); }).get();

        console.log(values)
    })

    /* Form Elements
	==========================================================*/
    $('html').on('click', '.rbox', toggleRbox);
    $('html').on('click', '.cbox', toggleCbox);
    $('html').on('click', '.dropdown-menu a', setBootstrapDropdownSelection);
    $('html').on('click', '#gotoAddLocation', scrollToDescriptionBox);

    $('html').on('click', '.modal-footer button.submit', submitEstimateForm);
    //$('html').on('click', 'button.submit', cancelEstimateForm);

    $('html').on('click', '#addAddress', addAddress);
    $('html').on('click', '#cancelAddAddress', cancelAddAddress);
    $('html').on('click', '#addTheAddress', addTheAddress);
    $('html').on('click', '#removeAddressLine', removeAddressLine);

    $('html').on('click', "input[type='submit']", validateNumberOfAddresses);

    $('html').on('click', "#clearForm", cancelAddAddress);
    $('html').on('click', "#cancelAddress", cancelAddAddress);

    $("html").on("click", "#rgroup-HouseOrApt .rbox", getAddressTypeForm);

    $('html').on('click', "#rgroup-HouseOrApt", function () {
        $('.btn-clearAddress').hide();
    });

    $("#addressType").on('change', onAddressTypeChange);

    $('html').on('change', ".select2", function () {
        $(this).valid();

        if ($(this).attr('id') == "addressType") {

            var val = $(this).val();

            if (val == "Starting Location") {
                for (var i = 0; i < addresses.length; i++) {
                    if (addresses[i].addressType == "Starting Location") {
                        $('#secondStartingAddress').modal('show');
                        return false;
                    }
                }
            }
            else if (val == "Ending Location") {

                var numEndings = 0;
                for (var q = 0; q < addresses.length; q++) {
                    if (addresses[q].addressType == "Ending Location") {
                        numEndings++;
                    }
                }

                if (numEndings < 1) {
                    $('.q-inventory').hide();
                    $('.q-inventory').find('input[type="hidden"]').removeClass('required').val(null);
                    $('.q-inventory-label').text("So that we can make a more educated estimate for your move, please provide us a detailed description of the items in each room at this location.");
                } else {
                    $('.q-inventory').show();
                    $('.q-inventory').find('input[type="hidden"]').addClass('required').val(null);
                    $('.q-inventory-label').text("Will we be dropping off items at this second ending location? If so please list which items from the starting location.");
                }

            }
        }
    });


    $("#to").datepicker({
        minDate: new Date(),
        numberOfMonths: 1,
        showButtonPanel: true,
        onClose: function (selectedDate) {
        }
    });


    $(".datepicker").datepicker({
        numberOfMonths: 1,
        showButtonPanel: true,
        onClose: function (selectedDate) {
        }
    });;

    $('.dropdown-toggle').dropdown();

    $('.estimate-nav-item').tooltip();

    $('form[name="estimateForm"] input[type="submit"]').on('click', function (e) {
        e.preventDefault();
        var form = $("form");

        var hasStarting = false;
        var hasEnding = false;

        for (var i = 0; i < addresses.length; i++) {
            if (addresses[i].addressType == "Starting Location") {
                hasStarting = true;
            } else if (addresses[i].addressType == "Ending Location") {
                hasEnding = true;
            }
        }

        if (!$.trim($('#address').is(':empty')) || addedAddresses < 2) {

            var showModal = false;


            if (addedAddresses < 2) {
                $('#notEnoughAddresses').show();
                $('#openAddressForm').hide();
                $('#noStartingOrEnding').hide();
                showModal = true;
            } else if (!$.trim($('#address').is(':empty'))) {
                $('#notEnoughAddresses').hide();
                $('#openAddressForm').show();
                $('#noStartingOrEnding').hide();
                showModal = true;
            }

            $('#addressModal').modal('show');

            $("#addressModal").on("click", ".addressOk", function () {
                scrollToDescriptionBox();
            });

            return;

        } else if (!hasStarting || !hasEnding) {
            $('#notEnoughAddresses').hide();
            $('#openAddressForm').hide();
            $('#noStartingOrEnding').show();

            $('#addressModal').modal('show');

            $("#addressModal").on("click", ".addressOk", function () {
                scrollToDescriptionBox();
            });

            return;

        } else if (form.valid()) {
            $('#myModal').modal('show');
        }

    });

    oddEven();

    var validator = $('form[name="estimateForm"]').validate({
        ignore: 'input.required.typeahead.tt-hint',
        highlight: function (element, error) {

            // textbox, textarea
            $(element).addClass('error');

            // radios
            if ($(element).hasClass('type-radio')) {
                //console.log($(element))
                $(element).closest('.question').find('.heading').addClass('error');
            }

            //dropdowns
            if ($(element).hasClass('type-dropdown')) {
                $(element).closest('.input.select')
                    .find('a.dropdown-toggle')
                    .addClass('error')
                    .css('background-color', 'red');
                $(element).closest('.input.select')
                    .find('a.dropdown-toggle')
                    .find('span')
                    .css('color', 'white');
            }

            //big checkbox
            if ($(element).hasClass('agree')) {
                $(element).parent().find('.heading.bigCheckbox').css('color', "red");
            }

            if ($(element).hasClass('type-select2')) {
                $(element).closest('.field').find('.select2-selection').addClass('error');
            }

            var errors = validator.numberOfInvalids();

            if (addedAddresses < 2) {
                errors++;
            }

            $('.errorList').show();
            $('.errorCount').text(errors);
        },
        unhighlight: function (element, error) {
            // textbox, textarea
            $(element).removeClass('error');

            if ($(element).hasClass("tt-input")) {
                $(element).closest('.twitter-typeahead').find('.tt-hint.error').removeClass('error');
            }

            // radios
            if ($(element).hasClass('type-radio')) {
                $(element).closest('.question').find('.heading').removeClass('error');
            }

            //dropdowns
            if ($(element).hasClass('type-dropdown')) {
                $(element).closest('.input.select')
                    .find('a.dropdown-toggle')
                    .removeClass('error')
                    .css('background-color', 'white');
                $(element).closest('.input.select')
                    .find('a.dropdown-toggle')
                    .find('span')
                    .css('color', '#73726e');
            }

            //big checkbox
            if ($(element).hasClass('agree')) {
                $(element).parent().find('.heading.bigCheckbox').css('color', "white");
            }

            if ($(element).hasClass('type-select2')) {
                $(element).closest('.field').find('.select2-selection').removeClass('error');
            }

            var errors = validator.numberOfInvalids();
            if (errors > 0) {
                $('.errorCount').text(validator.numberOfInvalids());
                $('.errorList').show();
            } else {
                $('.errorList').hide();
            }
        },
        submitHandler: function (form) {
            if (!customerConfirmation) {
                $('#myModal').modal('show');
            } else {
                showSpinner();
                //form.submit();
                //return false;
            }
        }
    });

});

function submitEstimateForm(e) {
    e.preventDefault();
    customerConfirmation = true;

    //cancelAddAddress(e);

    $('#myModal').modal('hide');

    $.blockUI({
        message: '<h1><img src="/Content/themes/base/images/spinner.gif" /> Just a moment...</h1>',
        baseZ: 5000,
        css: {
            color: '#FFF',
            border: 'none',
            backgroundColor: '#222',
            padding: '20px',
            width: '35%',
            left: '30%'
        },
        overlayCSS: {
            backgroundColor: '#FFF',
            opacity: 0.6,
            cursor: 'wait'
        }
    });

    $('form').submit();
    return false;
}

function cancelEstimateForm() {
    customerConfirmation = false;
}

function scrollToDescriptionBox(e) {
    if (e) {
        e.preventDefault();
    }

    if ($(".slide.addresses").offset() != undefined) {
        $('html, body').animate({
            scrollTop: $(".slide.addresses").offset().top - 50
        }, 300);
    }

}

function addAddress(e) {
    e.preventDefault();

    //$('html #addAddress').removeClass('show').addClass('hide');
    $('html #addAddress').addClass('d-none');


    $.ajax({
        url: "/Estimate/GetAddressForm",
        method: "GET",
        success: function (result) {

            $('#address').html(result);
            $('.btn-clearAddress').show();

            //$('select.state').select2({
            //    data: states,
            //    maximumSelectionLength: 2
            //});

            //$('select.addressType').select2({
            //    data: locationTypes,
            //    maximumSelectionLength: 2,
            //    width: "style"
            //});

            setupInputs();

            //$('#HouseStories').select2({
            //    data: houseStories,
            //    maximumSelectionLength: 2,
            //    placeholder: 'Select your house stories',
            //    width: "auto"
            //});

            //$('#AptFloor').select2({
            //    data: currentFloorApt,
            //    maximumSelectionLength: 2,
            //    placeholder: 'Select your apartment floor number',
            //    width: "auto"
            //});

            //$('#NumberOfBedrooms').select2({
            //    data: bedrooms,
            //    maximumSelectionLength: 2,
            //    placeholder: 'Select number of rooms',
            //    width: "auto"
            //});
        }
    });

    //$('select.addAddress').select2({
    //    data: ["Starting Location", "Ending Location", "Storage Unit", "Office"],
    //    maximumSelectionLength: 2,
    //    dropdownAutoWidth: true,
    //    width: 'auto',
    //    placeholder: 'Select location type'
    //});
}

function getAddressTypeForm(e) {

    $.ajax({
        url: "/Estimate/GetAddressFormType?type=" + $(this).attr('id'),
        method: "GET",
        success: function (result) {

            $('#addressTypeForm').html(result);

            showHideInventoryField();

            setupInputs();
           
        }
    });
}

function onAddressTypeChange(e) {
    showHideInventoryField();
}

function showHideInventoryField() {
    if ($("#addressType").val() == "Ending Location") {
        $('#qi-inventory').hide().find('textarea').removeClass('required.error').val("");
    } else {
        $('#qi-inventory').show().find('textarea').addClass('required').val("");
    }
}

function setupInputs() {
    $('select.addressType').select2({
        data: locationTypes,
        maximumSelectionLength: 2,
        width: "style",
        placeholder: "Select address type",
        allowClear: true
    });

    $('select.state').select2({
        data: states,
        maximumSelectionLength: 2,
        placeholder: "Select a state",
        allowClear: true
    });

    var type = $("#HouseOrApt").val();

    switch (type) {
        case "House":
            $('#NumberOfBedrooms').select2({
                data: bedrooms,
                maximumSelectionLength: 2,
                placeholder: 'Select number of rooms',
                allowClear: true,
                width: "auto"
            });

            $('select.boxCount').select2({
                data: boxCount,
                maximumSelectionLength: 2,
                dropdownAutoWidth: true,
                width: 'auto',
                placeholder: 'Select your box count',
                allowClear: true
            });

            $('select.stories-house').select2({
                data: houseStories,
                maximumSelectionLength: 2,
                dropdownAutoWidth: true,
                width: 'auto',
                placeholder: 'Select your house stories',
                allowClear: true
            });

            $('select.floor-apt').select2({
                data: currentFloorApt,
                maximumSelectionLength: 2,
                dropdownAutoWidth: true,
                width: 'auto',
                placeholder: 'Select your apartment floor number',
                allowClear: true
            });

            break;

        case "Apartment":
            $('#NumberOfBedrooms').select2({
                data: bedrooms,
                maximumSelectionLength: 2,
                placeholder: 'Select number of rooms',
                width: "auto",
                allowClear: true
            });

            $('select.boxCount').select2({
                data: boxCount,
                maximumSelectionLength: 2,
                dropdownAutoWidth: true,
                width: 'auto',
                placeholder: 'Select your box count',
                allowClear: true
            });

            $('select.apt-floor').select2({
                data: currentFloorApt,
                maximumSelectionLength: 2,
                dropdownAutoWidth: true,
                width: 'auto',
                placeholder: 'Select your apartment floor number',
                allowClear: true
            });

            break;

        case "Office":
            $('select.boxCount').select2({
                data: boxCount,
                maximumSelectionLength: 2,
                dropdownAutoWidth: true,
                width: 'auto',
                placeholder: 'Select your box count',
                allowClear: true
            });

            $('select.apt-floor').select2({
                data: currentFloorApt,
                maximumSelectionLength: 2,
                dropdownAutoWidth: true,
                width: 'auto',
                placeholder: 'Select your apartment floor number',
                allowClear: true
            });

            break;

        case "Storage-Unit":
            $('select.boxCount').select2({
                data: boxCount,
                maximumSelectionLength: 2,
                dropdownAutoWidth: true,
                width: 'auto',
                placeholder: 'Select your box count',
                allowClear: true
            });

            break;

        default:
    }
}

function cancelAddAddress(e) {

    if (e) {
        e.preventDefault();

        var targetId = $(e.target).attr('id');

        if (targetId === "clearForm" || targetId === "cancelAddress") {
            var target = $(e.target).closest('.slide');

            $('html, body').animate({
                scrollTop: parseInt($(target).offset().top) - 50
            }, 300);

            $('html #addAddress').removeClass('hide').addClass('show');
        }

    }


    $('#address').empty();
}

function addTheAddress(e) {
    e.preventDefault();

    var $inputs = $('#address :input');

    var values = {};
    $inputs.each(function () {
        values[this.name] = $(this).val();
    });

    var addressValid = false;

    if (values.addressType && values.Address1 && values.City && values.loc1State && values.Postcode) {

        values.id = locationId;

        var newAddress = "<li class=\"addressLine\" data-id=\"" + locationId + "\"><div class=\"icons\"><i class=\"fa fa-times\" id=\"removeAddressLine\"></i><i class=\"fa fa-bars\" id=\"sortAddress\"></i></div><div class=\"address\">" + values.addressType + "<br> ";

        locationId++;

        if (values.BuildingName.length) {
            newAddress += values.BuildingName + "<br> ";
        }

        newAddress += values.Address1 + ' ';

        if (values.AptNum.length) {
            newAddress += values.AptNum + ", ";
        }

        newAddress += values.City + ', ' + values.loc1State + ', ' + values.Postcode;

        newAddress += "</div></div>";

        $('#list li.note').hide();
        $('#addressList #list').append(newAddress);

        $('#address').empty();

        increaseAddressCount();

        createHiddenAddressAnswers(values);

        $('html #addAddress').removeClass('hide').addClass('show');

        scrollToDescriptionBox();

        if (addedAddresses > 1) {
            $(".fa-bars").show();
            $("#list").sortable({
                axis: "y",
                handle: ".fa-bars",
                items: ".addressLine",
                opacity: 0.5,
                stop: sortAddresses
            });
            $('.sortNote').show();
        } else {
            $(".fa-bars").hide();
            if ($("#list").sortable()) {
                $("#list").sortable("destroy");
            }

            $('.sortNote').hide();
        }

        pushAddress(values);

    } else {

        $inputs.each(function () {
            if ($(this).hasClass('required')) {

                if ($(this).val().length == 0) {
                    if ($(this).hasClass('type-select2')) {
                        $(this).closest('.field').find('.select2-selection').addClass('error');

                    } else if ($(this).hasClass('type-radio')) {
                        $(this).closest('.question').find('.heading').addClass('error');
                    }
                    else {
                        $(this).addClass("error");
                    }
                }
            }
        });
    }
}

function pushAddress(values) {


    console.log('values ', values)

    var address = {
        "id": values.id,
        "addressType": values.addressType,
        "BuildingName": values.BuildingName,
        "Address1": values.Address1,
        "AptNum": values.AptNum || "",
        "City": values.City,
        "loc1State": values.loc1State,
        "Postcode": values.Postcode,
        "ElevatorStairs": values.ElevatorStairs,
        "ElevatorStairsDescription": values.ElevatorStairsDescription || "",
        "HouseOrApt": values.HouseOrApt || "",
        "HouseStories": values.HouseStories || 0,
        "Inventory": values.Inventory || "",
        "LongWalks": values.LongWalks || false,
        "LongWalksDescription": values.LongWalksDescription || "",
        "Notes": values.Notes || "",
        "NumberOfBedrooms": values.NumberOfBedrooms || 0,
        "SpecialCare": values.SpecialCare || false,
        "SpecialCareDescription": values.SpecialCareDescription || "",
        "Stairs": values.Stairs || false,
        "StairsDescription": values.StairsDescription || "",
        "BoxCount": values.BoxCount || 0,
        "AptFloor": values.AptFloor || 0,
        "ApartmentMultipleLevelsDescription": values.ApartmentMultipleLevelsDescription || "",
        "StorageType": values.StorageType || "",
        "StorageGroundFloorElevator": values.StorageGroundFloorElevator || "",
        "StorageLongWalks": values.StorageLongWalks || false,
        "StorageLongWalksDescription": values.StorageLongWalksDescription || ""
    }

    console.log(address)

    addresses.push(address);

    //console.log(addresses);
}

function createHiddenAddressAnswers(values) {

    //Object.keys(values).forEach(function (key) {
    //    console.log(key, values[key]);
    //});

    var answerWrapper = "<div class='answerWrapper' data-id=\'" + values.id + "\'>";
    var addressType = "<input type=\"hidden\" value=\"" + values.addressType + "\" name='AddressType' id='AddressType'>";
    var buildingName = "<input type=\"hidden\" value=\"" + values.BuildingName + "\" name='BuildingName' id='BuildingName'>";
    var address1 = "<input type=\"hidden\" value=\"" + values.Address1 + "\" name='Address1' id='Address1'>";
    var aptNum = "<input type=\"hidden\" value=\"" + values.AptNum + "\" name='AptNum' id='AptNum'>";
    var city = "<input type=\"hidden\" value=\"" + values.City + "\" name='City' id='City'>";
    var state = "<input type=\"hidden\" value=\"" + values.loc1State + "\" name='State' id='State'>";
    var postcode = "<input type=\"hidden\" value=\"" + values.Postcode + "\" name='Postcode' id='Postcode'>";
    var elevatorStairs = "<input type=\"hidden\" value=\"" + values.ElevatorStairs + "\" name='ElevatorStairs' id='ElevatorStairs'>";
    var elevatorStairsDescription = "<input type=\"hidden\" value=\"" + values.ElevatorStairsDescription + "\" name='ElevatorStairsDescription' id='ElevatorStairsDescription'>";
    var houseOrApt = "<input type=\"hidden\" value=\"" + values.HouseOrApt + "\" name='HouseOrApt' id='HouseOrApt'>";
    var houseStories = "<input type=\"hidden\" value=\"" + values.HouseStories + "\" name='HouseStories' id='HouseStories'>";
    var inventory = "<input type=\"hidden\" value=\"" + values.Inventory + "\" name='Inventory' id='Inventory'>";
    var longWalks = "<input type=\"hidden\" value=\"" + values.LongWalks + "\" name='LongWalks' id='LongWalks'>";
    var longWalksDescription = "<input type=\"hidden\" value=\"" + values.LongWalksDescription + "\" name='LongWalksDescription' id='LongWalksDescription'>";
    var notes = "<input type=\"hidden\" value=\"" + values.Notes + "\" name='Notes' id='Notes'>";
    var numberOfBedrooms = "<input type=\"hidden\" value=\"" + values.NumberOfBedrooms + "\" name='NumberOfBedrooms' id='NumberOfBedrooms'>";
    var specialCare = "<input type=\"hidden\" value=\"" + values.SpecialCare + "\" name='SpecialCare' id='SpecialCare'>";
    var specialCareDescription = "<input type=\"hidden\" value=\"" + values.SpecialCareDescription + "\" name='SpecialCareDescription' id='SpecialCareDescription'>";
    var stairs = "<input type=\"hidden\" value=\"" + values.Stairs + "\" name='Stairs' id='Stairs'>";
    var stairsDescription = "<input type=\"hidden\" value=\"" + values.StairsDescription + "\" name='StairsDescription' id='StairsDescription'>";
    var boxCount = "<input type=\"hidden\" value=\"" + values.BoxCount + "\" name='BoxCount' id='BoxCount'>";
    var aptFloor = "<input type=\"hidden\" value=\"" + values.AptFloor + "\" name='AptFloor' id='AptFloor'>";
    var apartmentMultipleLevelsDescription = "<input type=\"hidden\" value=\"" + values.ApartmentMultipleLevelsDescription + "\" name='ApartmentMultipleLevelsDescription' id='ApartmentMultipleLevelsDescription'>";
    var storageType = "<input type=\"hidden\" value=\"" + values.StorageType + "\" name='StorageType' id='StorageType'>";
    var storageGroundFloorElevator = "<input type=\"hidden\" value=\"" + values.StorageGroundFloorElevator + "\" name='StorageGroundFloorElevator' id='StorageGroundFloorElevator'>";


    var slw;
    if (values.StorageLongWalks == "Yes") {
        slw = true;
    } else {
        slw = false;
    }

    var storageLongWalks = "<input type=\"hidden\" value=\"" + slw + "\" name='StorageLongWalks' id='StorageLongWalks'>";
    var storageLongWalksDescription = "<input type=\"hidden\" value=\"" + values.StorageLongWalksDescription + "\" name='StorageLongWalksDescription' id='StorageLongWalksDescription'>";

    answerWrapper += addressType;
    answerWrapper += buildingName;
    answerWrapper += address1;
    answerWrapper += aptNum;
    answerWrapper += city;
    answerWrapper += state;
    answerWrapper += postcode;
    answerWrapper += elevatorStairs;
    answerWrapper += elevatorStairsDescription;
    answerWrapper += houseOrApt;
    answerWrapper += houseStories;
    answerWrapper += inventory;
    answerWrapper += longWalks;
    answerWrapper += longWalksDescription;
    answerWrapper += notes;
    answerWrapper += numberOfBedrooms;
    answerWrapper += specialCare;
    answerWrapper += specialCareDescription;
    answerWrapper += stairs;
    answerWrapper += stairsDescription;
    answerWrapper += storageType;
    answerWrapper += storageLongWalks;
    answerWrapper += storageLongWalksDescription;
    answerWrapper += boxCount;
    answerWrapper += aptFloor;
    answerWrapper += apartmentMultipleLevelsDescription;
    answerWrapper += storageGroundFloorElevator;
    answerWrapper += "</div>";

    $('#answers').append(answerWrapper);

    formatAddressInputs();
}

function sortAddresses() {

    $('#answers').empty();

    $('ul#list').find(".addressLine").each(function () {
        var index = $(this).data("id");

        for (var i = 0; i < addresses.length; i++) {
            if (addresses[i].id == index) {
                createHiddenAddressAnswers(addresses[i]);
            }
        }
    });
}

function formatAddressInputs() {

    var x = 0;

    $('.answerWrapper').each(function (e) {

        //console.log($(this).data("id"), index)

        $(this).find('input').each(function () {

            if ($(this).val() == "undefined") {

                $(this).remove();

            } else {

                if ($(this).attr('id') !== undefined) {

                    var idName;
                    var id;

                    //console.log("current ", $(this).attr('id'))

                    if ($(this).attr('id').indexOf("]") !== -1) {

                        var temp = $(this).attr('id').split("].");

                        var myArray = [];

                        $.each(temp, function (index, value) {
                            myArray.push(value);
                        });

                        var idName = myArray[1];

                    } else {
                        idName = $(this).attr('id');
                    }

                    //console.log(typeof idName);

                    if (typeof idName == "object") {
                        id = idName[1];
                    } else {
                        id = idName;
                    }

                    $(this).attr('id', "[" + x + "]." + id).attr('name', "[" + x + "]." + id);

                    //console.log("changed ", $(this).attr('id'), $(this).parent().data('id'));
                }
            }

        });

        x++;
    });
}

function validateNumberOfAddresses() {
    //cancelAddAddress();

    if (addedAddresses < 2) {
        $('#addressList p').css({ "color": "red" });
    }
}

function increaseAddressCount() {

    addedAddresses++;

    var errorCount = $('.errorCount').html();

    if (!isNaN(errorCount)) {
        $('.errorCount').html(parseInt(errorCount));
    }

    if (addedAddresses == 2) {
        $('#addressList p').css({ "color": "#ffffff" });
    }

    $('#addressCount').html(addedAddresses);
}

function decreaseAddresscount() {
    addedAddresses--;

    $('#addressCount').html(addedAddresses);
}

function removeAddressLine(e) {

    var id = $(this).closest(".addressLine").data('id');

    e.preventDefault();
    var elementlist = $("#list");
    var clickedLi = $(this).closest('.addressLine');
    var index = $(".fa-times").index(this);

    decreaseAddresscount();

    $(this).closest('.addressLine').remove();
    $(".answerWrapper:eq(" + index + ")").remove();

    for (var i = 0; i < addresses.length; i++) {
        if (addresses[i].id === id) {
            addresses.splice(i, 1);
        }
    }

    $('#answers').empty();

    for (var q = 0; q < addresses.length; q++) {
        createHiddenAddressAnswers(addresses[q]);
    }

    updateAddressFormData();
}

function updateAddressFormData() {
    $('#answers').empty();

    for (var q = 0; q < addresses.length; q++) {
        createHiddenAddressAnswers(addresses[q]);
    }

    formatAddressInputs();
}

function oddEven() {
    $('.slide').each(function () {
        var thisIndex = $(this).index();

        if (thisIndex % 2 == 0) {
            $(this).addClass('odd');
        }
        else {
            $(this).addClass('even');
        }
    });
}

function showSpinner() {
    var wW = $(document).width();
    var wH = $(window).height();
    var dH = $(document).height();
    var sT = $(window).scrollTop();

    $('#spinner').css({ 'width': wW + 'px', 'height': dH + 'px' }).fadeIn();
    $('#spinner .working').css({ 'margin-top': sT + 200 + 'px' });
}

function hideSpinner() {
    $('#spinner').fadeOut();
}

function toggleCbox() {
    if ($(this).is('.cbox')) {
        // toggle checkbox graphic
        $(this).toggleClass('active');

        var cbox = $(this).parent().find('input');

        // set hidden checkbox value to true
        if ($(cbox).val() == 'true') {
            if ($(cbox).hasClass("required")) {
                $(this).parent().find('p.heading.bigCheckbox').css('color', "red");
                $(cbox).val(null);
            } else {
                $(cbox).val(false);
            }
        }
        else {
            $(cbox).val('true');
            $(this).parent().find('p.heading.bigCheckbox').css('color', "white");
        }
    }

    // validate hidden input element
    if ($(this).parent().find('input[type="hidden"]').hasClass('required')) {
        var valTarget = $(this).parent().find('input[type="hidden"]').attr('name');
        $(this).closest('form').validate().element('input[name="' + valTarget + '"]');
    }
}

function toggleRbox() {
    if ($(this).is('.rbox')) {
        // reset all the radio boxes in the group
        $(this).closest('.field').find('.rbox').each(function () {
            $(this).removeClass('active');
        });

        // toggle current radio box graphic
        $(this).toggleClass('active');

        var thisVal = $(this).attr('id');

        $(this).closest('.field').find('input').val(thisVal);

        console.log(thisVal)
    }

    // validate hidden input element
    var valTarget = $(this).closest('.radio-group').find('input[type="hidden"]');
    $(this).closest('form').validate().element(valTarget);

    checkForHiddenElement($(this));
}

function setBootstrapDropdownSelection(e) {
    e.preventDefault();

    // text of dropdown
    var thisText = $(this).text();

    // hold current value of selection available globally
    thisCurVal = thisText;

    $(this).closest('.dropdown').find('a.dropdown-toggle span:first-child').text(thisText);

    // for dropdowns within forms setting values to hidden fields
    if ($('form').length) {
        $(this).closest('.field').find('input[type="hidden"]').val(thisText);
    }

    // validate hidden input element
    var valTarget = $(this).closest('.field').find('input[type="hidden"]');
    $(this).closest('form').validate().element(valTarget);
}

function checkForHiddenElement(el) {

    var _this = $(el);

    if (_this.hasClass('hasHidden')) {

        var child;

        try {
            child = _this.data("child").split(",");
        } catch (e) {
            //console.log('no child')
        }

        _this.closest('.question-group').find(".hiddener").each(function (el) {
            $(this).hide().find('input, textarea, select').removeClass('required');
        });

        if (child) {

            _this.closest('.question-group').find('.hiddener').each(function (el) {
                $(el).hide().find('input, textarea, select').removeClass('required');
            });

            $.each(child, function (index, value) {
                var v = "." + value.trim();

                _this.closest('.question-group').find(v).show().find('input, textarea, select').addClass('required');
            });

        } else {
            _this.closest('.question-group').find('.hiddener').each(function () {
                $(this).hide().find('input, textarea, select').removeClass('required');
            });

            _this.closest('.question-group').find('.hiddener').show().find('input, textarea, select').addClass('required');
        }

    } else if (!_this.hasClass('noHide')) {
        _this.closest('.question-group').find('.hiddener').hide().find('input, textarea, select').removeClass('required').val("");
    }

}

function addReviewValue() {
    alert('click');
}

function swapPlaceholder() {
    // on blur, if value is blank, re-enter the placeholder text
    if ($(this).val() == "") {
        $(this).val($(this).attr('id'));
    }
}

function clearPlaceholder() {
    if ($(this).val() == $(this).attr('id')) {
        $(this).val("");
    }
}

function onSuccess(response) {
    //alert('success')
}

function onFailure(response) {
    //alert('Failure')
}

function isNumber(evt) {
    evt = (evt) ? evt : window.event;
    var charCode = (evt.which) ? evt.which : evt.keyCode;
    if (charCode > 31 && (charCode < 48 || charCode > 57)) {
        return false;
    }
    return true;
}