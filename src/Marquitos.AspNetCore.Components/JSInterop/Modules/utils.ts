export namespace Utils {

    export let resize = function (element: HTMLElement, width: string, heigth: string): void {
        element.style.width = width;
        element.style.height = heigth;
    }

    export let setWidth = function (element: HTMLElement, width: string): void {
        element.style.width = width;
    }

    export let setHeight = function (element: HTMLElement, heigth: string): void {
        element.style.height = heigth;
    }

    export let setProperty = function (element: HTMLElement, name: string, value: string): void {

        element.style.setProperty(name, value);
    }
}