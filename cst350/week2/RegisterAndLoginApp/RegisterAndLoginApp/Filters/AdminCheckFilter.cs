using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using RegisterAndLoginApp.Models;

namespace RegisterAndLoginApp.Filters
{
    public class AdminCheckFilter : ActionFilterAttribute
    {
        public override void OnActionExecuted(ActionExecutedContext context)
        {
            string userInfo = context.HttpContext.Session.GetString("User");
            if (userInfo == null)
            {
                context.Result = new RedirectResult("/User/Index");
                return;
            }

            try
            {
                UserModel user = ServiceStack.Text.JsonSerializer.DeserializeFromString<UserModel>(userInfo);
                if(!user.Groups.Contains("Admin"))
                {
                    context.Result = new RedirectResult("/User/Index");
                    return;
                }
            } 
            catch
            {
                context.Result = new RedirectResult("/User/Index");
                return;
            }
        }
    }
}
