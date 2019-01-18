package com.example.demo.Controller;

import com.example.demo.Bean.User;
import org.springframework.web.bind.annotation.RequestMapping;
import org.springframework.web.bind.annotation.RestController;

@RestController
public class HelloWorldController {
	
    @RequestMapping("/hello2")
    public User hello() {
        User user = new User();
        user.setName("lining");
        user.setPass("123456");


        return user;
    }
}
