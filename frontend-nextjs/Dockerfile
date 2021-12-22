FROM bitnami/node:12

ENV PORT 8080

# Create app directory
RUN mkdir -p /usr/src/app
WORKDIR /usr/src/app

# Installing dependencies
COPY package*.json /usr/src/app/
COPY yarn.lock /usr/src/app/
RUN npm -g config set user root
RUN yarn install --frozen-lockfile

# Copying source files
COPY . /usr/src/app

# Building app
RUN yarn build
EXPOSE 8080

# Running the app
CMD "yarn" "start"
