package app;

import java.io.BufferedInputStream;
import java.io.FileInputStream;
import java.io.InputStream;
import java.sql.*;
import java.text.SimpleDateFormat;
import java.util.Properties;
import java.io.FileInputStream;
import java.util.Properties;
import app.SendMessageWS;
import app.TimerManager;
import java.io.*;
import oracle.jdbc.driver.OracleDriver;
import java.sql.*;
import java.util.Properties;
import java.util.Calendar;
import java.util.Date;
import java.util.Timer;

public class QueryAndSendMessage {

    public String Data2Str(Calendar c){
        int   year   =   c.get(Calendar.YEAR);
        //一般month都需要+1才表示当前月份
        int   month   =   c.get(Calendar.MONTH);
        int   date   =   c.get(Calendar.DATE);
        int   hour   =   c.get(Calendar.HOUR_OF_DAY);
        int   minute   =   c.get(Calendar.MINUTE);
        int   second   =   c.get(Calendar.SECOND);
        String nowTime = year + "/" + month + "/" + date + " " +hour + ":" + minute + ":" + second;
        return nowTime;
    }
    public void sendMSM()
    {

        //连接数据库读取数据
        String driver = "oracle.jdbc.OracleDriver";    //驱动标识符
        //String url = "jdbc:oracle:thin:@localhost:1521:orcl"; //链接字符串
        String url = Var.url;
        String user = Var.user;         //数据库的用户名
        String password = Var.password;     //数据库的密码
        Connection con = null;
        PreparedStatement pstm = null;
        ResultSet rs = null;
        boolean flag = false;
        String MSMTEXT_YT = "烟台报警气体";
        String MSMTEXT_NB = "宁波报警气体";
        String MSMTEXT_T = "";
        try {

            //String sql = "select * from sm_role";
            String sql = "SELECT count(*) as num FROM bt_alarm_auto bt where bt.receive_time > to_date('2018-05-01 13:14:20','yyyy-MM-dd HH24:mi:ss')  and bt.receive_time < to_date('2018-06-01 13:14:20','yyyy-MM-dd HH24:mi:ss')  and bt.unit_code='10'";

            Date cur = new Date();
            SimpleDateFormat sdf = new SimpleDateFormat("yyyy-MM-dd HH:mm:ss");
            String nowtime = sdf.format(cur);

            Calendar curDate = Calendar.getInstance();
            curDate.setTime(cur);
            curDate.add(Calendar.HOUR,-8);
            Date cur2 = curDate.getTime();
            String nowtime8=sdf.format(cur2);
            curDate.add(Calendar.HOUR,-8);
            Date cur3 = curDate.getTime();
            String nowtime16=sdf.format(cur3);
            curDate.add(Calendar.HOUR,-8);
            Date cur4 = curDate.getTime();
            String nowtime24=sdf.format(cur4);



            String sqlmesYT1 = "SELECT count(*) as num FROM bt_alarm_auto bt where bt.receive_time > to_date('"+ nowtime24+"','yyyy-MM-dd HH24:mi:ss')  and bt.receive_time < to_date('"+nowtime16+"','yyyy-MM-dd HH24:mi:ss')  and bt.unit_code='10' and ALARM_TYPE='1'";
            String sqlmesYT2 = "SELECT count(*) as num FROM bt_alarm_auto bt where bt.receive_time > to_date('"+ nowtime16+"','yyyy-MM-dd HH24:mi:ss')  and bt.receive_time < to_date('"+nowtime8+"','yyyy-MM-dd HH24:mi:ss')  and bt.unit_code='10' and ALARM_TYPE='1'";
            String sqlmesYT3 = "SELECT count(*) as num FROM bt_alarm_auto bt where bt.receive_time > to_date('"+ nowtime8+"','yyyy-MM-dd HH24:mi:ss')  and bt.receive_time < to_date('"+nowtime+"','yyyy-MM-dd HH24:mi:ss')  and bt.unit_code='10' and ALARM_TYPE='1'";
            String sqlfireYT1 = "SELECT count(*) as num FROM bt_alarm_auto bt where bt.receive_time > to_date('"+ nowtime24+"','yyyy-MM-dd HH24:mi:ss')  and bt.receive_time < to_date('"+nowtime16+"','yyyy-MM-dd HH24:mi:ss')  and bt.unit_code='10' and ALARM_TYPE='2'";
            String sqlfireYT2 = "SELECT count(*) as num FROM bt_alarm_auto bt where bt.receive_time > to_date('"+ nowtime16+"','yyyy-MM-dd HH24:mi:ss')  and bt.receive_time < to_date('"+nowtime8+"','yyyy-MM-dd HH24:mi:ss')  and bt.unit_code='10' and ALARM_TYPE='2'";
            String sqlfireYT3 = "SELECT count(*) as num FROM bt_alarm_auto bt where bt.receive_time > to_date('"+ nowtime8+"','yyyy-MM-dd HH24:mi:ss')  and bt.receive_time < to_date('"+nowtime+"','yyyy-MM-dd HH24:mi:ss')  and bt.unit_code='10' and ALARM_TYPE='2'";
            String sqlmesNB1 = "SELECT count(*) as num FROM bt_alarm_auto bt where bt.receive_time > to_date('"+ nowtime24+"','yyyy-MM-dd HH24:mi:ss')  and bt.receive_time < to_date('"+nowtime16+"','yyyy-MM-dd HH24:mi:ss')  and bt.unit_code='11' and ALARM_TYPE='1'";
            String sqlmesNB2 = "SELECT count(*) as num FROM bt_alarm_auto bt where bt.receive_time > to_date('"+ nowtime16+"','yyyy-MM-dd HH24:mi:ss')  and bt.receive_time < to_date('"+nowtime8+"','yyyy-MM-dd HH24:mi:ss')  and bt.unit_code='11' and ALARM_TYPE='1'";
            String sqlmesNB3 = "SELECT count(*) as num FROM bt_alarm_auto bt where bt.receive_time > to_date('"+ nowtime8+"','yyyy-MM-dd HH24:mi:ss')  and bt.receive_time < to_date('"+nowtime+"','yyyy-MM-dd HH24:mi:ss')  and bt.unit_code='11' and ALARM_TYPE='1'";
            String sqlfireNB1 = "SELECT count(*) as num FROM bt_alarm_auto bt where bt.receive_time > to_date('"+ nowtime24+"','yyyy-MM-dd HH24:mi:ss')  and bt.receive_time < to_date('"+nowtime16+"','yyyy-MM-dd HH24:mi:ss')  and bt.unit_code='11' and ALARM_TYPE='2'";
            String sqlfireNB2 = "SELECT count(*) as num FROM bt_alarm_auto bt where bt.receive_time > to_date('"+ nowtime16+"','yyyy-MM-dd HH24:mi:ss')  and bt.receive_time < to_date('"+nowtime8+"','yyyy-MM-dd HH24:mi:ss')  and bt.unit_code='11' and ALARM_TYPE='2'";
            String sqlfireNB3 = "SELECT count(*) as num FROM bt_alarm_auto bt where bt.receive_time > to_date('"+ nowtime8+"','yyyy-MM-dd HH24:mi:ss')  and bt.receive_time < to_date('"+nowtime+"','yyyy-MM-dd HH24:mi:ss')  and bt.unit_code='11' and ALARM_TYPE='2'";

/*            while (rs.next()) {
                String id = rs.getString("id");
                String creator = rs.getString("creator");
                System.out.println(id + "\t" + creator + "\t");
            }*/
            Class.forName(driver);
            con = DriverManager.getConnection(url, user, password);
            pstm = con.prepareStatement(sqlmesYT1);
            rs = pstm.executeQuery();
            while (rs.next()) {MSMTEXT_YT=MSMTEXT_YT+rs.getInt("num")+"/";  }
            pstm = con.prepareStatement(sqlmesYT2);
            rs = pstm.executeQuery();
            while (rs.next()) {MSMTEXT_YT=MSMTEXT_YT+rs.getInt("num")+"/";  }
            pstm = con.prepareStatement(sqlmesYT3);
            rs = pstm.executeQuery();
            while (rs.next()) {MSMTEXT_YT=MSMTEXT_YT+rs.getInt("num");  }
            MSMTEXT_YT=MSMTEXT_YT+"火灾";
            pstm = con.prepareStatement(sqlfireYT1);
            rs = pstm.executeQuery();
            while (rs.next()) {MSMTEXT_YT=MSMTEXT_YT+rs.getInt("num")+"/";  }
            pstm = con.prepareStatement(sqlfireYT2);
            rs = pstm.executeQuery();
            while (rs.next()) {MSMTEXT_YT=MSMTEXT_YT+rs.getInt("num")+"/";  }
            pstm = con.prepareStatement(sqlfireYT3);
            rs = pstm.executeQuery();
            while (rs.next()) {MSMTEXT_YT=MSMTEXT_YT+rs.getInt("num");  }
            //System.out.println(MSMTEXT_YT);

            pstm = con.prepareStatement(sqlmesNB1);
            rs = pstm.executeQuery();
            while (rs.next()) {MSMTEXT_NB=MSMTEXT_NB+rs.getInt("num")+"/";  }
            pstm = con.prepareStatement(sqlmesNB2);
            rs = pstm.executeQuery();
            while (rs.next()) {MSMTEXT_NB=MSMTEXT_NB+rs.getInt("num")+"/";  }
            pstm = con.prepareStatement(sqlmesNB3);
            rs = pstm.executeQuery();
            while (rs.next()) {MSMTEXT_NB=MSMTEXT_NB+rs.getInt("num");  }
            MSMTEXT_NB=MSMTEXT_NB+"火灾";
            pstm = con.prepareStatement(sqlfireNB1);
            rs = pstm.executeQuery();
            while (rs.next()) {MSMTEXT_NB=MSMTEXT_NB+rs.getInt("num")+"/";  }
            pstm = con.prepareStatement(sqlfireNB2);
            rs = pstm.executeQuery();
            while (rs.next()) {MSMTEXT_NB=MSMTEXT_NB+rs.getInt("num")+"/";  }
            pstm = con.prepareStatement(sqlfireNB3);
            rs = pstm.executeQuery();
            while (rs.next()) {MSMTEXT_NB=MSMTEXT_NB+rs.getInt("num");  }
            //System.out.println(MSMTEXT_NB);
            MSMTEXT_T = nowtime;
            flag = true;
        } catch (ClassNotFoundException e) {
            e.printStackTrace();
        } catch (SQLException e) {
            e.printStackTrace();
        } finally {
            if (rs != null) {
                try {
                    rs.close();
                } catch (SQLException e) {
                    e.printStackTrace();
                }
            }
            // 关闭执行通道
            if (pstm != null) {
                try {
                    pstm.close();
                } catch (SQLException e) {
                    e.printStackTrace();
                }
            }
            // 关闭连接通道
            try {
                if (con != null && (!con.isClosed())) {
                    try {
                        con.close();
                    } catch (SQLException e) {
                        e.printStackTrace();
                    }
                }
            } catch (SQLException e) {
                e.printStackTrace();
            }
        }
        if (flag) {
            //System.out.println("数据库查询执行成功！");
        } else {
            System.out.println("数据库查询执行失败！");
        }
        //短信通知
        String text = MSMTEXT_YT+"  "+MSMTEXT_NB+"  时间:"+MSMTEXT_T;
        System.out.println("发送短信："+text);
        //System.out.println(Var.smsWsdl+Var.smsUser+Var.smsPws+Var.telList+text);
        String rst = SendMessageWS.sendMessage(Var.smsWsdl,Var.smsUser,Var.smsPws,Var.telList,text);
        // String rst = SendMessageWS.sendMessage(smsWsdl,smsUser,smsPws,telList,text);
        //System.out.println(rst);
    }
}