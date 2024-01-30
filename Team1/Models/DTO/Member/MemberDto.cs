using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Team1.Models.DTO.Member
{
	public class MemberDto
	{
		public int Id { get; set; }
		public string Account { get; set; }
		public string NewPassword { get; set; }
		public string EncryptedPassword { get; set; }
	}
}