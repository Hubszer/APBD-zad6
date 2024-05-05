using Zad6.Properties;

namespace Zad6;

public interface IWarehouseRepository2
{
    Task<int> InsertProduct_Warehouse(Warehouse warehouse);
}