$(document).ready(function () {
    $('#view-trigger').mouseover(function () {
        $('#view-content').slideDown(500);
    })
});

$(document).ready(function () {
    $('#create-button').mouseover(function () {
        $('#view-content').hide();
    })
});

$(document).ready(function () {
    $('#view-public-button').mouseover(function () {
        $('#view-content').hide();
    })
});