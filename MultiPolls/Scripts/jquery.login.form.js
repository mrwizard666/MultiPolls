//$(document).ready(function () {
//    $('#login-trigger').mouseover(function () {
//    if ($('#signup-content').visible === true) {
//        $('#signup-content').hide();
        
//            $(this).next('#login-content').slideToggle();
//            $(this).toggleClass('active');
//        };
//        //if ($(this).hasClass('active')) $(this).find('span').html('&#x25B2;')
//        //else $(this).find('span').html('&#x25BC;')
//    });
//});

$(document).ready(function () {
    $('#login-trigger').mouseover(function () {
        $(this).next('#login-content').slideToggle();
        $(this).toggleClass('active');

        //if ($(this).hasClass('active')) $(this).find('span').html('&#x25B2;')
        //else $(this).find('span').html('&#x25BC;')
    })
});

$(document).ready(function () {
    $('#signup-trigger').mouseover(function () {
        $(this).next('#signup-content').slideToggle();
        $(this).toggleClass('active');

        //if ($(this).hasClass('active')) $(this).find('span').html('&#x25B2;')
        //else $(this).find('span').html('&#x25BC;')
    })
});