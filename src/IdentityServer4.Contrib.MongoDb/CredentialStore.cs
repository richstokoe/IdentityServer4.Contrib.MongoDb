using IdentityServer4.Stores;
using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.IdentityModel.Tokens;
using System.Threading.Tasks;

namespace IdentityServer4.Contrib.MongoDb
{
    public class MongoDbCredentialStore : ISigningCredentialStore
    {
        public Task<SigningCredentials> GetSigningCredentialsAsync()
        {
            throw new NotImplementedException();
        }
    }
}
