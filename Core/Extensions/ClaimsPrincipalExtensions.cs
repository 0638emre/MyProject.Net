﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace Core.Extensions
{
    public static class ClaimsPrincipalExtensions
    {
        //bir kişinin claimlerini ararken dotnet bizi uğraştırır.
        //claimleri okumak için claimsPrincipal ı genişletiyoruz.
        //aslında seçmek gibi bir işlevi var bu sayfanın.
        public static List<string> Claims(this ClaimsPrincipal claimsPrincipal, string claimType)
        {
            var result = claimsPrincipal?.FindAll(claimType)?.Select(x => x.Value).ToList();
            //buradaki soru işareti null olabileceğini anlatır. mesela token istememiş gibi..
            return result;
        }

        public static List<string> ClaimRoles(this ClaimsPrincipal claimsPrincipal)
        {
            return claimsPrincipal?.Claims(ClaimTypes.Role);
        }
    }
}
