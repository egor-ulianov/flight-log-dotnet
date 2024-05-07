# Pokyny k instalaci a použití pro projekt

Cílem tohoto projektu je poskytnout snadno použitelný nástroj pro zaznamenávání letů na místním letišti uprostřed České republiky.

Před spuštemím je nutné mít nainstalovaný Docker a Docker Compose.
Taky je nutné nakopirovat soubory nginx-selfsigned.crt a nginx-selfsigned.key ze složky Certificates v dodavce do složky docker-nginx-ssl a nainstalovat .crt certifikát na klientské zařízení pro správné fungování SSL.

## Spuštění přes Docker
```
docker compose build --no-cache
docker compose up
```

Otestováno na MacOS Sonoma 14.1 s nainstalovanou verzí Dockeru 4.29.0(145265).

Pro účely testování prosím nastavte doménu flightlog.cz na vaši lokální IP adresu ve vašem souboru hosts.
```
127.0.0.1 flightlog.cz
```

Poté budete moci přistupovat k aplikaci na [https://flightlog.cz/](https://flightlog.cz/)