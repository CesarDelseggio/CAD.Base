window.MyInterop = (function () {
    const _changeTheme = function (classToAdd) {
        document.body.removeAttribute("class");
        document.body.classList.add(classToAdd);
    };

    return {
        ChangeTheme: _changeTheme
    };
})();

window.initializeCarousel = () => {
    $('#bootstrapCarousel').carousel({ interval: 3000 })
    $('#bootstrapCarousel-prev').click(
        () => $('#bootstrapCarousel').carousel('prev'));
    $('#bootstrapCarousel-next').click(
        () => $('#bootstrapCarousel').carousel('next'));
}
