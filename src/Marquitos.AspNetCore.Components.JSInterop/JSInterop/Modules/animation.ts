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

    export let fadeIn = function (element: HTMLElement, obj, duration: number = 250): void {
        var keyFrames: Keyframe[] = [
            {
                opacity: 0
            },
            {
                opacity: 1
            }];

        play(keyFrames, element, obj, duration);
    }

    export let fadeOut = function (element: HTMLElement, obj, duration: number = 150): void {
        var keyFrames: Keyframe[] = [
            {
                opacity: 1
            },
            {
                opacity: 0
            }];

        play(keyFrames, element, obj, duration);
    }

    export let slideInFromTop = function (element: HTMLElement, obj, distance: number = 50, duration: number = 300): void {
        
        if (distance == 0) {
            distance = element.clientHeight;
        }

        var keyFrames: Keyframe[] = [
            {
                transform: "translate(0, -" + distance + "px)",
                opacity: 0.5
            },
            {
                transform: "none",
                opacity: 1
            }];

        play(keyFrames, element, obj, {
            duration: duration,
            easing: 'ease-out'
        });
    }

    export let slideInFromBottom = function (element: HTMLElement, obj, distance: number = 50, duration: number = 300): void {

        if (distance == 0) {
            distance = element.clientHeight;
        }

        var keyFrames: Keyframe[] = [
            {
                transform: "translate(0, " + distance + "px)",
                opacity: 0.5
            },
            {
                transform: "none",
                opacity: 1
            }];

        play(keyFrames, element, obj, {
            duration: duration,
            easing: 'ease-out'
        });
    }

    export let slideInFromLeft = function (element: HTMLElement, obj, distance: number = 50, duration: number = 300): void {

        if (distance == 0) {
            distance = element.clientWidth;
        }

        var keyFrames: Keyframe[] = [
            {
                transform: "translate(-" + distance + "px, 0)",
                opacity: 0.5
            },
            {
                transform: "none",
                opacity: 1
            }];

        play(keyFrames, element, obj, {
            duration: duration,
            easing: 'ease-out'
        });
    }

    export let slideInFromRight = function (element: HTMLElement, obj, distance: number = 50, duration: number = 300): void {

        if (distance == 0) {
            distance = element.clientWidth;
        }

        var keyFrames: Keyframe[] = [
            {
                transform: "translate(" + distance + "px, 0)",
                opacity: 0.5
            },
            {
                transform: "none",
                opacity: 1
            }];

        play(keyFrames, element, obj, {
            duration: duration,
            easing: 'ease-out'
        });
    }

    export let slideOutToTop = function (element: HTMLElement, obj, distance: number = 50, duration: number = 200): void {

        if (distance == 0) {
            distance = element.clientHeight;
        }

        var keyFrames: Keyframe[] = [
            {
                transform: "none",
                opacity: 1
            },
            {
                transform: "translate(0, -" + distance + "px)",
                opacity: 0
            }];

        play(keyFrames, element, obj, {
            duration: duration,
            easing: 'ease-in'
        });
    }

    export let slideOutToBottom = function (element: HTMLElement, obj, distance: number = 50, duration: number = 200): void {

        if (distance == 0) {
            distance = element.clientHeight;
        }

        var keyFrames: Keyframe[] = [
            {
                transform: "none",
                opacity: 1
            },
            {
                transform: "translate(0, " + distance + "px)",
                opacity: 0
            }];

        play(keyFrames, element, obj, {
            duration: duration,
            easing: 'ease-in'
        });
    }

    export let slideOutToLeft = function (element: HTMLElement, obj, distance: number = 50, duration: number = 200): void {

        if (distance == 0) {
            distance = element.clientWidth;
        }

        var keyFrames: Keyframe[] = [
            {
                transform: "none",
                opacity: 1
            },
            {
                transform: "translate(-" + distance + "px, 0)",
                opacity: 0
            }];

        play(keyFrames, element, obj, {
            duration: duration,
            easing: 'ease-in'
        });
    }

    export let slideOutToRight = function (element: HTMLElement, obj, distance: number = 50, duration: number = 200): void {

        if (distance == 0) {
            distance = element.clientWidth;
        }

        var keyFrames: Keyframe[] = [
            {
                transform: "none",
                opacity: 1
            },
            {
                transform: "translate(" + distance + "px, 0)",
                opacity: 0
            }];

        play(keyFrames, element, obj, {
            duration: duration,
            easing: 'ease-in'
        });
    }

    export let expand = function (element: HTMLElement, obj, from: number = 0, duration: number = 300): void {
        var keyFrames: Keyframe[] = [
            {
                height: from + 'px',
                overflow: 'hidden'
            },
            {
                height: element.clientHeight+'px',
                overflow: 'hidden'
            }];

        play(keyFrames, element, obj, {
            duration: duration,
            easing: 'ease'
        });       
    }

    export let collapse = function (element: HTMLElement, obj, to: number = 0, duration: number = 300): void {
        var keyFrames: Keyframe[] = [
            {
                height: element.clientHeight+'px',
                overflow: 'hidden'
            },
            {
                height: to + 'px',
                overflow: 'hidden'
            }];

        play(keyFrames, element, obj, {
            duration: duration,
            easing: 'ease'
        });
    }

    export let grow = function (element: HTMLElement, obj, from: number = 0, duration: number = 300): void {
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
            duration: duration,
            easing: 'ease-out'
        });
    }

    export let compact = function (element: HTMLElement, obj, to: number = 0, duration: number = 300): void {
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
            duration: duration,
            easing: 'ease-out'
        });
    }

    export let growAndExpand = function (element: HTMLElement, obj, fromWidth: number = 0, fromHeight: number = 0, duration: number = 300): void {
        var keyFrames: Keyframe[] = [
            {
                width: fromWidth + 'px',
                height: fromHeight + 'px',
                overflow: 'hidden'
            },
            {
                width: element.clientWidth + 'px',
                height: element.clientHeight + 'px',
                overflow: 'hidden'
            }];

        play(keyFrames, element, obj, {
            duration: duration,
            easing: 'ease'
        });
    }

    export let compactAndCollapse = function (element: HTMLElement, obj, toWidth: number = 0, toHeight: number = 0, duration: number = 300): void {
        var keyFrames: Keyframe[] = [
            {
                width: element.clientWidth + 'px',
                height: element.clientHeight + 'px',
                overflow: 'hidden'
            },
            {
                width: toWidth + 'px',
                height: toHeight + 'px',
                overflow: 'hidden'
            }];

        play(keyFrames, element, obj, {
            duration: duration,
            easing: 'ease'
        });
    }

    export let clickAnimation = function (element: HTMLElement, obj, duration: number = 300): void {
        var keyFrames: Keyframe[] = [
            { transform: 'scale(1)' },
            { transform: 'scale(0.9)' },
            { transform: 'scale(1)' }
        ];
        play(keyFrames, element, obj, duration);
    }
}
