package com.gcu.activity2;

import org.springframework.boot.SpringApplication;
import org.springframework.boot.autoconfigure.SpringBootApplication;
import org.springframework.data.mongodb.repository.config.EnableMongoRepositories;

@SpringBootApplication
@EnableMongoRepositories(basePackages = "com.gcu.activity2")
public class Activity3Application {

	public static void main(String[] args) {
		SpringApplication.run(Activity3Application.class, args);
	}
}
