const langButton = document.getElementById("changeLang");
const darkModeButton = document.getElementById("toggleDarkMode");

const translations = {
    en: {
        title: "Welcome to the Educational Platform",
        description: "Learn anywhere, anytime!",
    },
    pl: {
        title: "Witaj na Platformie Edukacyjnej",
        description: "Ucz się gdziekolwiek i kiedykolwiek!",
    },
};

let currentLang = "pl";

langButton.addEventListener("click", () => {
    currentLang = currentLang === "pl" ? "en" : "pl";

    document.getElementById("title").textContent = translations[currentLang].title;
    document.getElementById("description").textContent = translations[currentLang].description;

    langButton.textContent = currentLang.toUpperCase();
});

darkModeButton.addEventListener("click", () => {
    document.body.classList.toggle("dark-mode");

    darkModeButton.textContent = document.body.classList.contains("dark-mode") ? "☀️" : "🌙";
});