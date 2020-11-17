FROM node:12.13-alpine AS builder
WORKDIR /app
COPY ./src/IdentifierGenerator.Web.Angular .
RUN npm install && \
    npm run build -- --configuration=production

FROM nginx:1.17-alpine
COPY --from=builder /app/dist/identifier-generator-web-angular /usr/share/nginx/html/
COPY --from=builder /app/nginx.conf /etc/nginx/conf.d/default.conf
