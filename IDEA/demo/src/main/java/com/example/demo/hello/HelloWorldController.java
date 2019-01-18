package com.example.demo.hello;
import org.springframework.web.bind.annotation.RequestMapping;
import org.springframework.web.bind.annotation.RequestMethod;
import org.springframework.web.bind.annotation.RestController;

import java.util.ArrayList;
import java.util.List;

@RestController
public class HelloWorldController {

    @RequestMapping(value = "/hello",method = RequestMethod.GET)
    public String helloWorld(){
        List< String> name = new ArrayList();

        name.add("lining 1");
        name.add("lining 2");
        name.add("lining 3");
        return name.toString();
    }
}
