        /** @type {import('tailwindcss').Config} */
module.exports = {
    content: ["*.razor", 
        "./Pages/**/*.{html,js,cshtml,razor}", 
        "./Views/**/*.{html,js,cshtml,razor}",
        "./Shared/**/*.{html,js,cshtml,razor}",
    ],
    plugins: [],
    important: true,

}