FROM node:alpine AS build

WORKDIR /src
COPY package.json .
RUN npm install
COPY . .
RUN npm run build
# into /src/dist


FROM nginx:alpine

COPY nginx.conf /etc/nginx/conf.d/default.conf

WORKDIR /usr/share/nginx/html
COPY --from=build /src/dist .

# nginx already has a CMD
