module.exports = {
  content: ["./src/**/*.{html,js}", 
  "./node_modules/flowbite/**/*.js",
  './src/**/*.{js,jsx,ts,tsx}',
  'node_modules/flowbite-react/**/*.{js,jsx,ts,tsx}'
],
  theme: {
    extend: {
      colors: {
        "sgreen": "#388659",
        "p-green": "#52AA5E",
        "columbian-blue": "#C6DDF0",
        "force-blue": "#508AA8"
      }
    },
  },
  plugins: [
    require('flowbite/plugin')
  ],
}