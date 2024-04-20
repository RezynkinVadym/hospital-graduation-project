using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Sockets;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;
using System.Threading;

namespace Admin
{
	abstract internal class NetworkClient
	{
		static Socket socket;
		public static string Result { get; private set; }

		static void ConnectToServer()
		{
			string name = Dns.GetHostName();
			IPAddress[] ipHostAddressList = Dns.GetHostEntry(name).AddressList;
			IPAddress ipAddr = ipHostAddressList[1];
			IPEndPoint ipEndPoint = new IPEndPoint(ipAddr, 11000);
			IPEndPoint localIP = new IPEndPoint(ipAddr, 0);

			socket = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
			socket.Bind(localIP);
			socket.Connect(ipEndPoint);
		}
		public static void SendQuery(object data)
		{
			ConnectToServer();
			try
			{
				socket.Send(Encoding.Unicode.GetBytes((string)data));
				byte[] buffer = new byte[1024];
				socket.Receive(buffer);
				Result = Encoding.Unicode.GetString(buffer).TrimEnd('\0');
			}
			catch(Exception ex)
			{
				Result = "Помилка: " + ex.Message;
			}
		}
		public static string GetAllPatients(string query) {
			ConnectToServer();
			try
			{
				socket.Send(Encoding.Unicode.GetBytes(query));
				byte[] buffer = new byte[80000];
				socket.Receive(buffer);
				string result = Encoding.Unicode.GetString(buffer).TrimEnd('\0');
				return result;
			}
			catch(Exception ex)
			{
				return "Помилка: " + ex.Message;
			}
		}
	}
}
