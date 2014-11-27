
$(document).ready(function () {
    $('#login-trigger').mouseover(function () {
        $('#signup-content').hide();
        $(this).next('#login-content').slideDown(500);

        if ($(this).is(':visible')) {
            $('#signup-trigger').find('span').html('&#x25BC;');
            $(this).find('span').html('&#x25B2;');
        }
    })
});

$(document).ready(function () {
    $('#signup-trigger').mouseover(function () {
        $('#login-content').hide();
        $(this).next('#signup-content').slideDown(500);

        if ($(this).is(':visible')) {
            $('#login-trigger').find('span').html('&#x25BC;');
            $(this).find('span').html('&#x25B2;');
        }
    })
});

$(document).ready(function () {
    $('#login-form-vanish').mouseover(function () {
        //if (($('#signup-content').data('clicked') || $('#login-content').data('clicked'))) {
        //    alert("yes");
            $('#signup-content').hide();
            $('#login-content').hide();
            $('#signup-trigger').find('span').html('&#x25BC;');
            $('#login-trigger').find('span').html('&#x25BC;');
            $(this).next('#login-content').slideDown(500);
        
    })
});
