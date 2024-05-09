using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Server
{
	public static class DataFirstStepRegistration
	{
		private static readonly List<DTOFirstStepRegistration> dataList = [];
		public static void SaveUserData(string ID, string firstName, string lastName, string email, char sex, DateTime dateOfBirth) {
			DTOFirstStepRegistration dto = new()
			{
				ID = ID,
				FirstName = firstName,
				LastName = lastName,
				Email = email,
				Sex = sex,
				DateOfBirth = dateOfBirth
			};
			if (dataList.Any(x => x.ID == ID))//один і той же користувач може проходити перший крок реєстрації кілька разів, тоді перші введені дані можна вважати не актуальними
				ClearUserDataByID(ID);
			dataList.Add(dto);
		}

		public static DTOFirstStepRegistration GetUserDataByID(string ID)
		{
			DTOFirstStepRegistration dto = dataList.Find(x => x.ID == ID);
			return dto;
		}

		public static void ClearUserDataByID(string ID)
		{
			dataList.Remove(GetUserDataByID(ID));
		}

	}
}
