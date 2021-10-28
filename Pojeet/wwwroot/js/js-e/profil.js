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



    if (!String.IsNullOrEmpty(Request.QueryString["error"])) {
        lblError.Text = "Whatever text you like.";
    }


});