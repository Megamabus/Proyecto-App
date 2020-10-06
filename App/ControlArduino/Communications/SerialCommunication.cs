using System;
using System.Collections.Generic;
using System.IO.Ports;
using System.Linq;
using System.Web;

namespace DataCube.Server.Communications
{
    public static class SerialCommunication 
    {
        public static SerialPort serialConnection;

        public static void Inicialize()
        {
            serialConnection = new SerialPort("COM3",9600);
            serialConnection.Open();
            Console.WriteLine("Se ah iniciado el SerialPort.");
        }

        public static void Close()
        {
            if (serialConnection.IsOpen) 
                serialConnection.Close();
        }

        public static void Write(string data)
        {
            serialConnection.Write(data);
        }

        public static string ReadLine()
        {
            string lectura = serialConnection.ReadLine();
            return lectura ;
        }
    }
}