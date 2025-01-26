export namespace Utils {

    interface Size {
        height: number;
        width: number;
    }

    var windowResizeCallback: any = null;

    let handleResize = function () {
        if (windowResizeCallback) {
            windowResizeCallback.invokeMethodAsync("CallbackAsync", { height: window.innerHeight, width: window.innerWidth });
        }
    }

    export let initialize = function (obj: any): void {

        windowResizeCallback = obj;

        window.addEventListener("resize", handleResize);
    }

    export let finalize = function (): void {

        window.removeEventListener("resize", handleResize);

        if (windowResizeCallback) {
            windowResizeCallback.dispose();

            windowResizeCallback = null;
        }
    }

    export let click = function (element: HTMLElement): void {
        element.click();
    }

    export let focus = function (element: HTMLElement): void {
        element.focus();
    }

    export let getWindowWidth = function (): number {
        return window.innerWidth;
    }

    export let getWindowHeight = function (): number {
        return window.innerHeight;
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
            height: element.clientHeight,
            width: element.clientWidth
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

    export let addClassIfNotExists = function (element: HTMLElement, className: string): void {
        if (!element.classList.contains(className)) {
            element.classList.add(className);
        }
    }

    export let removeClassIfExists = function (element: HTMLElement, className: string): void {
        if (element.classList.contains(className)) {
            element.classList.remove(className);
        }
    }

    export let toggleClass = function (element: HTMLElement, className: string): void {
        element.classList.toggle(className);
    }

    export let hasClass = function (element: HTMLElement, className: string): boolean {
        return element.classList.contains(className);
    }
}