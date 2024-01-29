using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Team1.Models.DTO.Member
{
	public class DiscountsForEachLevelDto
	{
		public int Id { get; set; }
		public int MembershipLevel { get; set; }
		public string TransactionCategory { get; set; }
		public decimal DiscountRate { get; set; }
	}
}