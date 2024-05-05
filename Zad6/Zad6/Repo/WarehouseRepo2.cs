using System.Data;
using System.Data.SqlClient;
using Zad6.Properties;

namespace Zad6.Repo;

public class WarehouseRepo2 : IWarehouseRepository2
{
    private readonly IConfiguration _configuration;

    public WarehouseRepo2(IConfiguration configuration)
    {
        _configuration = configuration;
    }
    public async Task<int> InsertProduct_Warehouse(Warehouse warehouse)
    {
        int kluczGlowny;

        using (var sqlConnection = new SqlConnection(_configuration.GetConnectionString("Default")))
        {
            await sqlConnection.OpenAsync();

            var transaction = await sqlConnection.BeginTransactionAsync();
            SqlCommand command = sqlConnection.CreateCommand();
            command.Connection = sqlConnection;
            command.Transaction = transaction as SqlTransaction;

            command.CommandType = CommandType.StoredProcedure;
            command.CommandText = "AddProductToWarehouse";

            command.Parameters.AddWithValue("@IdProduct", warehouse.IdProduct);
            command.Parameters.AddWithValue("@IdWarehouse", warehouse.IdWarehouse);
            command.Parameters.AddWithValue("@Amount", warehouse.Amount);
            command.Parameters.AddWithValue("@CreatedAt", warehouse.CreatedAt);

            kluczGlowny = Convert.ToInt32(await command.ExecuteScalarAsync());

            await transaction.CommitAsync();

            return kluczGlowny;
        }
    }
}