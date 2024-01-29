using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Team1.Models.ViewModels.Admin
{
	public class CreateAdminVm
	{
		public int Id { get; set; }

		[Required]
		[Display(Name = "帳號")]
		[StringLength(20)]
		public string Account { get; set; }

		// 長度限制為 6~20 個字元，且至少包含一個英文字母及一個數字

		[Required]
		[StringLength(20, MinimumLength = 6, ErrorMessage = "密碼長度必須在6到20個字符之間")]
		[RegularExpression(@"^(?=.*[A-Za-z])(?=.*\d)[A-Za-z\d]{6,20}$", ErrorMessage = "密碼必須包含至少一個英文字母和一個數字")]
		[Display(Name = "密碼")]
		[DataType(DataType.Password)]
		public string Password { get; set; }

		[Required]
		[Display(Name = "確認密碼")]
		[DataType(DataType.Password)]
		[Compare("Password")]
		public string ConfirmPassword { get; set; }


		[Required]
		[Display(Name = "電子郵件")]
		[EmailAddress]
		[StringLength(256)]
		public string Email { get; set; }

		[Required]
		[Display(Name = "姓名")]
		[StringLength(40)]
		public string Name { get; set; }

	}
}