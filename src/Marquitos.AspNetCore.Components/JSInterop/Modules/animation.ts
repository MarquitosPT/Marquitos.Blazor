export namespace Animation {

    let play = function (keyframes: Keyframe[] | PropertyIndexedKeyframes | null, element: HTMLElement, obj: any, options?: number | KeyframeAnimationOptions): void {
        try {
            // Cria e inicia a animação
            var animation = element.animate(keyframes, options);

            animation.oncancel = animation.onfinish = function (event: AnimationPlaybackEvent) {
                // Invocar o Callbak
                obj.invokeMethodAsync("CallbackAsync");
                obj.dispose();
            }
        } catch (e) {
            // Invocar o Callbak
            obj.invokeMethodAsync("CallbackAsync");
            obj.dispose();

            console.error(e);
        }
    }

    export let fadeIn = function (element: HTMLElement, obj): void {
        var keyFrames: Keyframe[] = [
            {
                opacity: 0
            },
            {
                opacity: 1
            }];

        play(keyFrames, element, obj, 250);
    }

    export let fadeOut = function (element: HTMLElement, obj): void {
        var keyFrames: Keyframe[] = [
            {
                opacity: 1
            },
            {
                opacity: 0
            }];

        play(keyFrames, element, obj, 150);
    }

    export let slideInFromTop = function (element: HTMLElement, obj): void {
        var keyFrames: Keyframe[] = [
            {
                transform: "translate(0, -50px)",
                opacity: 0.5
            },
            {
                transform: "none",
                opacity: 1
            }];

        play(keyFrames, element, obj, {
            duration: 300,
            easing: 'ease-out'
        });
    }

    export let slideInFromBottom = function (element: HTMLElement, obj): void {
        var keyFrames: Keyframe[] = [
            {
                transform: "translate(0, 50px)",
                opacity: 0.5
            },
            {
                transform: "none",
                opacity: 1
            }];

        play(keyFrames, element, obj, {
            duration: 300,
            easing: 'ease-out'
        });
    }

    export let slideInFromLeft = function (element: HTMLElement, obj): void {
        var keyFrames: Keyframe[] = [
            {
                transform: "translate(-50px, 0)",
                opacity: 0.5
            },
            {
                transform: "none",
                opacity: 1
            }];

        play(keyFrames, element, obj, {
            duration: 300,
            easing: 'ease-out'
        });
    }

    export let slideInFromRight = function (element: HTMLElement, obj): void {
        var keyFrames: Keyframe[] = [
            {
                transform: "translate(50px, 0)",
                opacity: 0.5
            },
            {
                transform: "none",
                opacity: 1
            }];

        play(keyFrames, element, obj, {
            duration: 300,
            easing: 'ease-out'
        });
    }

    export let slideOutToTop = function (element: HTMLElement, obj): void {
        var keyFrames: Keyframe[] = [
            {
                transform: "none",
                opacity: 1
            },
            {
                transform: "translate(0, -50px)",
                opacity: 0
            }];

        play(keyFrames, element, obj, {
            duration: 200,
            easing: 'ease-in'
        });
    }

    export let slideOutToBottom = function (element: HTMLElement, obj): void {
        var keyFrames: Keyframe[] = [
            {
                transform: "none",
                opacity: 1
            },
            {
                transform: "translate(0, 50px)",
                opacity: 0
            }];

        play(keyFrames, element, obj, {
            duration: 200,
            easing: 'ease-in'
        });
    }

    export let slideOutToLeft = function (element: HTMLElement, obj): void {
        var keyFrames: Keyframe[] = [
            {
                transform: "none",
                opacity: 1
            },
            {
                transform: "translate(-50px, 0)",
                opacity: 0
            }];

        play(keyFrames, element, obj, {
            duration: 200,
            easing: 'ease-in'
        });
    }

    export let slideOutToRight = function (element: HTMLElement, obj): void {
        var keyFrames: Keyframe[] = [
            {
                transform: "none",
                opacity: 1
            },
            {
                transform: "translate(50px, 0)",
                opacity: 0
            }];

        play(keyFrames, element, obj, {
            duration: 200,
            easing: 'ease-in'
        });
    }

    export let expand = function (element: HTMLElement, obj): void {
        var keyFrames: Keyframe[] = [
            {
                height: '0',
                overflow: 'hidden'
            },
            {
                height: element.clientHeight+'px',
                overflow: 'hidden'
            }];

        play(keyFrames, element, obj, {
            duration: 350,
            easing: 'ease'
        });       
    }

    export let collapse = function (element: HTMLElement, obj): void {
        var keyFrames: Keyframe[] = [
            {
                height: element.clientHeight+'px',
                overflow: 'hidden'
            },
            {
                height: '0',
                overflow: 'hidden'
            }];

        play(keyFrames, element, obj, {
            duration: 350,
            easing: 'ease'
        });
    }

    export let grow = function (element: HTMLElement, obj, from: number = 0): void {
        var keyFrames: Keyframe[] = [
            {
                width: from + 'px',
                overflow: 'hidden'
            },
            {
                width: element.clientWidth + 'px',
                overflow: 'hidden'
            }];

        play(keyFrames, element, obj, {
            duration: 350,
            easing: 'ease'
        });
    }

    export let compact = function (element: HTMLElement, obj, to: number = 0): void {
        var keyFrames: Keyframe[] = [
            {
                width: element.clientWidth + 'px',
                overflow: 'hidden'
            },
            {
                width: to + 'px',
                overflow: 'hidden'
            }];

        play(keyFrames, element, obj, {
            duration: 350,
            easing: 'ease'
        });
    }
}
