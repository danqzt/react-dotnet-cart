
FROM node:lts-alpine as builder


WORKDIR /app

COPY ui/package.json /app

RUN npm install

COPY ui/. .


CMD [ "npm", "run", "start" ]