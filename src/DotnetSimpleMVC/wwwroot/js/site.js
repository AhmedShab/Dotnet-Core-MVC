// site.js
(function () {

	var $sidebarAndWrapper = $("#sidebar,#wrapper");
	var $icon = $("#sidebarToggle i.fa");

	$("#sidebarToggle").on("click", function () {

		$sidebarAndWrapper.toggleClass("display-sidebar");

		if ($sidebarAndWrapper.hasClass("display-sidebar")) {

			$icon.removeClass("fa-angle-left");
			$icon.addClass("fa-angle-right");

		} else {
			$icon.addClass("fa-angle-left");
			$icon.removeClass("fa-angle-right");
		}
	});

})();