FROM nginx:latest

COPY ./nginx-selfsigned.crt /etc/nginx/ssl/nginx-selfsigned.crt
COPY ./nginx-selfsigned.key /etc/nginx/ssl/nginx-selfsigned.key

COPY ./default.conf.template /etc/nginx/conf.d/default.conf