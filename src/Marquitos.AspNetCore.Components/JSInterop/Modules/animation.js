export var Animation;
(function (Animation) {
    let play = function (keyframes, element, obj, options) {
        try {
            var animation = element.animate(keyframes, options);
            animation.oncancel = animation.onfinish = function (event) {
                obj.invokeMethodAsync("CallbackAsync");
                obj.dispose();
            };
        }
        catch (e) {
            obj.invokeMethodAsync("CallbackAsync");
            obj.dispose();
            console.error(e);
        }
    };
    Animation.fadeIn = function (element, obj) {
        var keyFrames = [
            {
                opacity: 0
            },
            {
                opacity: 1
            }
        ];
        play(keyFrames, element, obj, 250);
    };
    Animation.fadeOut = function (element, obj) {
        var keyFrames = [
            {
                opacity: 1
            },
            {
                opacity: 0
            }
        ];
        play(keyFrames, element, obj, 150);
    };
    Animation.slideInFromTop = function (element, obj) {
        var keyFrames = [
            {
                transform: "translate(0, -50px)",
                opacity: 0.5
            },
            {
                transform: "none",
                opacity: 1
            }
        ];
        play(keyFrames, element, obj, {
            duration: 300,
            easing: 'ease-out'
        });
    };
    Animation.slideInFromBottom = function (element, obj) {
        var keyFrames = [
            {
                transform: "translate(0, 50px)",
                opacity: 0.5
            },
            {
                transform: "none",
                opacity: 1
            }
        ];
        play(keyFrames, element, obj, {
            duration: 300,
            easing: 'ease-out'
        });
    };
    Animation.slideInFromLeft = function (element, obj) {
        var keyFrames = [
            {
                transform: "translate(-50px, 0)",
                opacity: 0.5
            },
            {
                transform: "none",
                opacity: 1
            }
        ];
        play(keyFrames, element, obj, {
            duration: 300,
            easing: 'ease-out'
        });
    };
    Animation.slideInFromRight = function (element, obj) {
        var keyFrames = [
            {
                transform: "translate(50px, 0)",
                opacity: 0.5
            },
            {
                transform: "none",
                opacity: 1
            }
        ];
        play(keyFrames, element, obj, {
            duration: 300,
            easing: 'ease-out'
        });
    };
    Animation.slideOutToTop = function (element, obj) {
        var keyFrames = [
            {
                transform: "none",
                opacity: 1
            },
            {
                transform: "translate(0, -50px)",
                opacity: 0
            }
        ];
        play(keyFrames, element, obj, {
            duration: 200,
            easing: 'ease-in'
        });
    };
    Animation.slideOutToBottom = function (element, obj) {
        var keyFrames = [
            {
                transform: "none",
                opacity: 1
            },
            {
                transform: "translate(0, 50px)",
                opacity: 0
            }
        ];
        play(keyFrames, element, obj, {
            duration: 200,
            easing: 'ease-in'
        });
    };
    Animation.slideOutToLeft = function (element, obj) {
        var keyFrames = [
            {
                transform: "none",
                opacity: 1
            },
            {
                transform: "translate(-50px, 0)",
                opacity: 0
            }
        ];
        play(keyFrames, element, obj, {
            duration: 200,
            easing: 'ease-in'
        });
    };
    Animation.slideOutToRight = function (element, obj) {
        var keyFrames = [
            {
                transform: "none",
                opacity: 1
            },
            {
                transform: "translate(50px, 0)",
                opacity: 0
            }
        ];
        play(keyFrames, element, obj, {
            duration: 200,
            easing: 'ease-in'
        });
    };
    Animation.expand = function (element, obj) {
        var keyFrames = [
            {
                height: '0',
                overflow: 'hidden'
            },
            {
                height: element.clientHeight + 'px',
                overflow: 'hidden'
            }
        ];
        play(keyFrames, element, obj, {
            duration: 350,
            easing: 'ease'
        });
    };
    Animation.collapse = function (element, obj) {
        var keyFrames = [
            {
                height: element.clientHeight + 'px',
                overflow: 'hidden'
            },
            {
                height: '0',
                overflow: 'hidden'
            }
        ];
        play(keyFrames, element, obj, {
            duration: 350,
            easing: 'ease'
        });
    };
    Animation.grow = function (element, obj, from = 0, duration = 350) {
        var keyFrames = [
            {
                width: from + 'px',
                overflow: 'hidden'
            },
            {
                width: element.clientWidth + 'px',
                overflow: 'hidden'
            }
        ];
        play(keyFrames, element, obj, {
            duration: duration,
            easing: 'ease-in'
        });
    };
    Animation.compact = function (element, obj, to = 0) {
        var keyFrames = [
            {
                width: element.clientWidth + 'px',
                overflow: 'hidden'
            },
            {
                width: to + 'px',
                overflow: 'hidden'
            }
        ];
        play(keyFrames, element, obj, {
            duration: 350,
            easing: 'ease'
        });
    };
    Animation.growAndExpand = function (element, obj, fromWidth = 0, fromHeight = 0) {
        var keyFrames = [
            {
                width: fromWidth + 'px',
                height: fromHeight + 'px',
                overflow: 'hidden'
            },
            {
                width: element.clientWidth + 'px',
                height: element.clientHeight + 'px',
                overflow: 'hidden'
            }
        ];
        play(keyFrames, element, obj, {
            duration: 350,
            easing: 'ease'
        });
    };
    Animation.compactAndCollapse = function (element, obj, toWidth = 0, toHeight = 0) {
        var keyFrames = [
            {
                width: element.clientWidth + 'px',
                height: element.clientHeight + 'px',
                overflow: 'hidden'
            },
            {
                width: toWidth + 'px',
                height: toHeight + 'px',
                overflow: 'hidden'
            }
        ];
        play(keyFrames, element, obj, {
            duration: 350,
            easing: 'ease'
        });
    };
})(Animation || (Animation = {}));
