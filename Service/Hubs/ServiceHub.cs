using Microsoft.AspNetCore.SignalR;
using SharedLibrary.Validation;
namespace Service.Hubs
{
	public partial class ServiceHub : Hub
	{
		StringValidation validation = new StringValidation();
		public override async Task OnConnectedAsync()
		{
			Console.WriteLine("Клiєнт " + Context.ConnectionId + " пiдключився");
			await base.OnConnectedAsync();
		}
	}
}
