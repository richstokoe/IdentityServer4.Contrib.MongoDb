using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.Azure.Documents.Client;

namespace IdentityServer4.Contrib.MongoDb
{
    public class DocumentClientProvider : IDocumentClientProvider
    {
        private readonly DocumentDbSettings _settings;
        private static DocumentClient _client;

        public DocumentClientProvider(DocumentDbSettings settings)
        {
            if (settings == null) { throw new ArgumentNullException(nameof(settings)); }

            _settings = settings;
        }

        public DocumentClient GetDocumentClient()
        {
            if(_client == null)
            {
                _client = new DocumentClient(
                    _settings.DatabaseUri,
                    _settings.PrimaryKey,
                    new ConnectionPolicy
                    {
                        ConnectionMode = ConnectionMode.Direct,
                        ConnectionProtocol = Protocol.Tcp
                    });
            }
            return _client;
        }
    }
}
