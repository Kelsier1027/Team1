using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Team1.Models.DTO.Member
{
	public class MemberProfileDto
	{
		public int Id { get; set; }
		public int MemberId { get; set; }
		public string Email { get; set; }
		public string FirstName { get; set; }
		public string LastName { get; set; }
		public string Gender { get; set; }
		public DateTime RegistrationDate { get; set; }
		public string ProfileImage { get; set; }
		public int Level { get; set; }
		public int? TotalConsumption { get; set; }
		public bool ActiveStatus { get; set; }
		public DateTime LastLogin { get; set; }
		public decimal PointPercentage { get; set; }
		public int PointBalance { get; set; }
	}
}