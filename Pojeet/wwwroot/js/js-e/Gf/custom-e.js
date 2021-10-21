  "use strict";

  $(document).ready(function () {

    $('.panel-heading').click(function () {
      $(this).toggleClass('in').next().slideToggle();
      $('.panel-heading').not(this).removeClass('in').next().slideUp();
        });

    });


    // Modal fenetre utilisateur
    $(document).ready(function($) {
      $('.popup-open').click(function() {
        $('.popup-fade').fadeIn();
        return false;
      });	
      
      $('.popup-close').click(function() {
        $(this).parents('.popup-fade').fadeOut();
        return false;
      });		
    
      $(document).keydown(function(e) {
        if (e.keyCode === 27) {
          e.stopPropagation();
          $('.popup-fade').fadeOut();
        }
      });
      
      $('.popup-fade').click(function(e) {
        if ($(e.target).closest('.popup').length == 0) {
          $(this).fadeOut();					
        }
      });	
    });


    // Modal fenetre commandes
    $(document).ready(function($) {
      $('.popup-open_commande').click(function() {
        $('.popup-fade_commande').fadeIn();
        return false;
      });	
      
      $('.popup-close_commande').click(function() {
        $(this).parents('.popup-fade_commande').fadeOut();
        return false;
      });		
    
      $(document).keydown(function(e) {
        if (e.keyCode === 27) {
          e.stopPropagation();
          $('.popup-fade_commande').fadeOut();
        }
      });
      
      $('.popup-fade_commande').click(function(e) {
        if ($(e.target).closest('.popup_commande').length == 0) {
          $(this).fadeOut();					
        }
      });	
    });

    //recherche page Comandes(table modal fenetre)
    $(document).ready(function(){
      $("#myInput_helper").on("keyup", function() {
        var value = $(this).val().toLowerCase();
        $("#commande_helper tr").filter(function() {
          $(this).toggle($(this).text().toLowerCase().indexOf(value) > -1)
        });
      });
    });

    //filtr table

  //   document.addEventListener('DOMContentLoaded', () => {

  //     const getSort = ({ target }) => {
  //         const order = (target.dataset.order = -(target.dataset.order || -1));
  //         const index = [...target.parentNode.cells].indexOf(target);
  //         const collator = new Intl.Collator(['fr'], { numeric: true });
  //         const comparator = (index, order) => (a, b) => order * collator.compare(
  //             a.children[index].innerHTML,
  //             b.children[index].innerHTML
  //         );
          
  //         for(const tBody of target.closest('table').tBodies)
  //             tBody.append(...[...tBody.rows].sort(comparator(index, order)));
  
  //         for(const cell of target.parentNode.cells)
  //             cell.classList.toggle('sorted', cell === target);
  //     };
      
  //     document.querySelectorAll('.table_sort thead').forEach(tableTH => tableTH.addEventListener('click', () => getSort(event)));
      
  // });