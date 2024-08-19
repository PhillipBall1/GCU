package com.gcu.activity2;

import java.util.ArrayList;
import java.util.List;

import org.springframework.beans.factory.annotation.Autowired;
import org.springframework.security.core.GrantedAuthority;
import org.springframework.security.core.authority.SimpleGrantedAuthority;
import org.springframework.security.core.userdetails.User;
import org.springframework.security.core.userdetails.UserDetails;
import org.springframework.security.core.userdetails.UserDetailsService;
import org.springframework.security.core.userdetails.UsernameNotFoundException;
import org.springframework.stereotype.Service;

@Service
public class UserBusinessService implements UserDetailsService{

    private final UserDataService usersDataService;

    @Autowired
    public UserBusinessService(UserDataService usersDataService) {
        this.usersDataService = usersDataService;
    }

    @Override
    public UserDetails loadUserByUsername(String username) throws UsernameNotFoundException {
        
        UserEntity user = usersDataService.findByUsername(username);
        if(user != null){
            List<GrantedAuthority> authorities = new ArrayList<>();
            authorities.add((new SimpleGrantedAuthority("USER")));
            return new User(user.getUsername(), user.getPassword(), authorities);
        }
        return null;
    }
}
