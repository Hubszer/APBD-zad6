using Microsoft.AspNetCore.Mvc;
using Zad6.Properties;

namespace Zad6;

[Route("api/warehouse")]
[ApiController]
public class WarehouseController : ControllerBase
{
    public readonly IConfiguration _configuration;
    

    public readonly IWarehousesRepository _warehousesRepository;

    public WarehouseController(IConfiguration configuration, IWarehousesRepository warehousesRepository)
    {
        _configuration = configuration;
        _warehousesRepository = warehousesRepository;
    }
    [HttpPost]
    public async Task<IActionResult> AddProductWarehouse(Warehouse warehouse)
    {
        if (await _warehousesRepository.ProductNotExist(warehouse.IdProduct) 
            || await _warehousesRepository.WarehouseNotExist(warehouse.IdWarehouse))
        {
            return NotFound("Produkt lub magazyn o danym ID={IdWarehouse} nie istnieje!");
        }

        int idOrder = await _warehousesRepository.OrderNotExist(warehouse);
        if (idOrder == -1)
        {
            return NotFound("Nie ma odpowiedniego zlecenia produktu!");
        }

        Product product = new Product { IdProduct = warehouse.IdProduct};
        Order order = new Order
        {
            IdOrder = idOrder,
            IdProduct = warehouse.IdProduct,
            Amount = warehouse.Amount,
            CreatedAt = warehouse.CreatedAt
        };

        await _warehousesRepository.UpdateFulfilledAt(order);

        var key = await _warehousesRepository.InsertProduct_Warehouse(warehouse, order, product);
            
        return Ok(key);
    }
}
