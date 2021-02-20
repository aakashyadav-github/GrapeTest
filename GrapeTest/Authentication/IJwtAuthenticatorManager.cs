using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GrapeTest.Authentication
{
    public interface IJwtAuthenticatorManager
    {
        public string Authenticate(string username, string password);
    }
}
