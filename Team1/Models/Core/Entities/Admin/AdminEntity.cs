using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using Team1.Models.DTO.Admin;
using Team1.Models.EFModels;

namespace Team1.Models.Core.Entities.Admin
{
	public class AdminEntity
	{
		public AdminEntity(int id, string account, string encryptedPassword, string email, string name, DateTime registrationDate, bool activeStatus,bool isEmailConfirmed, string verificationCode)
		{
			
			Id = id;
			Account = account;
			EncryptedPassword = encryptedPassword;
			Email = email;
			Name = name;
			RegistrationDate = registrationDate;
			ActiveStatus = activeStatus;
			IsEmailConfirmed = isEmailConfirmed;
			VerificationCode = verificationCode;
		}

		public int Id { get; set; }

		[Required]
		[StringLength(20)]
		public string Account { get; set; }

		[Required]
		public string EncryptedPassword { get; set; }

		[Required]
		[StringLength(256)]
		public string Email { get; set; }

		[Required]
		[StringLength(40)]
		public string Name { get; set; }

		[Required]
		public DateTime RegistrationDate { get; set; }

		[Required]
		public bool ActiveStatus { get; set; }

		[Required]
		public bool IsEmailConfirmed { get; set; }

		
		public string VerificationCode { get; set; }
	}

}