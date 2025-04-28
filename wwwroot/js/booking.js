/* JS Document */

/******************************

[Table of Contents]

1. Vars and Inits
2. Set Header
3. Init Menu
4. Init Date Picker
5. Init Booking Slider


******************************/
let COOKIE_ROOM_ID = 'ROOM_ID';
let COOKIE_PRICE = 'PRICE';
let COOKIE_USER_ID = 'USER_ID';
$(document).ready(function () {
	"use strict";
	/* 

	1. Vars and Inits

	*/

	var header = $('.header');
	var ctrl = new ScrollMagic.Controller();

	setHeader();

	$(window).on('resize', function () {
		setHeader();

		setTimeout(function () {
			$(window).trigger('resize.px.parallax');
		}, 375);
	});

	$(document).on('scroll', function () {
		setHeader();
	});

	initMenu();
	initDatePicker();
	initBookingSlider();

	/* 

	2. Set Header

	*/

	function setHeader() {
		if ($(window).scrollTop() > 91) {
			header.addClass('scrolled');
		}
		else {
			header.removeClass('scrolled');
		}
	}

	$('#bookNowButton').on('click', function (e) {
		e.preventDefault();

		const isAuthenticatedUser = getCookie(COOKIE_USER_ID);
		if (isAuthenticatedUser) {
			const roomId = getRoomName(e.target.innerHTML);

			if (getCookie(COOKIE_ROOM_ID)) {
				deleteCookie(COOKIE_ROOM_ID);
			}
			if (getCookie(COOKIE_PRICE)) {
				deleteCookie(COOKIE_PRICE);
			}

			setCookie(COOKIE_ROOM_ID, roomId);
			setCookie(COOKIE_PRICE, 120);
			redirectToBooking();
		} else {
			redirectToLogin();
		}
	});

	$('.book_now_button').on('click', function (e) {
		e.preventDefault();
		const isAuthenticatedUser = getCookie(COOKIE_USER_ID);
		if (isAuthenticatedUser) {
			const roomId = getRoomNameByClass(e.currentTarget.classList[1]);

			if (getCookie(COOKIE_ROOM_ID)) {
				deleteCookie(COOKIE_ROOM_ID);
			}
			if (getCookie(COOKIE_PRICE)) {
				deleteCookie(COOKIE_PRICE);
			}

			setCookie(COOKIE_ROOM_ID, roomId);
			setCookie(COOKIE_PRICE, 120);
			redirectToBooking();
		} else {
			redirectToLogin();
		}
	});
	function getRoomName(roomName) {
		switch (roomName) {
			case 'Single Room':
				return 1;
			case 'Deluxe Room':
				return 2;
			case 'Family Room':
				return 3;
		}
	} 
	function getRoomNameByClass(roomNameClass) {
		switch (roomNameClass) {
			case 'single-room':
				return 1;
			case 'delux-room':
				return 2;
			case 'family-room':
				return 3;
		}
	}
	function getCookie(name) {
		const cookies = document.cookie.split('; ');
		for (let i = 0; i < cookies.length; i++) {
			const [cookieName, cookieValue] = cookies[i].split('=');
			if (cookieName === decodeURIComponent(name)) {
				return decodeURIComponent(cookieValue);
			}
		}
		return null;
	}
	function setCookie(name, value, days = 1) {
		const expires = new Date(Date.now() + days * 864e5).toUTCString();
		document.cookie = `${encodeURIComponent(name)}=${encodeURIComponent(value)}; expires=${expires}; path=/`;
	}

	function deleteCookie(name) {
		document.cookie = `${name}=; expires=Thu, 01 Jan 1970 00:00:00 UTC; path=/`;
	}

	function redirectToBooking() {
		window.location.href = '/booking/create';
	}
	function redirectToLogin() {
		window.location.href = '/account/login';
	}
	/* 

	3. Init Menu

	*/

	function initMenu() {
		if ($('.menu').length) {
			var menu = $('.menu');
			var hamburger = $('.hamburger');
			var close = $('.menu_close');

			hamburger.on('click', function () {
				menu.toggleClass('active');
			});

			close.on('click', function () {
				menu.toggleClass('active');
			});
		}
	}

	/* 

	4. Init Date Picker

	*/

	function initDatePicker() {
		if ($('.datepicker').length) {
			var datePickers = $('.datepicker');
			datePickers.each(function () {
				var dp = $(this);
				// Uncomment to use date as a placeholder
				// var date = new Date();
				// var dateM = date.getMonth() + 1;
				// var dateD = date.getDate();
				// var dateY = date.getFullYear();
				// var dateFinal = dateM + '/' + dateD + '/' + dateY;
				var placeholder = dp.data('placeholder');
				dp.val(placeholder);
				dp.datepicker();
			});
		}
	}

	/* 

	5. Init Booking Slider

	*/

	function initBookingSlider() {
		if ($('.booking_slider').length) {
			var bookingSlider = $('.booking_slider');
			bookingSlider.owlCarousel(
				{
					items: 3,
					autoplay: true,
					autoplayHoverPause: true,
					loop: false,
					smartSpeed: 1200,
					dots: false,
					nav: false,
					margin: 30,
					responsive:
					{
						0: { items: 1 },
						768: { items: 2 },
						992: { items: 3 }
					}
				});
		}
	}

});