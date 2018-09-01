(function () {
    'use strict';
    
    $(function(){

        // Variables
        var $win = $(window),
            $page = $('.page'),
            $pageHeader = $('.page-header');

        /*fixed controls*/
        $win.scroll(function () {

            if ($(this).scrollTop() > 300) {
                $pageHeader.addClass('fixed');
                $page.addClass('has-fixed-menu');
            } else {
                $pageHeader.removeClass('fixed');
                $page.removeClass('has-fixed-menu');
            }

            if ($(this).scrollTop() > 500) {
                $pageHeader.addClass('show');
            } else {
                $pageHeader.removeClass('show');
            }

        });

        /*main-menu*/
        var $menu = $('.js-main-menu'),
            $menuBtn = $('.js-main-menu-btn');
        $menuBtn.on('click', function () {
            var $this = $(this);
            $this.toggleClass('active');
            $menu.toggleClass('opened');
        });


        $('.js-faq').on('click', function (e) {
            e.preventDefault();
            accordion($(this), 'js-faq', 'js-faq-answer','parent', 0);
        });


    });
  
})();


function accordion(elem, elemClass, contentClass, location, isAccordion) {

    var $this = elem;
    var $titleAll = $('.'+elemClass).not($this);
    var $content = (location === 'parent')?$this.find('.'+contentClass):$this.siblings('.'+contentClass);
    var $contentAll = $('.'+contentClass).not($content);

    if($this.hasClass('opened')) {
        $content.slideUp(300, function () {
            $this.removeClass('opened');
        });
    }else{
        if(isAccordion === 1){
            $contentAll.slideUp(300);
            $content.slideDown(300, function () {
                $titleAll.removeClass('opened');
                $this.addClass('opened');
            });
            return;
        }
        $content.slideDown(300, function () {
            $this.addClass('opened');
        });
    }
}

