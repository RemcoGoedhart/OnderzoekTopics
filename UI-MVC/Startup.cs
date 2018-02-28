using System;
using System.Threading.Tasks;
using Microsoft.Owin;
using Owin;

namespace SC.UI.Web.MVC
{
    public class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            app.MapSignalR();

        }
    }
}
