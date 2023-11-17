export var Navigation;
(function (Navigation) {
    Navigation.initialize = function () {
        history.replaceState({ page: 1 }, "Home", "");
    };
    Navigation.canGoBack = function () {
        return !(history.state && history.state.page == 1);
    };
    Navigation.back = function () {
        if (Navigation.canGoBack()) {
            history.back();
        }
    };
    Navigation.forward = function () {
        history.forward();
    };
})(Navigation || (Navigation = {}));
