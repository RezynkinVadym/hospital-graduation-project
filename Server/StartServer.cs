using Server;
using System.Net;
using System.Net.Sockets;
using System.Text;

Socket serverSocket;
StartServer();
Console.WriteLine("Сервер працює");
try
{
	while (true)//сервер постійно приймає запит на підключення від клієнтів та передає їх класу для прийому повідомлень
	{
		Socket clientSocket = serverSocket.Accept();
		MessageHandler handler = new MessageHandler(clientSocket);
		new Thread(handler.GetMessage).Start();
	}
}
catch (Exception e)
{
	Console.WriteLine(e.ToString());
}
void StartServer()
{
	string hostName = Dns.GetHostName();
	IPAddress[] ipHostAddressList = Dns.GetHostEntry(hostName).AddressList;
	IPAddress ipAddr = ipHostAddressList[1];
	IPEndPoint ipEndPoint = new IPEndPoint(ipAddr, 11000);

	serverSocket = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
	serverSocket.Bind(ipEndPoint);
	serverSocket.Listen();
}