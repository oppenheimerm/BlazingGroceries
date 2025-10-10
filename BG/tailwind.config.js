/** @type {import('tailwindcss').Config} */
module.exports = {
    content: ['./**/*.{razor, html}'],
    theme: {
        extend: {
            colors: {
                'swamp-green': {
                    50: '#f4f6ef',//light mode bg option 1  
                    100: '#e6eadd',//light mode bg option 2
                    200: '#cfd8be',
                    300: '#b0bf97',
                    400: '#9fb083',
                    500: '#768b57',
                    600: '#5c6d43',
                    700: '#485536',
                    800: '#3b452f',
                    900: '#343c2b',//dark mode bg option 1
                    950: '#1a1f14'//dark mode bg option 2
                },
                'bg-black': {
                    50: '#858586',
                    100: '#69696a',
                    200: '#4f4f50',
                    300: '#363637',
                    400: '#1e1e1f',
                    500: '#010103',

                }
            },
        },
        fontFamily: {
            inter: ["Inter", "sans-serif"]
        }
    },
    plugins: [],
}

