using Microsoft.Azure.Documents.Client;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace IdentityServer4.Contrib.MongoDb
{
    public interface IDocumentClientProvider
    {
        DocumentClient GetDocumentClient();
    }
}
