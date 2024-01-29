using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Team1.Models.DTO.Member
{
	public class MemberPersonalInfoDto
	{
		public int Id { get; set; }
		public int MemberID { get; set; }
		public string IDNumber { get; set; }
		public DateTime? BirthDate { get; set; }
		public string PhoneNumber { get; set; }
		public string Address { get; set; }
		public string EmCName { get; set; }
		public string EmCPhone { get; set; }
	}
}