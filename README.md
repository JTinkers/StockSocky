# StockSocky
A lightweight app for stock price tracking.

# How it works - behind the scenes
StockSocky is split into two layers: an app and a service.

The service is simply a Web API serving as a database provider.

The app handles management of stocks and purchases aswell as market value fetching from finnhub API.

The point of having separate service and an app without a clientside database is to be able to have a single database with multiple clients
\- just in case if you wanted to host it in different configurations.

StockSocky was built using Nuxt, Vue, WebSockets and ASP.NET Core.

# To-do
- Add ability to force update of market value via API.
- Set fixed number of decimals for values.
- Store market values between pages and upon refreshing so they don't disappear when you add new stocks etc.

# Requirements
- [node.js](https://nodejs.org)

# Installation
- Download and unpack [the .zip](https://github.com/JTinkers/StockSocky/archive/master.zip).
- Go to [finnhub.io](https://finnhub.io/) and register a free account to get your API key - **no verification required**.
- Go to `app` folder and open `nuxt.config.js` with any notepad.
- Paste your API key into the `key` field, here:
```
env:
{
    finnhub:
    {
        key: '' <-- here, between quotes
    }
}
```
- Save the file and run `install.bat`.

# Usage
- Run `start_service.bat`
- Run `start_app.bat`

The app and the service are now running, you can add any stocks to track their market values and add purchases to calculate potential profits.

**If you see no market values, just wait a while - stocks update every few seconds or even minutes**.
