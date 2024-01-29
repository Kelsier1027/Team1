using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Team1.Models.DTO.Admin;
using Team1.Models.ViewModels.Admin;

namespace Team1.Models.Exts.Admin
{
	public static class CreateAdminVmExts
	{
		public static AdminDto ToDto(this CreateAdminVm vm)
		{
			return new AdminDto()
			{
				Account = vm.Account,
				Email = vm.Email,
				Name = vm.Name,
				Password = vm.Password
			};
		}
	}
}