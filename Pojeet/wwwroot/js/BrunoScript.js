$(document).ready(function () {
    $("#profile2").addClass("active").siblings().removeClass("active");
    $("#profile2").addClass("show").siblings().removeClass("show");
    $("#profile2-tab").addClass("active").parent().siblings().children().removeClass("active");
    });