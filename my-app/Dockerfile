FROM node:13-alpine as BUILD_STAGE

WORKDIR /app

COPY . .
RUN npm install
ARG REACT_APP_SPRINGBOOT_PORT
ENV REACT_APP_SPRINGBOOT_PORT $REACT_APP_SPRINGBOOT_PORT
RUN npm run build

FROM nginx:1.17-alpine as PRODUCTION_STAGE
COPY --from=BUILD_STAGE /app/build /usr/share/nginx/html
CMD ["nginx", "-g", "daemon off;"]
