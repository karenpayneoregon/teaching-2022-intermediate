using Dapper;
using Microsoft.Data.SqlClient;
using TaxpayerLibraryEntityVersion.Models;
using static ConfigurationLibrary.Classes.ConfigurationHelper;

namespace TaxpayerLibraryEntityVersion.Classes;

    public class DapperOperations
    {

        public static async Task<List<ColumnResult>> GetColumnLengths(string statement)
        {
            await using SqlConnection cn = new(ConnectionString());
            var results = await cn.QueryAsync<ColumnResult>(statement);
            return results.ToList();
        }
    }

