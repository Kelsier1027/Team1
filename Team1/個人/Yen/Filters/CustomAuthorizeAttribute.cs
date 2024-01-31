using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;


namespace Team1.Filters
{
	public class CustomAuthorizeAttribute : AuthorizeAttribute
	{
		public bool IsAuthorize { get; set; }

		public override void OnAuthorization(AuthorizationContext filterContext)
		{
			base.OnAuthorization(filterContext);

			if (!this.IsAuthorize)
			{
				filterContext.HttpContext.Response.StatusCode = 403;

				//沒有權限就回到首頁
				UrlHelper urlHelper = new UrlHelper(filterContext.RequestContext);
				filterContext.Result = new RedirectResult(urlHelper.Action("Index", "Home"));
			}
		}

		protected override bool AuthorizeCore(HttpContextBase httpContext)
		{
			var identity = httpContext.User.Identity as FormsIdentity;

			var roles = this.Roles.Split(',');

			this.IsAuthorize = roles.Count(role =>
				System.Web.Security.Roles.IsUserInRole(identity.Ticket.Name, role)) > 0;

			return this.IsAuthorize;
		}
	}
}