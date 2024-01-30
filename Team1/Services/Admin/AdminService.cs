using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Team1.InterFace.IRepositories.Admin;
using Team1.InterFace.Member;
using Team1.Models.Core.Entities.Admin;
using Team1.Models.DTO.Admin;
using Team1.Models.Exts.Admin;
using Team1.Models.Infra;
using Team1.Models.Repositories.Admins;
using Team1.Models.ViewModels.Admin;

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
			// 確認密碼字數是否在6~20之間
			if (dto.Password.Length < 6 && dto.Password.Length > 20) throw new Exception("密碼字數需介於6~20之間");
			// 檢查密碼是否包含大小寫英文字母，以及數字
			if (!dto.Password.Any(char.IsUpper) || !dto.Password.Any(char.IsLower) || !dto.Password.Any(char.IsDigit)) throw new Exception("密碼必須包含大小寫英文字母以及數字");
			// 使用 BCrypt 產生指定因子的鹽
			string salt = BCrypt.Net.BCrypt.GenerateSalt(12);
			// 使用 BCrypt 產生雜湊密碼
			string encryptedPassword = BCrypt.Net.BCrypt.HashPassword(dto.Password, salt);
			// 將雜湊密碼存入 dto
			dto.EncryptedPassword = encryptedPassword;

			// 為驗證信件產生驗證碼
			string verificationCode = Guid.NewGuid().ToString();
			// 將驗證碼存入 dto
			dto.VerificationCode = verificationCode;
			// 寄送驗證信件驗證信箱

			// 將信箱狀態設定為未驗證
			dto.IsEmailConfirmed = false;
			// 將帳號狀態設定為啟用
			dto.ActiveStatus = true;
			// 將註冊日期設定為現在時間
			dto.RegistrationDate = DateTime.Now;
			// 將 dto 轉換成 entity，並且透過Entity檢查資料正確性
			int newAdminId= 0;
			try
			{
				AdminEntity newAdmin = dto.ToEntity();
				// 呼叫 repo 建立新增管理員
				newAdminId = _repo.Create(newAdmin);
				
			}
			catch (Exception ex)
			{
				throw new Exception("資料有缺漏，請檢查傳入資料是否齊全");
			}
			var newAdminInDb = _repo.GetById(newAdminId);

			// 寄送確認信
			var urlTemplate = HttpContext.Current.Request.Url.Scheme + "://" +                          // 生成 http:// 或 https://
							  HttpContext.Current.Request.Url.Authority + "/" +                         // 生成網域名稱或 ip
							  "BEAdmins/ConfirmEmail?adminId={0}&verificationCode={1}";                           // 生成網頁 url
			var url = string.Format(urlTemplate, newAdminInDb.Id, newAdminInDb.VerificationCode);
			string name = newAdminInDb.Name;
			string email = newAdminInDb.Email;
			new AdminsEmailHelper().SendConfirmRegisterMail(url, name, email);

			return newAdminId;
		}


		public AdminDto GetById(int newAdminId)
		{
			return _repo.GetById(newAdminId).ToDto();
		}
	}
}