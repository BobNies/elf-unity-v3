using UnityEngine;
using System.Collections;
using System;
using System.IO;
using System.Net.Sockets;

// https://stackoverflow.com/questions/50818491/unity3d-to-raspberry-pi-server-connection-failed-to-respond
// https://stackoverflow.com/questions/38816660/sending-data-from-unity-to-raspberry

public class UnityToRaspberry : MonoBehaviour
{

    bool socketReady = false;
    TcpClient mySocket;
    public NetworkStream theStream;
    StreamWriter theWriter;
    StreamReader theReader;
    public String Host = "192.168.3.232";
    public Int32 Port = 5005;

    void Start()
    {
        setupSocket();
    }


    public void setupSocket()
    {                            // Socket setup here
        try
        {
            mySocket = new TcpClient(Host, Port);
            theStream = mySocket.GetStream();
            theWriter = new StreamWriter(theStream);
            theReader = new StreamReader(theStream);
            socketReady = true;
        }
        catch (Exception e)
        {
            Debug.Log("Socket error:" + e);                // catch any exceptions
        }
    }

    public void SendMessage(string message)
    {
        if (socketReady == true)
        {
            theWriter.Write(message);
            theWriter.Flush();
        }
    }

}