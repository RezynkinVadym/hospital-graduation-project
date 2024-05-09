using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Server.Interfaces
{
	public interface IRepositoryUser<User>
	{
		void Add(User entity);
		void Update(User entity);
		void Delete(User entity);
		User GetByLogin(string login);
	}
}
