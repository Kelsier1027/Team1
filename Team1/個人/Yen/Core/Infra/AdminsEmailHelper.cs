using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Web;

namespace Team1.Models.Infra
{
	public class AdminsEmailHelper
	{
		private string senderEmail = "g01.webapp@gmail.com"; // 寄件者
		public void SendForgetPasswordEmail(string url, string name, string email)
		{
			var subject = "[重設密碼通知]";
			var body = $@"Hi {name},
<br />
請點擊此連結 [<a href='{url}' target='_blank'>重設密碼</a>], 以進行重設密碼, 如果您沒有提出申請, 請忽略本信, 謝謝";
			var from = senderEmail;
			var to = email;
			SendViaGoogle(from, to, subject, body);
		}
		public void SendConfirmRegisterEmail(string url, string name, string email)
		{
		}
		public virtual void SendViaGoogle(string from, string to, string subject, string body)
		{
			// todo 以下是開發時,測試之用, 只是建立text file, 不真的寄出信
			var path = HttpContext.Current.Server.MapPath("~/files/TestMails/");
			CreateTextFile(path, from, to, subject, body);
			return;
		}
		private void CreateTextFile(string path, string from, string to, string subject, string body)
		{
			var fileName = $"{to.Replace("@", "_")} {DateTime.Now.ToString("yyyyMMdd_HHmmss")}.txt";
			// 文字檔案的完整路徑
			var fullPath = Path.Combine(path, fileName);
			// 檔案內容
			var contents = $@"from:{from}
							to:{to}
							subject:{subject}
							{body}";
			// 建立文字檔案, 採用UTF8編碼
			File.WriteAllText(fullPath, contents, Encoding.UTF8);
		}

		internal void SendConfirmRegisterMail(string url, string name, string email)
		{
			var subject = "[電子信箱驗證信]";
			var body = $@"Hi {name},
			<br/>
			請點擊此連結 [<a href='{url}' target='_blank'>驗證電子信箱</a>], 以驗證電子信箱, 如果您沒有提出申請, 請忽略本信, 謝謝";

			var from = senderEmail;
			var to = email;

			SendViaGoogle(from, to, subject, body);

		}
	}
}