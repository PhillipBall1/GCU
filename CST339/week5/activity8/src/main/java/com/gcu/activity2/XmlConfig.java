package com.gcu.activity2;
import org.springframework.context.annotation.Bean;
import org.springframework.context.annotation.Configuration;

import com.fasterxml.jackson.dataformat.xml.XmlMapper;

@Configuration
public class XmlConfig {

    @Bean
    public XmlMapper xmlMapper() {
        return new XmlMapper();
    }
}
