using Oracle.ManagedDataAccess.EntityFramework;
using System.Data.Entity;

namespace Ingemmet.FirmaDocumento.Data
{
    public class OracleDbConfiguration : DbConfiguration
    {
        public OracleDbConfiguration()
        {
            SetProviderServices("Oracle.ManagedDataAccess.Client", EFOracleProviderServices.Instance);
        }
    }
}
