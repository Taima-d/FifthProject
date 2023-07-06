$(document).ready(function () {
    // Get the current URL
    var currentUrl = window.location.pathname;

    // Find the corresponding <a> element and add the "active" class
    $('#sidebar-menu a').each(function () {
        if ($(this).attr('href') === currentUrl) {
            $(this).addClass('active');
            // Add the "active" class to the parent <li> element
            $(this).closest('li').addClass('active');
        }
    });
});
