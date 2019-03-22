package UDPServer;

import java.io.IOException;
import java.net.DatagramPacket;
import java.net.DatagramSocket;
import java.net.InetAddress;
/* * 服务器线程处理类 */
public class UDPServerThread extends Thread {
    /* * 线程执行的操作，响应客户端的请求 */
    DatagramSocket socket = null;
    public UDPServerThread(DatagramSocket socket){
        this.socket = socket;
    }
    public void run(){
        while (true) {
            try {

                byte[] data = new byte[124];
                DatagramPacket packet = new DatagramPacket(data, data.length);
                socket.receive(packet);
                String info = new String(data, 0, packet.getLength());
                System.out.println("我是服务器，客户端说：" + info);
                Thread.sleep(500);
           /*  socket.receive(packet);
            String info = new String(data,0,packet.getLength());
            System.out.println("我是服务器，客户端说："+info);
           InetAddress address = packet.getAddress();
            int port = packet.getPort();
            byte[] data2= "welcome".getBytes();
            DatagramPacket packet2 = new DatagramPacket(data2,data2.length,address,port);
            socket.send(packet2);*/

            } catch (IOException e) {
                e.printStackTrace();
            }catch (InterruptedException e){
                e.printStackTrace();
            }
        }


    }

}