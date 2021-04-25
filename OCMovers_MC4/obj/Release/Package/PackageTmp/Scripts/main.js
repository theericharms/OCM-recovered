var toValidate; // variable holding form validator
var customerConfirmation = false;
//var addedAddresses = 0;

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
    "0", "0 - 10",
    "10 - 20",
    "20 - 30",
    "30 - 40",
    "40 - 50",
    "50 - 75",
    "75 - 100",
    "100+"
];

var locationTypes = ["Starting Location", "Ending Location", "Storage Unit", "Office"];

$(document).ready(function () {

    /* Form Elements
    ==========================================================*/
    $('html').on('click', '.rbox', toggleRbox);
    $('html').on('click', '.cbox', toggleCbox);
    $('html').on('click', '.dropdown-menu a', setBootstrapDropdownSelection);
    $('html').on('click', '#gotoAddLocation', scrollToDescriptionBox);

    $('html').on('click', '.modal-footer button.submit', submitEstimateForm);
    //$('html').on('click', 'button.submit', cancelEstimateForm);

    //$('html').on('click', '#addAddress', addAddress);
    //   $('html').on('click', '#cancelAddAddress', cancelAddAddress);
    // $('html').on('click', '#addTheAddress', addTheAddress);
    //$('html').on('click', '#removeAddressLine', removeAddressLine);
    //
    // $('html').on('click', "input[type='submit']", validateNumberOfAddresses);


    $("#to").datepicker({
        minDate: new Date(),
        numberOfMonths: 1,
        showButtonPanel: true,
        onClose: function (selectedDate) { }
    });


    $(".datepicker").datepicker({
        numberOfMonths: 1,
        showButtonPanel: true,
        onClose: function (selectedDate) { }
    });;

    $('.dropdown-toggle').dropdown();

    $('.estimate-nav-item').tooltip();

    $('form[name="estimateForm"] input[type="submit"]').on('click', function (e) {
        e.preventDefault();
        var form = $("form");

        if (form.valid()) {
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

            //if (addedAddresses < 2) {
            //errors++;
            ////}

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
    e.preventDefault();
    $('html, body').animate({
        scrollTop: $("#addLocation").offset().top - 130
    }, 300);
}

//function addAddress(e) {
//    e.preventDefault();

//    $.ajax({
//        url: "/Estimate/GetAddressForm",
//        method: "GET",
//        success: function (result) {

//            $('#address').html(result);

//            $('select.state').select2({
//                data: states,
//                maximumSelectionLength: 2
//            });

//            $('select.addressType').select2({
//                data: locationTypes,
//                maximumSelectionLength: 2,
//                dropdownAutoWidth: true
//            });
//        }
//    });

//    $('select.addAddress').select2({
//        data: ["Starting Location", "Ending Location", "Storage Unit", "Office"],
//        maximumSelectionLength: 2,
//        dropdownAutoWidth: true,
//        width: 'auto',
//        placeholder: 'Select location type'
//    });
//}

//function cancelAddAddress(e) {
//    if (e) {
//        e.preventDefault();
//    }

//    $('#address').empty();

//}

//function addTheAddress(e) {
//    e.preventDefault();

//    var $inputs = $('#address :input');

//    var values = {};
//    $inputs.each(function () {
//        values[this.name] = $(this).val();
//    });

//    var addressValid = false;

//    //if (values.addressType && values.Address1 && values.City && values.loc1State && values.Postcode) {
//        //console.log(values)

//        // values
//        //Address1:"155 summit drive"
//        //AptNum:"4444"
//        //BuildingName:"asdf"
//        //City:"corte madera"
//        //Postcode:"94924"
//        //addressType:"Starting Location"
//        //loc1State:"California"

//        //var newAddress = "<li class=\"addressLine\"><div class=\"icons\"><i class=\"fa fa-bars\"></i><i class=\"fa fa-trash\" id=\"removeAddressLine\"></i></div><div class=\"address\">" + values.addressType + ", ";

//        //if (values.BuildingName.length) {
//        //    newAddress += values.BuildingName + ", ";
//        //}

//        //newAddress += values.Address1 + ' ';

//        //if (values.AptNum.length) {
//        //    newAddress += values.AptNum + "# ";
//        //}

//        //newAddress += values.City + ', ' + values.loc1State + ', ' + values.Postcode;

//        //newAddress += "</div></div>";

//        //$('#list li.note').hide();
//        //$('#addressList #list').append(newAddress);

//        //$('#address').empty();

//        //$("ul#list").sortable({
//        //    axis: "y",
//        //    items: "> li",
//        //    stop: orderAddresses
//        //});

//        //increaseAddressCount();

//        //createHiddenAddressAnswers(values);

//    } else {

//        $inputs.each(function() {
//            console.log($(this))
//            if ($(this).hasClass('required')) {

//                if ($(this).val().length == 0)
//                {
//                    if ($(this).hasClass('type-select2'))
//                    {
//                        $(this).closest('.field').find('.select2-selection').addClass('error');

//                    } else {
//                        $(this).addClass("error");
//                    }
//                }
//            }
//        });
//    }
//}

//function createHiddenAddressAnswers(values) {

//    var answerWrapper = "<div class='answerWrapper'>";
//    var addressType = "<input type=\"hidden\" value=\"" + values.addressType + "\" name='AddressType' id='AddressType'>";
//    var buildingName = "<input type=\"hidden\" value=\"" + values.BuildingName + "\" name='BuildingName' id='BuildingName'>";
//    var address1 = "<input type=\"hidden\" value=\"" + values.Address1 + "\" name='Address1' id='Address1'>";
//    var aptNum = "<input type=\"hidden\" value=\"" + values.AptNum + "\" name='AptNum' id='AptNum'>";
//    var city = "<input type=\"hidden\" value=\"" + values.City + "\" name='City' id='City'>";
//    var state = "<input type=\"hidden\" value=\"" + values.loc1State + "\" name='State' id='State'>";
//    var postcode = "<input type=\"hidden\" value=\"" + values.Postcode + "\" name='Postcode' id='Postcode'>";

//    answerWrapper += addressType;
//    answerWrapper += buildingName;
//    answerWrapper += address1;
//    answerWrapper += aptNum;
//    answerWrapper += city;
//    answerWrapper += state;
//    answerWrapper += postcode;
//    answerWrapper += "</div>";

//    $('#answers').append(answerWrapper);

//    orderAddresses();
//}

//function orderAddresses() {


//    var x = 0;

//    $(".answerWrapper").each(function () {
//        $(this).find('input').each(function () {

//            var idName = $(this).attr('id').split("].");
//            var id;

//            if (idName.length > 1) {
//                id = idName[1];
//            } else {
//                id = idName;
//            }

//            $(this).attr('id', "[" + x + "]." + id).attr('name', "[" + x + "]." + id);

//            console.log($(this).val());
//        });

//        x++;
//    });
//}

//function validateNumberOfAddresses() {
//    cancelAddAddress();

//    if (addedAddresses < 2) {
//        $('#addressList p').css({"color":"red"});
//    }
//}

//function increaseAddressCount() {

//    addedAddresses++;

//    var errorCount = $('.errorCount').html();

//    if (!isNaN(errorCount)) {
//        $('.errorCount').html(parseInt(errorCount));
//    }

//    if (addedAddresses == 2) {
//        $('#addressList p').css({ "color": "#ffffff" });
//    }

//    $('#addressCount').html(addedAddresses);
//}

//function decreaseAddresscount() {
//    addedAddresses--;

//    $('#addressCount').html(addedAddresses);
//}

//function removeAddressLine(e) {
//    e.preventDefault();
//    decreaseAddresscount()
//    $(this).closest('.addressLine').remove();
//}

function oddEven() {
    $('.slide').each(function () {
        var thisIndex = $(this).index();

        if (thisIndex % 2 == 0) {
            $(this).addClass('odd');
        } else {
            $(this).addClass('even');
        }
    });
}

function showSpinner() {

    var wW = $(document).width();
    var wH = $(window).height();
    var dH = $(document).height();
    var sT = $(window).scrollTop();

    $('#spinner').css({
        'width': wW + 'px',
        'height': dH + 'px'
    }).fadeIn();
    $('#spinner .working').css({
        'margin-top': sT + 200 + 'px'
    });
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
        } else {
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
    console.log("toggleRbox")
    if ($(this).is('.rbox')) {
        console.log("toggleRbox aaa")
        // reset all the radio boxes in the group
        $(this).closest('.field').find('.rbox').each(function () {
            $(this).removeClass('active');
        });

        console.log("toggleRbox bbb")

        // toggle current radio box graphic
        $(this).toggleClass('active');
        console.log("toggleRbox ccc")
        var thisVal = $(this).attr('id');

        $(this).closest('.field').find('input').val(thisVal);
        console.log("toggleRbox ddd")
    }

    // validate hidden input element
    var valTarget = $(this).closest('.radio-group').find('input[type="hidden"]');
    console.log(valTarget)
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
    var thisId = $(el).attr('id');
    var thisLabel = $(el).closest('.radio-group')

    console.log(el.closest('.slide').find('.typeSelect').val());

    if (thisId == 'Apartment') {

        resetOptions(el)

        el.closest('.slide').find('.question.hiddener').show().find('input, textarea').addClass('required');

    } else if (thisId == 'House') {

        resetOptions(el)

        el.closest('.slide').find('.question.hiddener2').show().find('input, textarea, select').addClass('required');

        var id = el.closest('.slide').find('.question.hiddener2').find('.select2').attr('id');
        $("#" + id).val(null).trigger("change");


    } else if (thisId == 'Stairs' || thisId == 'Elevator' && el.closest('.slide').find('.typeSelect').val() != "Storage") {

        el.closest('.slide').find('.question.hiddener3').show().find('input, textarea').addClass('required');
        el.closest('.question').nextAll('.question.hiddener').hide().find('input, textarea').removeClass('required');

        // set select2 to null
        var id = el.closest('.slide').find('.question.hiddener3').find('.select2').attr('id')

        $("#" + id).val(null).trigger("change");

    } else if (thisId == 'Ground Floor') {
        el.closest('.slide').find('.question.hiddener3').hide().find('input, textarea, select').removeClass('required');
    }
    else if (thisId == "Storage") {

        resetOptions(el)
        el.closest('.slide').find('.question.hiddener4').show().find('input, textarea, select').addClass('required');
    }
    else if (thisId == "Indoor") {
        el.closest('.slide').find('.question.hiddener5').show().find('input, textarea, select').addClass('required');
    }
    else if (thisId == "Drive-up") {
        el.closest('.slide').find('.question.hiddener5').hide().find('input, textarea, select').removeClass('required');
    }
    else if (thisId == "Other") {
        resetOptions(el)
        el.closest('.slide').find('.question.hiddener6').show().find('input, textarea, select').addClass('required');
    }
}

function resetOptions(el) {
    el.closest('.question').nextAll('.question.hiddener').hide().find('input, textarea, select').removeClass('required');
    clearValues(el,'.question.hiddener')

    el.closest('.question').nextAll('.question.hiddener1').hide().find('input, textarea, select').removeClass('required');
    clearValues(el,'.question.hiddener1')

    el.closest('.question').nextAll('.question.hiddener2').hide().find('input, textarea, select').removeClass('required');
    clearValues(el,'.question.hiddener2')

    el.closest('.question').nextAll('.question.hiddener3').hide().find('input, textarea, select').removeClass('required');
    clearValues(el,'.question.hiddener3')

    el.closest('.question').nextAll('.question.hiddener4').hide().find('input, textarea, select').removeClass('required');
    clearValues(el,'.question.hiddener4')

    el.closest('.question').nextAll('.question.hiddener5').hide().find('input, textarea, select').removeClass('required');
    clearValues(el,'.question.hiddener5')

    el.closest('.question').nextAll('.question.hiddener6').hide().find('input, textarea, select').removeClass('required');
    clearValues(el,'.question.hiddener6')

}

function clearValues(el, hiddenElement)
{
    el.closest('.question').nextAll(hiddenElement).find('.field').each(function () {
        $(this).find('.dropdown-toggle span').text('Select');
        $(this).find('input[type="hidden"]').val("");
        $(this).find('.radio-group input').val("");
        $(this).find('textarea').val("");
        $(this).find('.rbox').removeClass('active');
    })
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