// inspired by -> https://codepen.io/noirsociety/pen/ZEwLGXB

// modified animation to keep it centered on the viewport
// modified animation timing
// no background images
// added stagger

// simple js i ever seen :)

const slider = document.querySelector(".slider");
const progressBar = document.querySelector(".progress-bar");
const intervalTime = 6000; // 6 segundos
let autoSlideInterval;

function activate(e) {
    const items = document.querySelectorAll(".item");
    e.target.matches(".next") && slider.append(items[0]);
    e.target.matches(".prev") && slider.prepend(items[items.length - 1]);
    resetProgressBar();
}

function autoActivate() {
    const items = document.querySelectorAll(".item");
    slider.append(items[0]);
    resetProgressBar();
}

function startAutoSlide() {
    autoSlideInterval = setInterval(autoActivate, intervalTime);
    startProgressBar();
}

function resetAutoSlide() {
    clearInterval(autoSlideInterval);
    startAutoSlide();
}

function startProgressBar() {
    progressBar.style.width = '0';
    setTimeout(() => {
        progressBar.style.width = '100%';
    }, 10); // slight delay to trigger the transition
}

function resetProgressBar() {
    progressBar.style.width = '0';
    setTimeout(() => {
        progressBar.style.width = '100%';
    }, 10); // slight delay to trigger the transition
}

document.addEventListener("click", function (e) {
    if (e.target.matches(".next") || e.target.matches(".prev")) {
        activate(e);
        resetAutoSlide();
    }
}, false);

// Iniciar el cambio automático al cargar la página
startAutoSlide();
