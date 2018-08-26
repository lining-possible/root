package app;

import java.io.BufferedInputStream;
import java.io.FileInputStream;
import java.io.InputStream;
import java.util.Properties;

public class Var {
    private static final String PROPERTIES_NAME = "config.properties";
    public static String   smsWsdl ="";
    public static String   smsUser ="";
    public static String   smsPws  ="";
    public static String   telList ="";
    public static String  url="";
    public static String   user="";
    public static String  password="";
    public static void init(){
        //读取配置文件
        String property = System.getProperty("user.dir");
        //System.out.println(property);
        InputStream in = null;
        try {
            Properties properties = new Properties();
            //config.properties 和 jar包放到同一个目录下
            in = new BufferedInputStream(new FileInputStream(property + "\\config.properties"));
            properties.load(in);
            smsWsdl = properties.getProperty("smsWsdl");
            smsUser = properties.getProperty("smsUser");
            smsPws = properties.getProperty("smsPws");
            telList = properties.getProperty("telList");
            url = properties.getProperty("url");
            user = properties.getProperty("user");
            password = properties.getProperty("password");
            System.out.println("读取配置信息成功！");
        } catch (Exception e) {
            e.printStackTrace();
            System.out.println("读取配置信息失败！");
        } finally {
            if (in != null) {
                try {
                    in.close();
                } catch (Exception e) {
                    e.printStackTrace();
                }
            }
        }
    }
}
