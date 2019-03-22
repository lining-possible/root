import UDPServer.UDPServerThread;
import java.io.IOException;
import java.net.DatagramPacket;
import java.net.DatagramSocket;
import java.net.InetAddress;
import java.io.*;
import java.net.*;
public class test {

    public static void main(String[] args) throws Exception{
        System.out.println("java test runnning");
        DatagramSocket socket = new DatagramSocket(8888);
        System.out.println("server is running");
        while (true){
            UDPServerThread st = new UDPServerThread(socket);
            st.start();
        }
    }
}



/*import java.io.*;
        import java.net.*;

//创建客户端，向服务端发送数据，并接收反馈信息
class TCPClient
{
    public static void main(String[] args)throws Exception
    {
        //创建Socket服务
        Socket s = new Socket("10.22.72.144", 20005);

        //获取Socket中的输出流
        OutputStream out = s.getOutputStream();
        out.write("hello Server".getBytes());

        //接受从服务端的反馈信息
        InputStream in = s.getInputStream();
        byte[] buf = new byte[1024];
        int len = in.read(buf);
        System.out.println(new String(buf, 0, len));
        s.close();
    }
}

//创建服务端
class TCPServer
{
    public static void main(String[] args) throws Exception
    {
        //创建ServerSocket服务
        ServerSocket ss = new ServerSocket(20005);

        //获取客户端对象
        Socket s = ss.accept();

        //获取客户端IP
        String ip = s.getInetAddress().getHostAddress();
        System.out.println(ip +"..connected..");

        //通过Socket客户端输入流获取客户端数据
        InputStream in = s.getInputStream();
        byte[] buf = new byte[1024];
        int len = in.read(buf);
        String str = new String(buf, 0, len);
        System.out.println(ip +":"+str);

        //向客户端发送反馈信息
        OutputStream out = s.getOutputStream();
        out.write("hello client".getBytes());

        ss.close();
        s.close();
    }
}*/
