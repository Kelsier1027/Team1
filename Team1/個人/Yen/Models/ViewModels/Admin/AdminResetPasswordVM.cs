using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using Team1.Models.Infra;

namespace Team1.ViewModels.Admin
{
	public class AdminResetPasswordVM
	{
		[Display(Name = "新密碼")]
		[Required(ErrorMessage = DAHelper.Required)]
		[StringLength(20, MinimumLength = 6, ErrorMessage = DAHelper.StringLength2)]
		[DataType(DataType.Password)]
		public string Password { get; set; }

		[Display(Name = "確認密碼")]
		[Required(ErrorMessage = DAHelper.Required)]
		[StringLength(20, MinimumLength = 6, ErrorMessage = DAHelper.StringLength2)]
		[Compare(nameof(Password), ErrorMessage = DAHelper.Compare)]
		[DataType(DataType.Password)]
		public string ConfirmPassword { get; set; }
	}
}