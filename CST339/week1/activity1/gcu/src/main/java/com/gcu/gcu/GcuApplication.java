package com.gcu.gcu;

import org.springframework.boot.SpringApplication;
import org.springframework.boot.autoconfigure.SpringBootApplication;

@SpringBootApplication
public class GcuApplication {

	public static void main(String[] args) {
		System.out.println("Hello from my spring boot application!");
		SpringApplication.run(GcuApplication.class, args);
	}

}
