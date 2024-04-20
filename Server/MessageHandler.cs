using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net.Sockets;
using MySqlX.XDevAPI.Common;

namespace Server
{
	internal class MessageHandler
	{
		Socket clientSocket;
		string[] data;
		public MessageHandler(object socket)
		{
			clientSocket = (Socket)socket;
		}
		public void GetMessage()
		{
			try
			{
				byte[] buffer = new byte[1024];
				clientSocket.Receive(buffer);
				string dataString = Encoding.Unicode.GetString(buffer).TrimEnd('\0');
				data = dataString.Split(';');
				if (data[0] != "patient")
					SendDataAdmin();
				else
					SendDataPatient();
			}
			catch(Exception ex)
			{
				Console.WriteLine("Error: " + ex.Message);
				clientSocket.Send(Encoding.Unicode.GetBytes("Error: " + ex.Message));
			}

		}
		void SendDataAdmin()
		{
			DBQuery dBAdminQuery = new DBQuery();
			string result = "Can`t execute query";//залишиться таким же якщо неправильний запит
			if (data[0] == "registration")
			{
				DateTime birth = DateTime.Parse(data[4]);
				result = dBAdminQuery.Registration(data[1], data[2], data[3], birth, Char.Parse(data[5]), data[6], data[7]);
			}
			else if (data[0] == "signIn")
				result = dBAdminQuery.SignIn(data[1], data[2]);
			else if (data[0] == "edit")
			{
				DateTime birth = DateTime.Parse(data[5]);
				result = dBAdminQuery.Edit(data[1], data[2], data[3], data[4], birth, Char.Parse(data[6]));
			}
			clientSocket.Send(Encoding.Unicode.GetBytes(result));
		}
		void SendDataPatient()
		{
			DBQuery dBPatientQuery = new DBQuery();
			string result = "Can`t execute query";//залишиться таким же якщо неправильний запит
			if (data[1] == "add")
			{
				DateTime birth = DateTime.Parse(data[4]);
				result = dBPatientQuery.AddPatient(data[2], data[3], birth, data[5], data[6]);
			}
			else if (data[1] == "get")
			{
				result = dBPatientQuery.GetAllPatients();
			}
			else if (data[1] == "delete")
				result = dBPatientQuery.DeletePatient(Int32.Parse(data[2]));
			else if (data[1] == "edit")
			{
				DateTime birth = DateTime.Parse(data[5]);
				int idToEdit = Int32.Parse(data[2]);
				result = dBPatientQuery.EditPatient(idToEdit, data[3], data[4], birth, data[6], data[7]);
			}

			clientSocket.Send(Encoding.Unicode.GetBytes(result));
		}
	}
}
