using Microsoft.AspNetCore.SignalR.Client;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Admin
{
	public static class HubConnect
	{
		private static readonly HubConnection connection = new HubConnectionBuilder()
		.WithUrl("http://localhost:37590/notes")
		.Build();
		private static readonly Dictionary<string, IDisposable> handlers = new Dictionary<string, IDisposable>();
		public static HubConnection GetConnection()
		{
			return connection;
		}
		public static async Task Connect()
		{
			connection.Closed += async (error) =>
			{
				await connection.StartAsync();
			};
			try
			{
				await connection.StartAsync();
			}
			catch (Exception ex)
			{
				Console.Write(ex.Message);
			}
		}
		public static void On<T>(string methodName, Action<T> handler)
		{
			// Перевірка, чи існує вже обробник для цього методу
			if (handlers.ContainsKey(methodName))
			{
				// Якщо так, то він видаляється
				handlers[methodName].Dispose();
				handlers.Remove(methodName);
			}
			var disposable = connection.On(methodName, handler);
			handlers[methodName] = disposable;
		}
		public static void On<T1, T2, T3, T4, T5, T6>(string methodName, Action<T1, T2, T3, T4, T5, T6> handler)
		{
			// Перевірка, чи існує вже обробник для цього методу
			if (handlers.ContainsKey(methodName))
			{
				// Якщо так, то він видаляється
				handlers[methodName].Dispose();
				handlers.Remove(methodName);
			}
			var disposable = connection.On(methodName, handler);
			handlers[methodName] = disposable;
		}
		public static void Off(string methodName)
		{
			if (handlers.ContainsKey(methodName))
			{
				handlers[methodName].Dispose();
				handlers.Remove(methodName);
			}
		}
	}
}
