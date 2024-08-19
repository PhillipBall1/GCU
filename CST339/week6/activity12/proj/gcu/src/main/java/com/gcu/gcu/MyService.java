package com.gcu.gcu;

import java.security.Principal;

import org.springframework.web.bind.annotation.GetMapping;
import org.springframework.web.bind.annotation.RequestMapping;
import org.springframework.web.bind.annotation.RestController;

@RestController
@RequestMapping("/service")
public class MyService {

    @GetMapping("/test")
    public String test(Principal principal) {
        String username = principal != null ? principal.getName() : "anonymous";
        return "hello, " + username;
    }
}
