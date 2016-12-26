using Microsoft.Azure.Documents;
using Microsoft.Azure.Documents.Client;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace IdentityServer4.Contrib.MongoDb
{
    public class DbCreate
    {
        private readonly DocumentDbSettings _settings;
        private readonly DocumentClient _client;
        private readonly ILogger<DbCreate> _logger;

        public DbCreate(IDocumentClientProvider dbProvider, DocumentDbSettings settings, ILogger<DbCreate> logger)
        {
            _client = dbProvider.GetDocumentClient();
            _settings = settings;
            _logger = logger;
        }

        public async Task Run()
        {
            await CreateDbIfNotExists(_settings.DatabaseName);
        }

        private async Task CreateDbIfNotExists(string databaseName)
        {
            // Check to verify a database with the id=FamilyDB does not exist
            try
            {
                await this._client.ReadDatabaseAsync(UriFactory.CreateDatabaseUri(databaseName));
                this._logger.LogInformation($"DbCreate.CreateIfNotExists: Found {databaseName}");
            }
            catch (DocumentClientException de)
            {
                // If the database does not exist, create a new database
                if (de.StatusCode == HttpStatusCode.NotFound)
                {
                    await this._client.CreateDatabaseAsync(new Database { Id = databaseName });
                    this._logger.LogInformation($"DbCreate.CreateIfNotExists: Created {databaseName}");
                }
                else
                {
                    throw;
                }
            }
        }
    }
}
