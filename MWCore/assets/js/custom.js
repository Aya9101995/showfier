$(document).ready(function () {




	$('.zone-slider').slick({
		dots: false,
		infinite: true,
		arrows: false,
		speed: 500,
		autoplay: false,
		slidesToShow: 4,
		slidesToScroll: 4,
		dots: true,
		responsive: [
			{
				breakpoint: 1800,
				settings: {
					slidesToShow: 4,
				}
			},

			{
				breakpoint: 1550,
				settings: {
					slidesToShow: 4,
				}
			},

			{
				breakpoint: 1150,
				settings: {
					slidesToShow: 2,
					slidesToScroll: 2,
				}
			},
			{
				breakpoint: 1024,
				settings: {
					slidesToShow: 2,
					centerPadding: '150px',
				}
			},
			{
				breakpoint: 769,
				settings: {
					slidesToShow: 2,
					centerPadding: '50px',
				}
			},
			{
				breakpoint: 500,
				settings: {
					slidesToShow: 1,
					centerPadding: '50px',
				}
			}
			// You can unslick at a given breakpoint now by adding:
			// settings: "unslick"
			// instead of a settings object
		]


	});






	$('.related-web-slide').slick({

		infinite: true,
		arrows: true,
		speed: 500,
		autoplay: false,
		slidesToShow: 4,
		slidesToScroll: 1,
		dots: false,
		responsive: [
			{
				breakpoint: 1800,
				settings: {
					slidesToShow: 4,
				}
			},

			{
				breakpoint: 1550,
				settings: {
					slidesToShow: 4,
				}
			},

			{
				breakpoint: 1150,
				settings: {
					slidesToShow: 2,
					slidesToScroll: 2,
				}
			},
			{
				breakpoint: 1024,
				settings: {
					slidesToShow: 2,
					centerPadding: '150px',
				}
			},
			{
				breakpoint: 769,
				settings: {
					slidesToShow: 2,
					centerPadding: '50px',
				}
			},
			{
				breakpoint: 500,
				settings: {
					slidesToShow: 1,
					centerPadding: '50px',
				}
			}
			// You can unslick at a given breakpoint now by adding:
			// settings: "unslick"
			// instead of a settings object
		]


	});



	$('.department-slide').slick({
		dots: false,
		arrows: true,
		infinite: true,
		speed: 300,
		slidesToShow: 1,
	});


	$('.monument-home-slide').slick({
		dots: false,
		arrows: true,
		infinite: true,
		speed: 300,
		slidesToShow: 1,
	});



	$('.latest-news-slider').slick({
		dots: false,
		arrows: false,
		infinite: true,
		speed: 300,
		autoplay: true,
		slidesToShow: 2,
		slidesToScroll: 2,
		responsive: [
			{
				breakpoint: 500,
				settings: {
					slidesToShow: 1,
					slidesToScroll: 1,
				}
			},
		]
	});

	$('.whats-slider').slick({
		dots: false,
		arrows: true,
		infinite: true,
		speed: 300,
		slidesToShow: 3,
		slidesToScroll: 1,
		prevArrow: $('.whats-prev'),
		nextArrow: $('.whats-next'),

		responsive: [

			{
				breakpoint: 1024,
				settings: {
					slidesToShow: 3,
					slidesToScroll: 1,


				}
			},
			{
				breakpoint: 992,
				settings: {
					slidesToShow: 2,
					slidesToScroll: 1
				}
			},
			{
				breakpoint: 500,
				settings: {
					slidesToShow: 1,
					slidesToScroll: 1
				}
			}

		]

	});






	$('.contest-slider').slick({
		dots: false,
		arrows: true,
		infinite: true,
		speed: 300,
		slidesToShow: 3,
		slidesToScroll: 1,


		responsive: [

			{
				breakpoint: 1024,
				settings: {
					slidesToShow: 3,
					slidesToScroll: 1,


				}
			},
			{
				breakpoint: 992,
				settings: {
					slidesToShow: 2,
					slidesToScroll: 1
				}
			},
			{
				breakpoint: 500,
				settings: {
					slidesToShow: 1,
					slidesToScroll: 1
				}
			}

		]

	});



	$('a[data-toggle="tab"]').on('shown.bs.tab', function (e) {
		$('.zone-slider').slick('setPosition');
		$('.news-hold-slider-js ').slick('setPosition');
	})




	$('.homebanner').slick({
		centerMode: false,
		dots: true,
		slidesToShow: 1,
		slidesToScroll: 1,
		arrows: true,
		autoplay: true,
		autoplaySpeed: 7000,
		speed: 500,
		fade: true,
		cssEase: 'linear',
	});



	$('.ff-slides').slick({
		slidesToShow: 4,
		slidesToScroll: 1,
		autoplay: false,
		autoplaySpeed: 3000,
		centerMode: false,
		dots: false,
		infinite: false,
		arrows: true,

		responsive: [

			{
				breakpoint: 1024,
				settings: {
					slidesToShow: 3,
					slidesToScroll: 1,


				}
			},
			{
				breakpoint: 992,
				settings: {
					slidesToShow: 2,
					slidesToScroll: 1
				}
			},
			{
				breakpoint: 500,
				settings: {
					slidesToShow: 1,
					slidesToScroll: 1
				}
			}
			// You can unslick at a given breakpoint now by adding:
			// settings: "unslick"
			// instead of a settings object
		]


	});




	$('.history-slider').slick({
		slidesToShow: 3,
		slidesToScroll: 1,
		autoplay: true,
		autoplaySpeed: 3000,
		dots: true,

		responsive: [

			{
				breakpoint: 1024,
				settings: {
					slidesToShow: 3,
					slidesToScroll: 1,
					infinite: true,
					dots: true
				}
			},
			{
				breakpoint: 992,
				settings: {
					slidesToShow: 2,
					slidesToScroll: 1
				}
			},
			{
				breakpoint: 500,
				settings: {
					slidesToShow: 1,
					slidesToScroll: 1
				}
			}
			// You can unslick at a given breakpoint now by adding:
			// settings: "unslick"
			// instead of a settings object
		]


	});



	$(document).ready(function () {
		new WOW().init();
	});

});


(function ($) {
	$.fn.countTo = function (options) {
		options = options || {};

		return $(this).each(function () {
			// set options for current element
			var settings = $.extend({}, $.fn.countTo.defaults, {
				from: $(this).data('from'),
				to: $(this).data('to'),
				speed: $(this).data('speed'),
				refreshInterval: $(this).data('refresh-interval'),
				decimals: $(this).data('decimals')
			}, options);

			// how many times to update the value, and how much to increment the value on each update
			var loops = Math.ceil(settings.speed / settings.refreshInterval),
				increment = (settings.to - settings.from) / loops;

			// references & variables that will change with each update
			var self = this,
				$self = $(this),
				loopCount = 0,
				value = settings.from,
				data = $self.data('countTo') || {};

			$self.data('countTo', data);

			// if an existing interval can be found, clear it first
			if (data.interval) {
				clearInterval(data.interval);
			}
			data.interval = setInterval(updateTimer, settings.refreshInterval);

			// initialize the element with the starting value
			render(value);

			function updateTimer() {
				value += increment;
				loopCount++;

				render(value);

				if (typeof (settings.onUpdate) == 'function') {
					settings.onUpdate.call(self, value);
				}

				if (loopCount >= loops) {
					// remove the interval
					$self.removeData('countTo');
					clearInterval(data.interval);
					value = settings.to;

					if (typeof (settings.onComplete) == 'function') {
						settings.onComplete.call(self, value);
					}
				}
			}

			function render(value) {
				var formattedValue = settings.formatter.call(self, value, settings);
				$self.html(formattedValue);
			}
		});
	};

	$.fn.countTo.defaults = {
		from: 0,               // the number the element should start at
		to: 0,                 // the number the element should end at
		speed: 1000,           // how long it should take to count between the target numbers
		refreshInterval: 100,  // how often the element should be updated
		decimals: 0,           // the number of decimal places to show
		formatter: formatter,  // handler for formatting the value before rendering
		onUpdate: null,        // callback method for every time the element is updated
		onComplete: null       // callback method for when the element finishes updating
	};

	function formatter(value, settings) {
		return value.toFixed(settings.decimals);
	}
}(jQuery));

jQuery(function ($) {
	// custom formatting example
	$('.count-number').data('countToOptions', {
		formatter: function (value, options) {
			return value.toFixed(options.decimals).replace(/\B(?=(?:\d{3})+(?!\d))/g, ',');
		}
	});

	// start all the timers
	$('.timer').each(count);

	function count(options) {
		var $this = $(this);
		options = $.extend({}, options || {}, $this.data('countToOptions') || {});
		$this.countTo(options);
	}
});




$(document).ready(function () {


	$('.festivals-hold-slider-js').slick({
		dots: false,
		infinite: true,
		arrows: true,
		speed: 500,
		centerMode: false,
		autoplay: true,
		slidesToShow: 3,
		responsive: [
			{
				breakpoint: 1800,
				settings: {
					slidesToShow: 3,
				}
			},

			{
				breakpoint: 1550,
				settings: {
					slidesToShow: 3,
				}
			},

			{
				breakpoint: 1150,
				settings: {
					slidesToShow: 3,
				}
			},
			{
				breakpoint: 1024,
				settings: {
					slidesToShow: 3,

				}
			},
			{
				breakpoint: 769,
				settings: {
					slidesToShow: 2,

				}
			},
			{
				breakpoint: 500,
				settings: {
					slidesToShow: 1,

				}
			}
			// You can unslick at a given breakpoint now by adding:
			// settings: "unslick"
			// instead of a settings object
		]


	});

	$('.news-hold-slider-js').slick({
		dots: false,
		infinite: true,
		arrows: true,
		speed: 500,
		centerMode: false,
		autoplay: false,
		slidesToShow: 4,
		responsive: [
			{
				breakpoint: 1800,
				settings: {
					slidesToShow: 4,
				}
			},

			{
				breakpoint: 1550,
				settings: {
					slidesToShow: 3,
				}
			},

			{
				breakpoint: 1150,
				settings: {
					slidesToShow: 3,
				}
			},
			{
				breakpoint: 1024,
				settings: {
					slidesToShow: 3,

				}
			},
			{
				breakpoint: 769,
				settings: {
					slidesToShow: 2,

				}
			},
			{
				breakpoint: 500,
				settings: {
					slidesToShow: 1,

				}
			}
			// You can unslick at a given breakpoint now by adding:
			// settings: "unslick"
			// instead of a settings object
		]
	});
	$('.festival-hold-slider-js').slick({
		dots: false,
		infinite: true,
		arrows: true,
		speed: 500,
		centerMode: false,
		autoplay: false,
		slidesToShow: 1,
	});
});

$(function () {
	$('.normal-list').select2({
		placeholder: "-- Select -- ",
	});

	$('.choose-gov').select2({
		placeholder: "-- Choose Governorate -- ",
	});

	$('.choose-area').select2({
		placeholder: "-- Choose Area -- ",
	});

	//JQUERY DATE PICKER
	$(".datepicker").datepicker({
		changeMonth: true,
		changeYear: true,
		dateFormat: "dd/mm/yy"
	});
});




/*banner image fade if it has caption*/


