function isValidForm() {
    if (GenderNotNull() && SkillsNotNull() && isvalidUrl()) {
        if (confirm('Do you want to submit the form?')) {
            addEntry();
            newFunction();
            return true;
        }
    }
}

function GenderNotNull() {
    var maleSelected = document.getElementById("Male").checked;
    var femaleSelected = document.getElementById("Female").checked;
    if (!maleSelected && !femaleSelected) {
        alert("Please select a gender to continue");
        return false;
    }
    return true;
}

function SkillsNotNull() {
    var javaChecked = document.getElementById("Java").checked;
    var htmlChecked = document.getElementById("HTML").checked;
    var cssChecked = document.getElementById("CSS").checked;
    if (!javaChecked && !htmlChecked && !cssChecked) {
        alert("Mention at least 1 skill");
        return false;
    }
    return true;
}

function isvalidUrl() {
    var site = document.getElementById('Website').value;
    if (site == "") return true;
    if (site.includes('https://')) { site = site.replace('https://', '') }
    site = 'https://' + site;
    var pattern = new RegExp('^(https?:\\/\\/)?' +
        '((([a-z\\d]([a-z\\d-]*[a-z\\d])*)\\.?)+[a-z]{2,}|' +
        '((\\d{1,3}\\.){3}\\d{1,3}))' +
        '(\\:\\d+)?(\\/[-a-z\\d%_.~+]*)*' +
        '(\\?[;&a-z\\d%_.~+=-]*)?' +
        '(\\#[-a-z\\d_]*)?$', 'i');
    if (pattern.test(site)) {
        return true;
    } else {
        alert("Please enter a valid url to continue");
        return false;
    }
}

function addEntry() {
    var name = document.getElementById('Name').value;
    var email = document.getElementById('Email').value;
    var site = document.getElementById('Website').value;
    var link = site;
    if (site != '' && !site.includes('https://')) {
        link = 'https://' + site;
    }
    var image = document.getElementById('ImageLink').value;
    var gender = document.forms["EnrollmentForm"]["Gender"].value;

    var java = document.getElementById("Java");
    var html = document.getElementById("HTML");
    var css = document.getElementById("CSS");

    var animation = "fade-in";

    var skills = " ";
    if (java.checked) {
        skills = skills + java.value + " ";
    }
    if (html.checked) {
        skills = skills + html.value + " ";
    }
    if (css.checked) {
        skills = skills + css.value + " ";
    }

    var table = document.getElementsByTagName('table')[0];

    var newRow = table.insertRow(table.rows.length);

    var infoCell = newRow.insertCell(0);
    var imageCell = newRow.insertCell(1);


    infoCell.innerHTML = "<div class=" + animation + "><ul><li>  <b>" + name + "</b></li><li>" + gender + "</li><li>" + email + "</li><li> <a href=" + link + " target=_blank>" + site + "</a></li><li>" + skills + " </li></ul>";
    imageCell.innerHTML = "<div class=" + animation + "><img src= " + image + " alt=User Image class = responsive>";

    $('#submitButton').on('click', function () {
        if ($('#UserTable').css('opacity') == 0) $('#UserTable').css('opacity', 1);
        else { $('#UserTable').css('opacity', 0); }
        $('#UserTable').css('opacity', 1).delay(5000);
    });
}

function newFunction() {
    $('form').get(0).reset();
}