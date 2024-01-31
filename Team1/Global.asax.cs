using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Principal;
using System.Web;
using System.Web.Http;
using System.Web.Mvc;
using System.Web.Optimization;
using System.Web.Routing;
using System.Web.Security;

namespace Team1
{
    public class MvcApplication : System.Web.HttpApplication
    {
        protected void Application_Start()
        {
            AreaRegistration.RegisterAllAreas();
            GlobalConfiguration.Configure(WebApiConfig.Register);
            FilterConfig.RegisterGlobalFilters(GlobalFilters.Filters);
            RouteConfig.RegisterRoutes(RouteTable.Routes);
            BundleConfig.RegisterBundles(BundleTable.Bundles);
        }

		// 客製化 Application_AuthenticateRequest 事件處理常式
        protected void Application_AuthenticateRequest(object sender, EventArgs e)
        {
			bool hasUser = HttpContext.Current.User != null; // 判斷目前的 HttpContext 的 User 屬性是否為 null
			bool isAuthenticated = hasUser && HttpContext.Current.User.Identity.IsAuthenticated; // 判斷user是否已經通過身份驗證
			bool isIdentity = isAuthenticated && HttpContext.Current.User.Identity is FormsIdentity; // 判斷user的身份驗證類型是否為 Forms 身份驗證

            if (isIdentity)
            {
                // 取得 Forms 身份驗證的票證
                FormsIdentity identity = (FormsIdentity)HttpContext.Current.User.Identity;
                // 取得 Forms 身份驗證的票證中的使用者資訊
                FormsAuthenticationTicket ticket = identity.Ticket;
                // 傳入存於cookie(ticket.name)中的account，來取得使用者資訊中的角色清單
                var roles = Roles.GetRolesForUser(ticket.Name);
                // 賦予目前這個 HttpContext 的 User 屬性新的 Forms 身份驗證票證
                HttpContext.Current.User = new GenericPrincipal(identity, roles);
            }
		}
	}
}
