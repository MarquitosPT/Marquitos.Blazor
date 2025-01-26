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
    Animation.fadeIn = function (element, obj, duration = 250) {
        var keyFrames = [
            {
                opacity: 0
            },
            {
                opacity: 1
            }
        ];
        play(keyFrames, element, obj, duration);
    };
    Animation.fadeOut = function (element, obj, duration = 150) {
        var keyFrames = [
            {
                opacity: 1
            },
            {
                opacity: 0
            }
        ];
        play(keyFrames, element, obj, duration);
    };
    Animation.slideInFromTop = function (element, obj, distance = 50, duration = 300) {
        if (distance == 0) {
            distance = element.clientHeight;
        }
        var keyFrames = [
            {
                transform: "translate(0, -" + distance + "px)",
                opacity: 0.5
            },
            {
                transform: "none",
                opacity: 1
            }
        ];
        play(keyFrames, element, obj, {
            duration: duration,
            easing: 'ease-out'
        });
    };
    Animation.slideInFromBottom = function (element, obj, distance = 50, duration = 300) {
        if (distance == 0) {
            distance = element.clientHeight;
        }
        var keyFrames = [
            {
                transform: "translate(0, " + distance + "px)",
                opacity: 0.5
            },
            {
                transform: "none",
                opacity: 1
            }
        ];
        play(keyFrames, element, obj, {
            duration: duration,
            easing: 'ease-out'
        });
    };
    Animation.slideInFromLeft = function (element, obj, distance = 50, duration = 300) {
        if (distance == 0) {
            distance = element.clientWidth;
        }
        var keyFrames = [
            {
                transform: "translate(-" + distance + "px, 0)",
                opacity: 0.5
            },
            {
                transform: "none",
                opacity: 1
            }
        ];
        play(keyFrames, element, obj, {
            duration: duration,
            easing: 'ease-out'
        });
    };
    Animation.slideInFromRight = function (element, obj, distance = 50, duration = 300) {
        if (distance == 0) {
            distance = element.clientWidth;
        }
        var keyFrames = [
            {
                transform: "translate(" + distance + "px, 0)",
                opacity: 0.5
            },
            {
                transform: "none",
                opacity: 1
            }
        ];
        play(keyFrames, element, obj, {
            duration: duration,
            easing: 'ease-out'
        });
    };
    Animation.slideOutToTop = function (element, obj, distance = 50, duration = 200) {
        if (distance == 0) {
            distance = element.clientHeight;
        }
        var keyFrames = [
            {
                transform: "none",
                opacity: 1
            },
            {
                transform: "translate(0, -" + distance + "px)",
                opacity: 0
            }
        ];
        play(keyFrames, element, obj, {
            duration: duration,
            easing: 'ease-in'
        });
    };
    Animation.slideOutToBottom = function (element, obj, distance = 50, duration = 200) {
        if (distance == 0) {
            distance = element.clientHeight;
        }
        var keyFrames = [
            {
                transform: "none",
                opacity: 1
            },
            {
                transform: "translate(0, " + distance + "px)",
                opacity: 0
            }
        ];
        play(keyFrames, element, obj, {
            duration: duration,
            easing: 'ease-in'
        });
    };
    Animation.slideOutToLeft = function (element, obj, distance = 50, duration = 200) {
        if (distance == 0) {
            distance = element.clientWidth;
        }
        var keyFrames = [
            {
                transform: "none",
                opacity: 1
            },
            {
                transform: "translate(-" + distance + "px, 0)",
                opacity: 0
            }
        ];
        play(keyFrames, element, obj, {
            duration: duration,
            easing: 'ease-in'
        });
    };
    Animation.slideOutToRight = function (element, obj, distance = 50, duration = 200) {
        if (distance == 0) {
            distance = element.clientWidth;
        }
        var keyFrames = [
            {
                transform: "none",
                opacity: 1
            },
            {
                transform: "translate(" + distance + "px, 0)",
                opacity: 0
            }
        ];
        play(keyFrames, element, obj, {
            duration: duration,
            easing: 'ease-in'
        });
    };
    Animation.expand = function (element, obj, from = 0, duration = 300) {
        var keyFrames = [
            {
                height: from + 'px',
                overflow: 'hidden'
            },
            {
                height: element.clientHeight + 'px',
                overflow: 'hidden'
            }
        ];
        play(keyFrames, element, obj, {
            duration: duration,
            easing: 'ease'
        });
    };
    Animation.collapse = function (element, obj, to = 0, duration = 300) {
        var keyFrames = [
            {
                height: element.clientHeight + 'px',
                overflow: 'hidden'
            },
            {
                height: to + 'px',
                overflow: 'hidden'
            }
        ];
        play(keyFrames, element, obj, {
            duration: duration,
            easing: 'ease'
        });
    };
    Animation.grow = function (element, obj, from = 0, duration = 300) {
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
            easing: 'ease-out'
        });
    };
    Animation.compact = function (element, obj, to = 0, duration = 300) {
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
            duration: duration,
            easing: 'ease-out'
        });
    };
    Animation.growAndExpand = function (element, obj, fromWidth = 0, fromHeight = 0, duration = 300) {
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
            duration: duration,
            easing: 'ease'
        });
    };
    Animation.compactAndCollapse = function (element, obj, toWidth = 0, toHeight = 0, duration = 300) {
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
            duration: duration,
            easing: 'ease'
        });
    };
    Animation.clickAnimation = function (element, obj, duration = 300) {
        var keyFrames = [
            { transform: 'scale(1)' },
            { transform: 'scale(0.9)' },
            { transform: 'scale(1)' }
        ];
        play(keyFrames, element, obj, duration);
    };
})(Animation || (Animation = {}));
