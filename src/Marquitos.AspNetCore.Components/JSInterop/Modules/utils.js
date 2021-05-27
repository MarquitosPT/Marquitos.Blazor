export var Utils;
(function (Utils) {
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
