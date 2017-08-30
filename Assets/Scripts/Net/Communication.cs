using System.Net;
using System.Text;
using UnityEngine;

//通讯类
public class Communication {

    private static SuperClient client;
    private const string terminateString = "\r\n";
    public bool Init()
    {
        client = new SuperClient();
        IPAddress ip = IPAddress.Parse("127.0.0.1");
        client.Init(new IPEndPoint(ip, 7777));
        return client.Connect;
    }

    public void Close()
    {
        if (client != null)
            client.Close();
    }


    public bool ReConnect()
    {
        Close();
        return Init();
    }

    public static bool IsConnect
    {
        get {
            if (client != null)
                return client.Connect;
            return false;
        }
    }

    public static void SendMessage(string command, string body)
    {
        if (IsConnect)
        {
            Debug.Log("SendMessage Success");
            string message = command + " " + body + terminateString;
            byte[] buff = Encoding.UTF8.GetBytes(message);
            client.Send(buff);
        }
    }


}
