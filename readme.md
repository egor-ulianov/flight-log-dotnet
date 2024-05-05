# Installation and usage instructions for the project

The aim of this project is to provide easy to use tool for logging flights on a local airfield in the middle of the Czech Republic.

## Docker launch
```
docker compose build --no-cache
docker compose up
```

Tested on MacOS Sonoma 14.1 with Docker version 4.29.0(145265) installed.

For testing purposes, please set flightlog.cz domain to your local IP address in your hosts file.
```
127.0.0.1 flightlog.cz
```

After that, you can access the application on [https://flightlog.cz/](https://flightlog.cz/)