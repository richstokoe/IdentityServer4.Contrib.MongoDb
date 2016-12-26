using System;
using System.Collections.Generic;
using System.Text;

namespace IdentityServer4.Contrib.MongoDb
{
    public class DocumentDbSettings
    {
        public string DatabaseName { get; set; }

        public Uri DatabaseUri { get; set; }

        public string PrimaryKey { get; set; }

        public const string DatabaseNameKey = "DocumentDbSettings:DatabaseName";
        public const string DatabaseUriKey = "DocumentDbSettings:DatabaseUri";
        public const string PrimaryKeyKey = "DocumentDbSettings:PrimaryKey";
    }
}
