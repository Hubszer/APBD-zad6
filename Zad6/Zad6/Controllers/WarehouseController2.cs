using Microsoft.AspNetCore.Mvc;
using Zad6.Properties;

namespace Zad6;

[Route("api/warehouse2")]
[ApiController]
public class WarehouseController2 : ControllerBase
{
    private readonly IConfiguration _configuration;
    private readonly IWarehouseRepository2 _warehouses2Repository;

    public WarehouseController2(IConfiguration configuration, IWarehouseRepository2 warehouseRepository2)
    {
        _configuration = configuration;
        _warehouses2Repository = warehouseRepository2;
    }

    [HttpPost]
    public async Task<int> AddProductToWarehouse(Warehouse warehouse)
    {
        return await _warehouses2Repository.InsertProduct_Warehouse(warehouse);
    }
}