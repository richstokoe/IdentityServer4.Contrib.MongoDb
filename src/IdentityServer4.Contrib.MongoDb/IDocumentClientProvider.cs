using Microsoft.Azure.Documents.Client;
using System;
using System.Collections.Generic;
using System.Text;

namespace IdentityServer4.Contrib.MongoDb
{
    public interface IDocumentClientProvider
    {
        DocumentClient GetDocumentClient();
    }
}
