using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Team1.InterFace.IRepositories.Admin;
using Team1.Models.Core.Entities.Admin;
using Team1.Models.EFModels;
using Team1.Models.Exts.Admin;

namespace Team1.Models.Repositories.Admins
{
	public class AdminEFRepository: IAdminRepository
	{
		public int Create(AdminEntity en)
		{
			var db = new AppDbContext();
			BEAdmin model = en.ToEFModels();
			db.BEAdmins.Add(model);
			db.SaveChanges();
			return model.Id;
		}

		public AdminEntity GetById(int id)
		{
			AppDbContext db = new AppDbContext();
			return db.BEAdmins.FirstOrDefault(p => p.Id == id).ToEntity();
		}

		public bool CheckAccountExists(string account)
		{
			AppDbContext db = new AppDbContext();
			return db.BEAdmins.Any(p => p.Account == account);
		}

	}
}