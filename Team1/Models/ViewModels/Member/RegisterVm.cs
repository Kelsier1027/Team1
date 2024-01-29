using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Team1.Models.ViewModels.Member
{
	public class RegisterVm
	{
		// 會員註冊用 ViewModel
		public int Id { get; set; }

		[Display(Name = "帳號")]
		[Required]
		[StringLength(30)]
		public string Account { get; set; }

		/// <summary>
		/// 明碼
		/// </summary>
		[Display(Name = "密碼")]
		[Required]
		[StringLength(50)]
		[DataType(DataType.Password)]
		public string NewPassword { get; set; }

		[Display(Name = "確認密碼")]
		[Required]
		[StringLength(50)]
		[Compare(nameof(NewPassword))]
		[DataType(DataType.Password)]
		public string ConfirmPassword { get; set; }

	}
}