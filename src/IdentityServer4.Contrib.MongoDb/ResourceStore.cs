﻿using IdentityServer4.Stores;
using System;
using System.Collections.Generic;
using System.Text;
using IdentityServer4.Models;
using System.Threading.Tasks;
using Microsoft.Azure.Documents.Client;

namespace IdentityServer4.Contrib.MongoDb
{
    public class MongoDbResourceStore : IResourceStore
    {
        private readonly DocumentClient _client;

        public MongoDbResourceStore(IDocumentClientProvider documentClientProvider)
        {
            _client = documentClientProvider.GetDocumentClient();
        }

        public Task<ApiResource> FindApiResourceAsync(string name)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<ApiResource>> FindApiResourcesByScopeAsync(IEnumerable<string> scopeNames)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<IdentityResource>> FindIdentityResourcesByScopeAsync(IEnumerable<string> scopeNames)
        {
            throw new NotImplementedException();
        }

        public Task<Resources> GetAllResources()
        {
            throw new NotImplementedException();
        }
    }
}
