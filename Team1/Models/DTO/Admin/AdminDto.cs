using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Team1.Models.DTO.Admin
{
	public class AdminDto
	{
		public int Id { get; set; }

		public string Account { get; set; }

		public string Password { get; set; }

		public string ConfirmPassword { get; set; }

		public string EncryptedPassword { get; set; }

		public string Email { get; set; }

		public string Name { get; set; }

		public DateTime RegistrationDate { get; set; }

		public bool ActiveStatus { get; set; }

		public string VerificationCode { get; set; }
	}
}