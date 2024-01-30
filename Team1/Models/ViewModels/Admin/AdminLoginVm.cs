using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Team1.Models.ViewModels.Admin
{
	public class AdminLoginVm
	{
		[Display(Name = "帳號")]
		[Required(ErrorMessage = "請輸入帳號")]
		public string Account { get; set; }

		[Display(Name = "密碼")]
		[Required(ErrorMessage = "請輸入密碼")]
		public string Password { get; set; }
	}
}