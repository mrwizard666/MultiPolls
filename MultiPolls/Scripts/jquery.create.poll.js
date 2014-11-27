
$(document).ready(function () {
    var x = 2;
    var y = 3;
 
    $("[id^=option]").keyup(function () {
        if ("option" + x === this.id && x !== 10) {
            $("#Option" + y).show();
            x++;
            y++;
            if (y === 11) {$('#add-option').hide()
            };
        };
    });
});

