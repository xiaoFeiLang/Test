﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using NB.Common.Models;
using System.Reflection;
using NB.Web.Extension.Filters;

namespace NB.Web.Common
{
    public class ConfigSettingHelper
    {
        private readonly static string WebNamespace = "";
        private readonly static string AdminController = "AdminController";

        public static List<MVCModuleModel> GetAllModuleLinkUrl()
        {
            var model = new List<MVCModuleModel>();
            if (HttpContext.Current.Application["ModuleLinkUrl"] == null)
            {
                model = GetAllModuleByAssembly();
                HttpContext.Current.Application["ModuleLInkUrl"] = model;
            }
            else
            {
                model = (List<MVCModuleModel>)HttpContext.Current.Application["ModuleLinkUrl"];
            }
            return model;
        }

        /// <summary>
        /// 获取Controller下的Action, 组合成LinkUrl提供给Module模块使用
        /// </summary>
        /// <returns></returns>
        private static List<MVCModuleModel> GetAllModuleByAssembly()
        {
            var model = new List<MVCModuleModel>();

            var types = Assembly.Load(WebNamespace).GetTypes();

            foreach (var type in types)
            {
                if (type.BaseType.Name == AdminController)
                {
                    var members = type.GetMethods();
                    foreach (var member in members)
                    {
                        if (member.ReturnType.Name == "ActionResult")
                        {
                            object[] attrs = member.GetCustomAttributes(typeof(AdminLayoutAttribute), true);
                            if (attrs.Length > 0)
                            {
                                var moduleModel = new MVCModuleModel();

                                var fullNameArray = member.DeclaringType.FullName.Split('.');
                                string areaName = fullNameArray[fullNameArray.Length - 3];
                                string controllerName = member.DeclaringType.Name.Substring(0, member.DeclaringType.Name.Length - 10);
                                string actionName = member.Name;
                                moduleModel.LinkUrl = string.Format("{0}/{1}/{2}", areaName, controllerName, actionName);

                                model.Add(moduleModel);
                            }
                        }
                    }
                }
            }
            return model;
        }

    }
}