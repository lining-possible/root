package app;
import java.util.TimerTask;
import com.sun.istack.internal.logging.Logger;
import app.QueryAndSendMessage;
public class NFDFlightDataTimerTask extends TimerTask {

    private static Logger log = Logger.getLogger(NFDFlightDataTimerTask.class);

    @Override
    public void run() {
        try {
            // 在这里写你要执行的内容
            System.out.println("执行定时任务.................");
            QueryAndSendMessage queryAndSendMessage = new QueryAndSendMessage();
            queryAndSendMessage.sendMSM();

        } catch (Exception e) {
            log.info("-------------解析信息发生异常--------------");
        }
    }
}