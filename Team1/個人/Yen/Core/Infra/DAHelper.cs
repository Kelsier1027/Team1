using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Team1.Models.Infra
{
	/// <summary>
	/// Data Annotation Helper
	/// </summary>
	public static class DAHelper
	{
		public const string Required = "{0} 必填";
		public const string EmailAddress = "{0} 格式有誤";
		public const string StringLength = "{0} 長度不可大於 {1}";
		public const string StringLength2 = "{0} 長度必須介於 {2} 到 {1} 個字";
		public const string Compare = "{0} 與 {1} 不相同";
	}
}