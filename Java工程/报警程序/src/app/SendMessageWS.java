package app;

import org.apache.axiom.om.OMAbstractFactory;
import org.apache.axiom.om.OMElement;
import org.apache.axiom.om.OMFactory;
import org.apache.axiom.om.OMNamespace;
import org.apache.axis2.AxisFault;
import org.apache.axis2.addressing.EndpointReference;
import org.apache.axis2.client.Options;
import org.apache.axis2.client.ServiceClient;


/**
 *
 * @Title: SendMessageWS.java
 * @Description: 发送短信
 * @author zhagnJie
 * @date 2014-8-8
 * @version V1.0
 *
 */
public class SendMessageWS {

    /**
     * 发送
     * @param telList  列表
     * @param text 文本
     * @return 发送成功
     */
    public static String sendMessage(String smsWsdl,String smsUser,String smsPws,String telList,String text)
    {
        /**
         * 接口
         */
        final String FINAL_STR_MES = "SendSMSOfInterface";


        try
        {
            ServiceClient sc = new ServiceClient();
            Options opts = new Options();
            EndpointReference end = new EndpointReference(smsWsdl);
            opts.setTo(end);
            opts.setAction(FINAL_STR_MES);
            sc.setOptions(opts);
            OMFactory fac = OMAbstractFactory.getOMFactory();
            OMNamespace omNs = fac.createOMNamespace("http://tempuri.org/", "");
            OMElement method = fac.createOMElement(FINAL_STR_MES,omNs);
            OMElement value1 = fac.createOMElement("UserName",omNs);
            value1.setText(smsUser);
            OMElement value2 = fac.createOMElement("PassWord",omNs);
            value2.setText(smsPws);

            OMElement value3 = fac.createOMElement("TelList",omNs);
            value3.setText(telList);
            OMElement value4 = fac.createOMElement("Content",omNs);
            value4.setText(text);

            method.addChild(value1);
            method.addChild(value2);
            method.addChild(value3);
            method.addChild(value4);
            OMElement res = sc.sendReceive(method);
            return res.getFirstElement().getText();
        }
        catch(AxisFault e){
            return "0";
        }
    }
}
