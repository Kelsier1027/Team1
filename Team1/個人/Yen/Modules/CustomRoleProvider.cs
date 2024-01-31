using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Security;
using Team1.Models.EFModels;

namespace Team1.個人.Yen.Modules
{

	public class CustomRoleProvider : RoleProvider
	{
		private AppDbContext db = new AppDbContext();
		/// <summary>
		/// 取得所設定 applicationName 之指定使用者所屬的角色清單(將角色作為權限使用)
		/// </summary>
		/// <param name="userId">要傳回角色(權限)清單的使用者</param>"
		/// <returns>
		/// 字串陣列，其中包含所設定 applicationName 之指定使用者所屬的角色(權限)名稱。
		/// </returns>
		/// <exception cref="System.NotImplementedException">"
		public override string[] GetRolesForUser(string userAccount)
		{
			//int id;
			//if (!int.TryParse(userID, out id))
			//{
			//	return new string[] { }; // 若無法轉換成數字，則回傳空字串陣列
			//}
			//else
			//{
				var user = db.BEAdmins
							 .AsNoTracking()
							 .FirstOrDefault(u => u.Account == userAccount);
				// 驗證使用者是否存在
				if (user == null)
				{
					return new string[] { }; // 若不存在，則回傳空字串陣列
				}

				// 再使用Id取得該使用者的角色權限
				var permissions = db.AdminRoles
									.Where(ar => ar.AdminId == user.Id)                          // 直接從AdminRoles 取得該使用者擁有的所有角色
									.SelectMany(ar => ar.Role.RolePermissions)                  // 由於一個角色可以有多個權限，所以使用SelectMany將所有權限合併成一個集合
									.Select(rp => rp.Permission.NameInSystem)                   // 取得權限名稱
									.Distinct()                                                 // 移除重複的權限名稱
									.ToArray();                                                 // 轉換成陣列

				return permissions;                                         // 回傳該使用者擁有的所有權限
			//}


		}

		/// <summary>
		/// 取得值，指出指定的使用者是否擁有設定 applicationmName 之指定權限。
		/// </summary>
		/// <param name="account">The user identifier</param>
		/// <param name="permissionName">要搜尋的權限</param>
		/// <returns>
		/// 如果指定使用者擁有所設定 applicationName 的指定權限，則為 true，否則為 false。
		/// </returns>
		public override bool IsUserInRole(string account, string permissionName)
		{
			//Guid id;
			//if (!Guid.TryParse(userId, out id))
			//{
			//	return false;
			//}

			//// 將Guid id 轉換成int
			//Guid guid = new Guid(id);
			//int intValue = BitConverter.ToInt32(guid.ToByteArray(), 0);

			//// 使用Id取得該使用者
			//var user = db.BEAdmins
			//			 .AsNoTracking()
			//			 .FirstOrDefault(u => u.Id == intValue);

			// 使用account取得該使用者
			var user = db.BEAdmins
						 .AsNoTracking()
						 .FirstOrDefault(u => u.Account == account);

			// 判斷使用者是否存在
			if (user == null)
			{
				return false; // 若不存在，則回傳false
			}

			// 檢查使用者是否擁有指定的權限

			bool hasPermission = db.AdminRoles
				.Where(ar => ar.AdminId == user.Id)                          // 直接從AdminRoles 取得該使用者擁有的所有角色
				.SelectMany(ar => ar.Role.RolePermissions)                  // 由於一個角色可以有多個權限，所以使用SelectMany將所有權限合併成一個集合
				.Select(rp => rp.Permission.NameInSystem)                   // 取得權限名稱
				.Distinct()                                                 // 移除重複的權限名稱
				.Contains(permissionName);                                      // 檢查使用者是否擁有指定的角色(權限)
			return hasPermission;

		}

		public override string ApplicationName { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }

		public override void AddUsersToRoles(string[] usernames, string[] roleNames)
		{
			throw new NotImplementedException();
		}

		public override void CreateRole(string roleName)
		{
			throw new NotImplementedException();
		}

		public override bool DeleteRole(string roleName, bool throwOnPopulatedRole)
		{
			throw new NotImplementedException();
		}

		public override string[] FindUsersInRole(string roleName, string usernameToMatch)
		{
			throw new NotImplementedException();
		}

		public override string[] GetAllRoles()
		{
			throw new NotImplementedException();
		}



		public override string[] GetUsersInRole(string roleName)
		{
			throw new NotImplementedException();
		}


		public override void RemoveUsersFromRoles(string[] usernames, string[] roleNames)
		{
			throw new NotImplementedException();
		}

		public override bool RoleExists(string roleName)
		{
			throw new NotImplementedException();
		}
	}
}