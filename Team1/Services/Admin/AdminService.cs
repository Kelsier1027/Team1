using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Team1.InterFace.IRepositories.Admin;
using Team1.InterFace.Member;
using Team1.Models.Core.Entities.Admin;
using Team1.Models.DTO.Admin;
using Team1.Models.Exts.Admin;
using Team1.Models.Repositories.Admins;

namespace Team1.Services.Admin
{
	public class AdminService
	{
		private IAdminRepository _repo;

		public AdminService()
		{
			_repo = new AdminEFRepository();
		}

		public AdminService(IAdminRepository repo)
		{
			_repo = repo;
		}

		public int Create(AdminDto dto)
		{
			// 確認是否有重複的帳號
			if (_repo.CheckAccountExists(dto.Account)) throw new Exception("帳號已存在");
			
			// 確認密碼是否一致
			if (dto.Password != dto.ConfirmPassword) throw new Exception("密碼不一致");

			// 確認密碼是否符合規則
			if (dto.Password.Length < 6) throw new Exception("密碼長度不足");

			

			// 將 dto 轉換成 entity
			AdminEntity newAdmin = dto.ToEntity();

			// 呼叫 repo 建立新增管理員
			int newAdminId = _repo.Create(newAdmin);
			return newAdminId;
		}


		public AdminDto GetById(int newAdminId)
		{
			return _repo.GetById(newAdminId).ToDto();
		}
	}
}