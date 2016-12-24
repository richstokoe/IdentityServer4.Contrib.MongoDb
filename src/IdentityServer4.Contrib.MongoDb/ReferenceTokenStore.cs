using IdentityServer4.Stores;
using System;
using System.Collections.Generic;
using System.Text;
using IdentityServer4.Models;
using System.Threading.Tasks;

namespace IdentityServer4.Contrib.MongoDb
{
    public class MongoDbReferenceTokenStore : IReferenceTokenStore
    {
        public Task<Token> GetReferenceTokenAsync(string handle)
        {
            throw new NotImplementedException();
        }

        public Task RemoveReferenceTokenAsync(string handle)
        {
            throw new NotImplementedException();
        }

        public Task RemoveReferenceTokensAsync(string subjectId, string clientId)
        {
            throw new NotImplementedException();
        }

        public Task StoreReferenceTokenAsync(string handle, Token token)
        {
            throw new NotImplementedException();
        }
    }
}
