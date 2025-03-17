using _0_Framework.Application;
using _0_Framework.Infrastructure;
using Microsoft.AspNetCore.Mvc.Filters;
using System.Reflection;

namespace SM.LampShade
{
    public class SecurityPageFilter : IPageFilter
    {
        private readonly IAuthHelper _authHelper;

        public SecurityPageFilter(IAuthHelper authHelper)
        {
            _authHelper = authHelper;
        }

        public void OnPageHandlerExecuted(PageHandlerExecutedContext context)
        {
            
        }

        public void OnPageHandlerExecuting(PageHandlerExecutingContext context)
        {
            var handlerPermission = 
                (NeedsPermissionAttribute) context.HandlerMethod.MethodInfo.GetCustomAttribute
                (typeof(NeedsPermissionAttribute));

            if(handlerPermission == null)
            {
                return;
            }
            var accountPermission = _authHelper.GetPermissions();
            if (accountPermission.All(x=>x != handlerPermission.Permissions))
                context.HttpContext.Response.Redirect("/Account");
        }

        public void OnPageHandlerSelected(PageHandlerSelectedContext context)
        {
           
        }
    }
}
