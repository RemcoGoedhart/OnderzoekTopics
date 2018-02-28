using System;
using System.Collections.Generic;
using System.Linq;
using System.Data.Entity;

namespace SC.DAL.EF
{
    class SupportCenterDBConfiguration : DbConfiguration
    {
        public SupportCenterDBConfiguration()
        {
            this.SetDefaultConnectionFactory
                (new System.Data.Entity.Infrastructure.SqlConnectionFactory());

            this.SetProviderServices("System.Data.SqlClient"
                    , System.Data.Entity.SqlServer.SqlProviderServices.Instance);
        }
    }
}
