package com.gcu.gcu;

import org.springframework.boot.autoconfigure.security.oauth2.client.EnableOAuth2Sso;
import org.springframework.context.annotation.Bean;
import org.springframework.context.annotation.Configuration;
import org.springframework.security.config.annotation.web.builders.HttpSecurity;
import org.springframework.security.config.annotation.web.configuration.EnableWebSecurity;
import org.springframework.security.web.SecurityFilterChain;

@Configuration
@EnableOAuth2Sso
public class SecurityConfig {

    public SecurityFilterChain securityFilterChain(HttpSecurity http) throws Exception {
        http
                .antMatcher("/**")
                .authorizeRequests(requests -> requests
                        .antMatchers("/", "/login**", "/callback", "/error**").permitAll()
                        .anyRequest()
                        .authenticated());

        return http.build();
    }
}
