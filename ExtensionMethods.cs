using BSSLNCSApi.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BSSLNCSApi
{
    public static class ExtensionMethods
    {
        public static AppUser WithoutPassword(this AppUser user)
        {
            user.Password = null;
            return user;
        }
    }
}
