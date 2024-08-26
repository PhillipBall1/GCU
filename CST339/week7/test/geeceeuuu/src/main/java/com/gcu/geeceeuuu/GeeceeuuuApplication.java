package com.gcu.geeceeuuu;

import org.springframework.boot.SpringApplication;
import org.springframework.boot.autoconfigure.SpringBootApplication;
import org.springframework.cloud.netflix.eureka.server.EnableEurekaServer;

@SpringBootApplication
@EnableEurekaServer
public class GeeceeuuuApplication {

    public static void main(String[] args) {
        SpringApplication.run(GeeceeuuuApplication.class, args);
    }
}
