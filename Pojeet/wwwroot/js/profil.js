$(document).ready(function () {

    console.log("ready to start PROFIL!");


    var coll = document.getElementsByClassName("collapsible");
    var i;

    for (i = 0; i < coll.length; i++) {
        coll[i].addEventListener("click", function () {
            this.classList.toggle("activeToogle");
            var content = this.nextElementSibling;
            if (content.style.display === "block") {
                content.style.display = "none";
            } else {
                content.style.display = "block";
            }
        });
    }


    $(window).scroll(function () {
        var $heightScrolled = $(window).scrollTop();
        var $defaultHeight = 100;

        if ($heightScrolled < $defaultHeight) {
            $('#navbar').removeClass("navbar-color")
            $('#navbar').addClass("navbar-transparent")
        }
        else {
            $('#navbar').addClass("navbar-color")
        }

    });



    window.addEventListener('load', function () {
        initSlider(
            'slider', //id
            ['changer votre batterie ?', 'faire votre vidange ?', 'louer une visseuse ?'],
            100, //duration
            1000 //delay
        );
    });

    //just copy and paste below
    var createText = function (text, id, duration) {
        document.getElementById(id).innerHTML = '';
        for (let i = 0; i < text.length; i++) {
            setTimeout(() => {
                let newText = text.substr(0, (i + 1));
                document.getElementById(id).innerHTML = newText;
            }, duration * i);
        }
    }
    var clearText = function (id, duration) {
        let text = document.getElementById(id).innerHTML;
        for (let i = text.length; i > 0; i--) {
            setTimeout(() => {
                let newText = text.substr(0, text.length - i);
                document.getElementById(id).innerHTML = newText;
            }, duration * i);
        }
    }
    var initSlider = function (id, texts, duration, delay) {
        let durs = [];
        for (let i = 0; i < texts.length - 1; i++) {
            let beforeDur;
            if (i == 0) {
                beforeDur = 0;
            }
            else {
                beforeDur = durs[i - 1];
            }
            durs.push((texts[i].length * duration * 2) + (2 * delay) + beforeDur);
        }

        let allTime = 0;
        for (let i = 0; i < texts.length; i++) {
            allTime += (texts[i].length * duration * 2) + (2 * delay);
        }
        let mainSlider = function () {
            for (let i = 0; i < texts.length; i++) {
                setTimeout(() => {
                    createText(texts[i], id, duration);
                    setTimeout(() => {
                        clearText(id, duration);
                    }, texts[i].length * duration + delay);
                }, i === 0 ? 0 : durs[i - 1]);
            }
        }
        mainSlider();
        setInterval(() => {
            mainSlider();
        }, allTime);
    }




});