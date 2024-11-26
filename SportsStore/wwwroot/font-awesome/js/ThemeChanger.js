// ThemeChanger.js

function applyTheme(theme) {
    if (theme === 'light') {
        document.documentElement.classList.remove('bg-dark', 'text-light');
        document.documentElement.classList.add('bg-light', 'text-dark');
        document.body.classList.remove('bg-dark', 'text-light');
        document.body.classList.add('bg-light', 'text-dark');
    } else {
        document.documentElement.classList.remove('bg-light', 'text-dark');
        document.documentElement.classList.add('bg-dark', 'text-light');
        document.body.classList.remove('bg-light', 'text-dark');
        document.body.classList.add('bg-dark', 'text-light');
    }
}

function toggleTheme(isLight) {
    const theme = isLight ? 'light' : 'dark';
    applyTheme(theme);
    localStorage.setItem('theme', theme);
}

document.addEventListener('DOMContentLoaded', function () {
    const savedTheme = localStorage.getItem('theme') || 'dark'; // Default to dark
    applyTheme(savedTheme);

    const themeSwitch = document.getElementById('btnSwitch');
    if (themeSwitch) {
        themeSwitch.checked = savedTheme === 'light';
        themeSwitch.addEventListener('change', function () {
            toggleTheme(themeSwitch.checked);
        });
    }
});
