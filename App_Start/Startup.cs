using System;
using System.Threading.Tasks;
using Microsoft.Owin;
using Microsoft.Owin.Security;
using Microsoft.Owin.Security.Cookies;
using Microsoft.Owin.Security.OpenIdConnect;
using Owin;

[assembly: OwinStartup(typeof(LiberalStudiesFinal.App_Start.Startup))]

namespace LiberalStudiesFinal.App_Start
{
	public class Startup
	{
		public void Configuration(IAppBuilder app)
		{
			app.SetDefaultSignInAsAuthenticationType(CookieAuthenticationDefaults.AuthenticationType);

			app.UseCookieAuthentication(new CookieAuthenticationOptions());

			app.UseOpenIdConnectAuthentication(
				new OpenIdConnectAuthenticationOptions
				{
					ClientId = "d04fb01f-0715-4ed7-a656-0793b545e1f1",
					Authority = "https://login.windows.net/6c3d51dd-f0e5-4959-b4ea-a80c4e36fe5e"
				});
			// For more information on how to configure your application, visit https://go.microsoft.com/fwlink/?LinkID=316888
		}
	}
}
