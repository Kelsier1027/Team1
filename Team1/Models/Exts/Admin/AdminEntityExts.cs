using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Team1.Models.Core.Entities.Admin;
using Team1.Models.DTO.Admin;
using Team1.Models.EFModels;

namespace Team1.Models.Exts.Admin
{
	public static class AdminEntityExts
	{
		public static BEAdmin ToEFModels(this AdminEntity en)
		{
			return new BEAdmin()
			{
				Id = en.Id,
				Account = en.Account,
				EncryptedPassword = en.EncryptedPassword,
				Email = en.Email,
				Name = en.Name,
				RegistrationDate = en.RegistrationDate,
				ActiveStatus = en.ActiveStatus,
				Salt = en.Salt
			};
		}

		public static AdminDto ToDto(this AdminEntity en)
		{
			return new AdminDto()
			{
				Id = en.Id,
				Account = en.Account,
				EncryptedPassword = en.EncryptedPassword,
				Email = en.Email,
				Name = en.Name,
				RegistrationDate = en.RegistrationDate,
				ActiveStatus = en.ActiveStatus,
				Salt = en.Salt
			};
		}
	}
}