package com.gcu.activity2;

import org.springframework.security.crypto.bcrypt.BCryptPasswordEncoder;
import org.springframework.stereotype.Controller;
import org.springframework.ui.Model;
import org.springframework.web.bind.annotation.GetMapping;

@Controller
public class HomeController {

    @GetMapping("/")
    public String home(Model model) {
        model.addAttribute("title", "My Home");
        String encoded = new BCryptPasswordEncoder().encode("phillip");
        System.err.println(encoded);
        return "home";
    }
}
