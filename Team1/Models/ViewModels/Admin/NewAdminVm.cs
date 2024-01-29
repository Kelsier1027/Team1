using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Team1.Models.ViewModels.Admin
{
	public class NewAdminVm
	{
		public int Id { get; set; }
		public string Account { get; set; }
		public string Name { get; set; }
		public string Email { get; set; }
	}
}