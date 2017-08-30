using UnityEngine;
using SuperSocket.ClientEngine;
using SuperSocket.ProtoBase;
using System;
using System.Net;
using System.Text;

public class SuperClient
{
    EasyClient client;
    public void Init(IPEndPoint iep)
    {
        client = new EasyClient();
        client.Initialize(new MyReceiveFilter(), HandlePackage);
        //IPAddress ip = IPAddress.Parse("127.0.0.1");
        //client.BeginConnect(new IPEndPoint(ip, 7777));
        client.BeginConnect(iep);
        client.Connected += new System.EventHandler(client_Connected);
        client.Closed += new System.EventHandler(client_Closed);
        client.Error += new EventHandler<ErrorEventArgs>(client_Error);
    }

    public void Send(byte[] info) {
        client.Send(info);
    }

    public bool Connect {
        get {
            if (client != null)
                return client.IsConnected;
            else
                return false;
        }
    }
    protected void HandlePackage(IPackageInfo package)
    {
        Debug.Log("HandlePackage........................");
        StringPackageInfo spi = package as StringPackageInfo;
        if (spi != null) {
            Debug.Log("Key:"+spi.Key+" body:"+spi.Body);
            switch (spi.Key) {
               
            }
        }
    }

    void client_Connected(object sender, EventArgs e)
    {
        Debug.Log("client_Connected");
    }

    void client_Closed(object sender, EventArgs e)
    {
        Debug.Log("client_Closed");
    }

    void client_Error(object sender, ErrorEventArgs e)
    {
        Debug.Log("client_Error");
    }

    public void Close() {
        if (client != null)
            client.Close();
    }

}
