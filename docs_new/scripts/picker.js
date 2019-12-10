function select(element, file) {
    $(element).parent().parent().find('.active').removeClass('active');
    $(element).addClass('active');
    $(element).parent().parent().find('#' + file).addClass("active");
}