/** @type {import('tailwindcss').Config} */
module.exports = {
    content: ['./**/*.{razor, html}'],
    theme: {
        extend: {
            colors: {
                'qp-background': '#3f3d47',
            },
        },
        fontFamily: {
            inter: ["Inter", "sans-serif"]
        }
    },
    plugins: [],
}

