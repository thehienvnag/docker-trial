# syntax=docker/dockerfile:experimental
# Maven config
FROM maven:3.5.2-jdk-8-alpine AS MAVEN_BUILD


WORKDIR /build
COPY pom.xml /build/

COPY src /build/src/

RUN --mount=type=cache,target=/root/.m2 mvn install -DskipTests

# JDK Config
FROM openjdk:8-jre-alpine
EXPOSE 8080

WORKDIR /app 

COPY --from=MAVEN_BUILD /build/target/demo-app-0.0.1-SNAPSHOT.jar /app/

ENTRYPOINT [ "java", "-jar", "demo-app-0.0.1-SNAPSHOT.jar" ]

# syntax = docker/dockerfile:experimental

# FROM openjdk:15-jdk-slim as bulid
# WORKDIR /application

# COPY mvnw .
# COPY .mvn .mvn
# COPY pom.xml .
# COPY src src

# RUN --mount=type=cache,target=/root/.m2 ./mvnw  install -DskipTests

# RUN cp /application/target/*.jar app.jar
# RUN java -Djarmode=layertools -jar app.jar extract

# FROM openjdk:15-jdk-slim
# WORKDIR /application
# COPY --from=bulid application/dependencies/ ./
# COPY --from=bulid application/spring-boot-loader/ ./
# COPY --from=bulid application/snapshot-dependencies/ ./
# COPY --from=bulid application/application/ ./
# ENTRYPOINT ["java", "org.springframework.boot.loader.JarLauncher"]