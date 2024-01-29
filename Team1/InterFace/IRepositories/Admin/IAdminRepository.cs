using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Team1.Models.Core.Entities.Admin;

namespace Team1.InterFace.IRepositories.Admin
{
	public interface IAdminRepository
	{
		int Create(AdminEntity en);
		AdminEntity GetById(int id);
		bool CheckAccountExists(string account);
	}
}
