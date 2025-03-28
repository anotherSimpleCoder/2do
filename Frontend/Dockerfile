FROM instrumentisto/flutter:latest AS build
USER root
WORKDIR /app
COPY . .

RUN flutter doctor
RUN flutter pub get

RUN flutter channel master
RUN flutter upgrade
RUN flutter config --enable-web

COPY . /app/
WORKDIR /app
RUN flutter build web

FROM nginx:alpine
COPY --from=build /app/build/web /usr/share/nginx/html