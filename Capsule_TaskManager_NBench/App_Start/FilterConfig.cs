﻿using System.Web;
using System.Web.Mvc;

namespace Capsule_TaskManager_NBench
{
    public class FilterConfig
    {
        public static void RegisterGlobalFilters(GlobalFilterCollection filters)
        {
            filters.Add(new HandleErrorAttribute());
        }
    }
}
