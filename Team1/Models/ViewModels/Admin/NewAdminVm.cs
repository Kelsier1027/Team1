using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Runtime.InteropServices;
using System.Web;

namespace Team1.Models.ViewModels.Admin
{
	public class NewAdminVm
	{
		[Display(Name = "管理員編號")]
		public int Id { get; set; }

		[Display(Name = "帳號")]
		public string Account { get; set; }

		[Display(Name = "姓名")]
		public string Name { get; set; }

		[Display(Name = "電子郵件")]
		public string Email { get; set; }
	}
}