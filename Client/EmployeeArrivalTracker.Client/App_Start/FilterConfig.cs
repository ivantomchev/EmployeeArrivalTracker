﻿using System.Web;
using System.Web.Mvc;

namespace EmployeeArrivalTracker.Client
{
    public class FilterConfig
    {
        public static void RegisterGlobalFilters(GlobalFilterCollection filters)
        {
            filters.Add(new HandleErrorAttribute());
        }
    }
}
