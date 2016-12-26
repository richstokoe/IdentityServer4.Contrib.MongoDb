using System;
using System.Collections.Generic;
using System.Text;

namespace IdentityServer4.Contrib.MongoDb
{
    public class DocumentDbSettings
    {
        public Uri DatabaseUri { get; set; }

        public string PrimaryKey { get; set; }
    }
}
