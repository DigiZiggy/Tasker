import {Aurelia} from 'aurelia-framework';
import {PLATFORM} from 'aurelia-pal';
import {log} from "./home";

export class Carousel {
  constructor() {
    log.debug('constructor');

  }


  attached() {
    log.debug('attached');
    // $('#feedPhotoCarousel').carousel({
    //   interval: 10000
    // });
    //
    // $('.carousel .carousel-item').each(function() {
    //   var next = $(this).next();
    //   if (!next.length) {
    //     next = $(this).siblings(':first');
    //   }
    //   next.children(':first-child').clone().appendTo($(this));
    //
    //   for (var i = 0; i < 4; i++) {
    //     next = next.next();
    //     if (!next.length) {
    //       next = $(this).siblings(':first');
    //     }
    //
    //     next.children(':first-child').clone().appendTo($(this));
    //   }
    // });
  }
}
