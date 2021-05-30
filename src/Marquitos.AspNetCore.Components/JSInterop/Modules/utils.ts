export namespace Utils {

    interface Size {
        height: number;
        width: number;
    }

    export let getWidth = function (element: HTMLElement): number {
        return element.clientWidth;
    }

    export let getHeight = function (element: HTMLElement): number {
        return element.clientHeight;
    }

    export let getProperty = function (element: HTMLElement, name: string): string {

        return element.style.getPropertyValue(name);
    }

    export let getSize = function (element: HTMLElement): Size {
        return {
            height: element.clientWidth,
            width: element.clientHeight
        };
    }

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