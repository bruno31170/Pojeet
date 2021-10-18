$(document).ready(function () {

    console.log("ready to start!");

    $('.form .stages label').click(function () {
        var radioButtons = $('.form input:radio');
        var selectedIndex = radioButtons.index(radioButtons.filter(':checked'));
        selectedIndex = selectedIndex + 1;
    });

    $('.form button').click(function () {
        var radioButtons = $('.form input:radio');
        var selectedIndex = radioButtons.index(radioButtons.filter(':checked'));

        selectedIndex = selectedIndex + 2;

        $('.form input[type="radio"]:nth-of-type(' + selectedIndex + ')').prop('checked', true);

        if (selectedIndex == 4) {
            $('button').html('Soumettre');
        }

        if (selectedIndex == 5) {
            $('button').html('Retour accueil');
                document.getElementById("my_button").onclick = function () {
                     location.href = "index.html";
                 };
        }
    });




    
});
