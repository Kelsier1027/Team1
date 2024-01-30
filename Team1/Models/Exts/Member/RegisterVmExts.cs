using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Team1.Models.DTO.Member;
using Team1.Models.ViewModels.Member;

namespace Team1.Models.Exts.Member
{
	public static class RegisterVmExts
	{
		public static MemberDto ToDto(this RegisterVm vm)
		{
			return new MemberDto()
			{
				Id = vm.Id,
				Account = vm.Account,
				NewPassword = vm.NewPassword
			};

		}
	}
}