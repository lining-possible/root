import java.io.FileInputStream;
import java.util.Properties;
import app.SendMessageWS;
import app.TimerManager;
import java.io.*;

import app.Var;
import oracle.jdbc.driver.OracleDriver;
import java.sql.*;
import java.util.Properties;
import java.util.Calendar;
import java.util.Date;
import java.util.Timer;
public class main{


    public static void main(String[] args){
       //初始化变量  从配置文件读取
        Var.init();
        //启动定时任务
        TimerManager timerManager = new TimerManager();



    }



}
