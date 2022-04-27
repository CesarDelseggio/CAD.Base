window.MyInterop = (function () {
    const _changeTheme = function (classToAdd) {
        document.body.classList.add(classToAdd);
    };

    return {
        ChangeTheme: _changeTheme
    };
})();
