/** @type {import('tailwindcss').Config} */
module.exports = {
  content: ['./**/*.{razor, html}'],
    theme: {
        extend: {
            colors: {
                'bg-green': '#809a58',
                'bg-black': '#303030',
                'bg-black-accent': '#141516',
                'bg-light-grey' : '#F8F8F8'
            }
        },
      fontFamily: {
          sans: ["'Mulish'", "sans-serif"]
      }
  },
  plugins: [],
}

