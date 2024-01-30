﻿using Microsoft.Ajax.Utilities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Team1.Models.Core.Entities.Admin;
using Team1.Models.EFModels;
using Team1.Models.ViewModels.Admin;

namespace Team1.Models.Exts.Admin
{
	public static class BEAdminExts
	{
		// EFModel-BEAdmin 擴充方法，用來轉換成 AdminEntity
		public static AdminEntity ToEntity(this BEAdmin model)
		{
			return new AdminEntity(
				model.Id,
				model.Account,
				model.EncryptedPassword,
				model.Email,
				model.Name,
				model.RegistrationDate,
				model.ActiveStatus,
				model.IsEmailConfirmed,
				model.VerificationCode
																																							);
		}

		// EFModel-BEAdmin 擴充方法，用來轉換成 ToEditProfileVm
		public static EditAdminProfileVm ToEditProfileVm(this BEAdmin model)
		{
			return new EditAdminProfileVm
			{
				Id = model.Id,
				Email = model.Email,
				Name = model.Name
			};
		}
	}
}