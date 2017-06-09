﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Principal;
using System.Text;
using System.Threading.Tasks;
using System.Web;
using WebApplication6.Model;

namespace WebApplication6.Auth
{
    public interface IAuthentication
    {
        
        HttpContext HttpContext { get; set; }

        User Login(string login, string password, bool isPersistent);

        User Login(string login);

        void LogOut();

        IPrincipal CurrentUser { get; }
    }
}
