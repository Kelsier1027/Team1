using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Team1.Models.Core.Entities.Admin;
using Team1.Models.DTO.Admin;
using Team1.Models.ViewModels.Admin;

namespace Team1.Models.Exts.Admin
{
	public static class AdminDtoExts
	{
		public static AdminEntity ToEntity(this AdminDto dto)
		{
			return new AdminEntity(
				dto.Id,
				dto.Account,
				dto.EncryptedPassword,
				dto.Email,
				dto.Name,
				dto.RegistrationDate,
				dto.ActiveStatus,
				dto.VerificationCode
			);
		}
		public static NewAdminVm ToNewAdminVm(this AdminDto dto)
		{
			return new NewAdminVm()
			{
				Id = dto.Id,
				Account = dto.Account,
				Email = dto.Email,
				Name = dto.Name
			};
		}
	}
}