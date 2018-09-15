$(document).ready(function () {
    $(".slider").each(function () {
        var obj = $(this);
        $(obj).append("<div class='nav'></div>");
        $(obj).find("li").each(function () {
            $(obj).find(".nav").append("<span rel='" + $(this).index() + "'></span>");
            $(this).addClass("slider" + $(this).index());
        });
        $(obj).find("span").first().addClass("on");
    });
});
function sliderJS(obj, sl) {
    var ul = $(sl).find("ul");
    var bl = $(sl).find("li.slider" + obj);
    var step = $(bl).width();
    $(ul).animate({ marginLeft: "-" + step * obj }, 500);
}
$(document).on("click", ".slider .nav span", function () {
    var sl = $(this).closest(".slider");
    $(sl).find("span").removeClass("on");
    $(this).addClass("on");
    var obj = $(this).attr("rel");
    sliderJS(obj, sl);
    return false;

});

var link = document.querySelector(".login-link");

var popup = document.querySelector(".modal-login");
var close = popup.querySelector(".modal-close");

var form = popup.querySelector("form");
var login = popup.querySelector("[name=login]");
var password = popup.querySelector("[name=password]");

var isStorageSupport = true;
var storage = "";

try {
    storage = localStorage.getItem("login");
} catch (err) {
    isStorageSupport = false;
}

link.addEventListener("click", function (evt) {
    evt.preventDefault();
    popup.classList.add("modal-show");

    if (storage) {
        login.value = storage;
        password.focus();
    } else {
        login.focus();
    }
});

close.addEventListener("click", function (evt) {
    evt.preventDefault();
    popup.classList.remove("modal-show");
    popup.classList.remove("modal-error");
});

form.addEventListener("submit", function (evt) {
    if (!login.value || !password.value) {
        evt.preventDefault();
        popup.classList.remove("modal-error");
        popup.offsetWidth = popup.offsetWidth;
        popup.classList.add("modal-error");
    } else {
        if (isStorageSupport) {
            localStorage.setItem("login", login.value);
        }
    }
});

window.addEventListener("keydown", function (evt) {
    if (evt.keyCode === 27) {
        evt.preventDefault();
        if (popup.classList.contains("modal-show")) {
            popup.classList.remove("modal-show");
            popup.classList.remove("modal-error");
        }
    }
});

