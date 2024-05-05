using Zad6.Properties;

namespace Zad6;

public interface IWarehousesRepository
{
    Task<bool> ProductNotExist(int id);
    Task<bool> WarehouseNotExist(int id);
    Task<int> OrderNotExist(Warehouse warehouse);
    Task UpdateFulfilledAt(Order order);
    Task<int> InsertProduct_Warehouse(Warehouse productWarehouse, Order order, Product product);
}