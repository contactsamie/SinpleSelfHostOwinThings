using System.Web.Http;
using Microsoft.Owin.Cors;
using Owin;

namespace SinpleSelfHostOwinThings
{
    public class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            var config = new HttpConfiguration();
            //TODO FOUND secure entire site globally, does not work with authize attribute
            //COMMENT OUT TO DISABLE THIS FEATURES
            /*
            HTTP/1.1 401 Unauthorized
            Content-Length: 0
            Server: Microsoft-HTTPAPI/2.0
            WWW-Authenticate: Negotiate
            WWW-Authenticate: NTLM
            Date: Sun, 28 Jul 2013 21:02:21 GMT
            Proxy-Support: Session-Based-Authentication
             */
            app.UseCors(CorsOptions.AllowAll);
            app.UsePacketTrackingMiddleware();
            SetUpOwinThings.SetUpIntegratedWindowsAuthentication(app);
            SetUpOwinThings.SetUpAuthentication(app);
            SetUpOwinThings.SetUpWebApi(app, config);
            SetUpOwinThings.SetUpFileServer(app);
            app.MapSignalR();
        }
    }
}