using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using IdentityServer4.Models;
using IdentityServer4.Validation;
using IdentityServer4;
using Microsoft.Extensions.DependencyInjection;
using IdentityServer4.Contrib.MongoDb;
using IdentityServer4.Services;
using IdentityServer4.Stores;

namespace IdentityServer4.Contrib.MongoDb
{
    public class IdentityConfig
    {
        public static IIdentityServerBuilder Setup(IServiceCollection services)
        {
            var builder = services.AddIdentityServer();
            builder.Services
                .AddTransient<IClientStore, MongoDbClientStore>()
                .AddTransient<IAuthorizationCodeStore, MongoDbAuthorizationCodeStore>()
                .AddTransient<IPersistedGrantStore, MongoDbPersistedGrantStore>()
                .AddTransient<IReferenceTokenStore, MongoDbReferenceTokenStore>()
                .AddTransient<IRefreshTokenStore, MongoDbRefreshTokenStore>()
                .AddTransient<IResourceStore, MongoDbResourceStore>()
                .AddTransient<ISigningCredentialStore, MongoDbCredentialStore>()
                
                .AddSingleton<IDocumentClientProvider, DocumentClientProvider>();

            return builder;
        }
    }
}
