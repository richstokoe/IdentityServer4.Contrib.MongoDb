using IdentityServer4.Stores;
using System;
using System.Collections.Generic;
using System.Text;
using IdentityServer4.Models;
using System.Threading.Tasks;

namespace IdentityServer4.Contrib.MongoDb
{
    public class MongoDbAuthorizationCodeStore : IAuthorizationCodeStore
    {
        public Task<AuthorizationCode> GetAuthorizationCodeAsync(string code)
        {
            throw new NotImplementedException();
        }

        public Task RemoveAuthorizationCodeAsync(string code)
        {
            throw new NotImplementedException();
        }

        public Task StoreAuthorizationCodeAsync(string handle, AuthorizationCode code)
        {
            throw new NotImplementedException();
        }
    }
}
