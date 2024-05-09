using SharedLibrary;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Server.Interfaces
{
	public interface IRepositoryPatient<Patient>
	{
		Patient Add(Patient entity);
		void Update(Patient entity);
		void Delete(long id);
		Patient GetByID(long id);
		List<Patient> GetAll();
	}
}
