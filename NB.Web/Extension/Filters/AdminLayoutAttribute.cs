using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

using System.ComponentModel.Composition.Hosting;
using Quick.Framework.Common.ToolsHelper;
using NB.Domain.Models.Authen;
using NB.Models.AdminCommon;

namespace NB.Web.Extension.Filters
{
    [AttributeUsage(AttributeTargets.Class | AttributeTargets.Method, Inherited = true, AllowMultiple = false)]
    public class AdminLayoutAttribute : ActionFilterAttribute
    {
        public AdminLayoutAttribute()
        {
				var container = System.Web.HttpContext.Current.Application["Container"] as CompositionContainer;
        }

        public override void OnResultExecuting(ResultExecutingContext filterContext)
        {
            base.OnResultExecuting(filterContext);
            var user = SessionHelper.GetSession("CurrentUser") as User;
            if(user != null)
            {
                ((ViewResult)filterContext.Result).ViewBag.LoginName = user.LoginName;
                ((ViewResult)filterContext.Result).ViewBag.SidebarMenuModel = InitSidebarMenu(user);
            }
        }

        private List<SidebarMenuModel>InitSidebarMenu(User user)
        {
            var entity = user.UserRole.Select(t => t.RoleId);
            List<int> RoleIds = entity.ToList();

            var sideBarMenu = new SidebarMenuModel
            {
                Id = 1,
                ParentId = 1,
                Name = "nAME",
                Code ="SDFDS",
                Icon ="SDF",
                LinkUrl = "SDFSD",
            };
            var childSideBarMenu = new SidebarMenuModel
            {
                Id = 1,
                ParentId = 1,
                Name = "34",
                Code ="324",
                Icon ="DDD",
                Area = "SDF",
                Controller = "SDFSD",
                Action ="SDFFSD"
            };
            sideBarMenu.ChildMenuList.Add(childSideBarMenu);
            
            var model = new List<SidebarMenuModel>();
            model.Add(sideBarMenu);
            return model;
        } 
    }
}

  //1.OnActionExecuting
  //     在Action方法调用前使用，使用场景：如何验证登录等。


  // 2.OnActionExecuted
  //    在Action方法调用后，result方法调用前执行，使用场景：异常处理。



  // 3.OnResultExecuting
  //   在result执行前发生(在view 呈现前)，使用场景：设置客户端缓存，服务器端压缩.


  //4.OnResultExecuted
  //  在result执行后发生，使用场景：异常处理，页面尾部输出调试信息。