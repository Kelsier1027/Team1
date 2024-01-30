using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Team1.Models.DTO.Member
{
	public class MembershipLevelDto
	{
		public int Id { get; set; }
		public char LevelName { get; set; }
		public string Description { get; set; }
	}
}