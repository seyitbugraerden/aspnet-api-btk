/**
*
* -----------------------------------------------------------------------------
*
* Template : Neoton - Blog News & Magazine HTML Template
* Author : backtheme
* Author URI : https://backtheme.com/ 

* -----------------------------------------------------------------------------
*
**/

(function($) {
    "use strict";

    // pisticky Menu
    var header = $('.back-header');
    var win = $(window);
    win.on('scroll', function() {
        var scroll = win.scrollTop();
        if (scroll < 100) {
           header.removeClass("back-sticky");
        } else {
           header.addClass("back-sticky");
        }
    });

    //Menu Code Here
    $("#backmenu").backResponsiveMenu({
        resizeWidth: '991', 
        animationSpeed: 'medium', 
        accoridonExpAll: false 
    });

    //Menu Active Here
    var path = window.location.href; 
    $('.back-menus li a').each(function() {
        if (this.href === path) {
            $(this).addClass('back-current-page');
        }
    });

    // Elements Animation
    if ($('.wow').length) {
        var wow = new WOW(
            {
                boxClass: 'wow', // animated element css class (default is wow)
                animateClass: 'animated', // animation css class (default is animated)
                offset: 0, // distance to the element when triggering the animation (default is 0)
                mobile: false, // trigger animations on mobile devices (default is true)
                live: true       // act on asynchronously loaded content (default is true)
            }
        );
        wow.init();
    }

    //Taggle Js
    $('#menu-btn').on('click', function(e) {
        $(this).toggleClass("back__close");
        e.preventDefault();
    });

    // Hero Slider Part
    if ($('.back-hero-slider').length) {
        $('.back-hero-slider').owlCarousel({
            loop:true,
            items:1,
            margin:0,
            autoplay:true,
            slideSpeed : 10000,
            cssEase: 'linear',
            nav:false,
            dots:false,

        })
    }

    // Hero Slider 2 Part
    if ($('.back-hero-slider2').length) {
        $('.back-hero-slider2').owlCarousel({
            loop:true,
            items:3,
            margin:0,
            autoplay:true,
            slideSpeed : 12000,
            cssEase: 'linear',
            nav:true,
            dots:false,
            responsive : {
                0 : {
                    items:1,
                },
                480 : {
                    items:1,
                },
                768 : {
                    items:2,
                },
                992 : {
                    items:2,
                },
                1024 : {
                    items:2,
                },
                1200 : {
                    items:3,
                }
            }
        })
    }

    // Hero Slider 3 Part
    if ($('.back-hero-slider3').length) {
        $('.back-hero-slider3').owlCarousel({
            loop:true,
            items:4,
            margin:0,
            autoplay:true,
            slideSpeed : 12000,
            cssEase: 'linear',
            nav:false,
            dots:false,
            responsive : {
                0 : {
                    items:1,
                },
                480 : {
                    items:1,
                },
                768 : {
                    items:2,
                },
                992 : {
                    items:2,
                },
                1024 : {
                    items:3,
                },
                1200 : {
                    items:4,
                }
            }
        })
    }

    if ($('.back-trending-slider').length) {
        $('.back-trending-slider').owlCarousel({
            loop:true,
            items:4,
            margin:0,
            autoplay:true,
            slideSpeed : 800,
            nav:true,
            dots:false,
            responsive : {
                0 : {
                    items:1,
                    nav:false,
                },
                480 : {
                    items:1,
                    nav:false,
                },
                768 : {
                    items:2,
                    nav:false,
                },
                992 : {
                    items:3,
                },
                1024 : {
                    items:3,
                },
                1200 : {
                    items:4,
                }
            }
        })
    }
    
    if ($('.back-weekend-slider').length) {
        $('.back-weekend-slider').owlCarousel({
            loop:true,
            items:4,
            margin:0,
            autoplay:true,
            slideSpeed : 800,
            nav:true,
            dots:false,
            responsive : {
                0 : {
                    items:1,
                    nav:false,
                },
                480 : {
                    items:1,
                    nav:false,
                },
                768 : {
                    items:2,
                    nav:false,
                },
                992 : {
                    items:3,
                },
                1024 : {
                    items:3,
                },
                1200 : {
                    items:4,
                }
            }
        })
    }

    if ($('.back-topbar-slider').length) {
        $('.back-topbar-slider').owlCarousel({
            loop:true,
            items:1,
            margin:0,
            autoplay:true,
            slideSpeed : 300,
            nav:false,
            dots:false,
            singleItem: true,
            animateIn: 'fadeIn',
            animateOut: 'fadeOut',
        })
    }

    // Team Slider Part
    if ($('.team-slider').length) {
        $('.team-slider').owlCarousel({
            loop:true,
            items:4,
            margin:30,
            autoplay:false,
            slideSpeed : 300,
            nav:false,
            dots:false,
            responsive : {
                0 : {
                    items:1,
                },
                480 : {
                    items:1,
                },
                768 : {
                    items:2,
                },
                992 : {
                    items:3,
                },
                1024 : {
                    items:3,
                },
                1200 : {
                    items:4,
                }
            }
        })
    }

    // Client Slider Part
    if ($('#back-blog-slider').length) {
        $('#back-blog-slider').owlCarousel({
            loop:true,
            items:3,
            margin:20,
            autoplay:false,
            slideSpeed : 300,
            nav:false,
            dots:false,
            center: false,
            responsive:{
                0:{
                    items:1,
                    center: false,
                },
                575:{
                    items:1,
                    center: false,
                },
                767:{
                    items:2,
                    center: false,
                },
                1200:{
                    items:3,
                },
            }
        })
    }


    $('.back-dark-light').on('click', function(e) {
        $('body').toggleClass('back_dark__mode');
        e.stopPropagation();
    });

    // Footer Top Slider Part
    if ($('.back-footer-top-slider').length) {
        $('.back-footer-top-slider').owlCarousel({
            loop:true,
            items:4,
            margin:0,
            autoplay:true,
            slideSpeed : 8000,
            cssEase: 'linear',
            nav:false,
            dots:false,
            responsive : {
                0 : {
                    items:1,
                },
                480 : {
                    items:1,
                },
                768 : {
                    items:2,
                },
                992 : {
                    items:2,
                },
                1024 : {
                    items:3,
                },
                1200 : {
                    items:4,
                }
            }

        })
    }

    //canvas menu
    var navexpander = $('#nav-expander');
    if(navexpander.length){
        $('#nav-expander, #nav-close, .back-offcanvas').on('click',function(e){
            e.preventDefault();
            $('body').toggleClass('nav-expanded');
        });
    }

    //search 
    $('.back_search').on('click', function(event) {        
        $('.search-form').slideToggle('show');
        $( '.search-form input' ).focus();
    });


    //Videos popup jQuery 
    var popup = $('.popup-videos');
    if(popup.length) {
        $('.popup-videos').magnificPopup({
            disableOn: 10,
            type: 'iframe',
            mainClass: 'mfp-fade',
            removalDelay: 160,
            preloader: false,
            fixedContentPos: false
        }); 
    }

    

    //Dark & Light jQuery
    var back_go_dark = $('.back-go-dark');
    if(back_go_dark.length) {
        let backtheme = localStorage.getItem('backtheme');
        const godarkback   = document.querySelector('.back-go-dark')
        const golightback  = document.querySelector('.back-go-light')
        const godarkback1   = document.querySelector('.back-go-dark1')
        const golightback1  = document.querySelector('.back-go-light1')

        const darkTheme = function() {
            document.documentElement.classList.add('back-dark');
            localStorage.setItem('backtheme', 'back-dark');
        }
        const lightTheme = function() {
            document.documentElement.classList.remove('back-dark');
            localStorage.setItem('backtheme', 'light');
        }
        document.addEventListener('DOMContentLoaded', function() {
            localStorage.getItem('backtheme');    
            if (localStorage.backtheme === 'back-dark') {
                darkTheme();
            } else if (localStorage.backtheme === 'light') {
                lightTheme();
            }
        });
        godarkback.addEventListener('click', function() {
            darkTheme();
        });
        golightback.addEventListener('click', function() {
            lightTheme();
        });
        godarkback1.addEventListener('click', function() {
            darkTheme();
        });
        golightback1.addEventListener('click', function() {
            lightTheme();
        });
    }

    
    // Sticky Sidebar
    var contentsticky = $('.back-content-sticky');
    if(contentsticky.length) {
        $('.back-content-sticky, .back-sidebar-sticky').theiaStickySidebar({
            additionalMarginTop: 140,
            additionalMarginBottom: 20,
        });
    }


    //preloader
    $(window).on( 'load', function() {
        $("#back__preloader").delay(1000).fadeOut(400);
        $("#back__preloader").delay(1000).fadeOut(400);
    })

    // scrollTop init
    var pitotop = $('#backscrollUp'); 
    if(pitotop.length){   
        win.on('scroll', function() {
            if (win.scrollTop() > 350) {
                pitotop.fadeIn();
            } else {
                pitotop.fadeOut();
            }
        });
        pitotop.on('click', function() {
            $("html,body").animate({
                scrollTop: 0
            }, 500)
        });
    }
    var lastScrollTop = 0;
    $(window).scroll(function(event){
       var st = $(this).scrollTop();
       if (st > lastScrollTop){
           $( "#backscrollUp" ).removeClass( "back__up___scroll" );
       } else {
          $( "#backscrollUp" ).addClass( "back__up___scroll" );
       }
       lastScrollTop = st;
    });

})(jQuery);