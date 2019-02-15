using System.Web;
using System.Web.Mvc;

namespace Cede_Dotnet_MVC
{
    public class FilterConfig
    {
        public static void RegisterGlobalFilters(GlobalFilterCollection filters)
        {
            filters.Add(new HandleErrorAttribute());
            
            // comprueba el usuario en toda la aplicacion
            //filters.Add(new AuthorizeAttribute());
        }
    }
}
