export namespace Navigation {

    export let initialize = function (): void {
        history.replaceState({ page: 1 }, "Home", "");
    }

    export let canGoBack = function (): boolean {
        return !(history.state && history.state.page == 1);
    }

    export let back = function (): void {
        if (canGoBack()) {
            history.back();
        }
    }

    export let forward = function (): void {
        history.forward();
    }

}