  "use strict";

  function Clk() {
    var div = document.getElementsByClassName('comment_post_list')[0];

    if (!div.style.display || div.style.display === 'block') div.style.display = 'none';
    else div.style.display = 'block';
  }

//////////************* Carousel image l'annonce*************/////////////



var slideIndex = 1;
showSlides(slideIndex);

function plusSlides(n) {
  showSlides(slideIndex += n);
}

function currentSlide(n) {
  showSlides(slideIndex = n);
}

function showSlides(n) {
  var i;
  var slides = document.getElementsByClassName("slide");
  var dots = document.getElementsByClassName("dot");
  if (n > slides.length) {slideIndex = 1}    
  if (n < 1) {slideIndex = slides.length}
  for (i = 0; i < slides.length; i++) {
      slides[i].style.display = "none";  
  }
  for (i = 0; i < dots.length; i++) {
      dots[i].className = dots[i].className.replace(" active", "");
  }
  slides[slideIndex-1].style.display = "block";  
  dots[slideIndex-1].className += " active";
}

     //////////************* END Carousel image l'annonce*************/////////////


     $(document).ready(function(){
       $("address").each(function(){
         var embed ="<iframe width='100%' height='350' frameborder='0' scrolling='no'  marginheight='0' marginwidth='0'   src='https://maps.google.com/maps?&amp;q="+ encodeURIComponent( $(this).text() ) +"&amp;output=embed'></iframe>";
                                     $(this).html(embed);

        });
     });
