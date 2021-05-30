export var Utils;
(function (Utils) {
    var windowResizeCallback = null;
    let handleResize = function () {
        if (windowResizeCallback) {
            windowResizeCallback.invokeMethodAsync("CallbackAsync", { height: window.innerHeight, width: window.innerWidth });
        }
    };
    Utils.initialize = function (obj) {
        windowResizeCallback = obj;
        window.addEventListener("resize", handleResize);
    };
    Utils.finalize = function () {
        window.removeEventListener("resize", handleResize);
        if (windowResizeCallback) {
            windowResizeCallback.dispose();
            windowResizeCallback = null;
        }
    };
    Utils.getWindowWidth = function () {
        return window.innerWidth;
    };
    Utils.getWindowHeight = function () {
        return window.innerHeight;
    };
    Utils.getWidth = function (element) {
        return element.clientWidth;
    };
    Utils.getHeight = function (element) {
        return element.clientHeight;
    };
    Utils.getProperty = function (element, name) {
        return element.style.getPropertyValue(name);
    };
    Utils.getSize = function (element) {
        return {
            height: element.clientHeight,
            width: element.clientWidth
        };
    };
    Utils.resize = function (element, width, heigth) {
        element.style.width = width;
        element.style.height = heigth;
    };
    Utils.setWidth = function (element, width) {
        element.style.width = width;
    };
    Utils.setHeight = function (element, heigth) {
        element.style.height = heigth;
    };
    Utils.setProperty = function (element, name, value) {
        element.style.setProperty(name, value);
    };
})(Utils || (Utils = {}));
