using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using SolarCoffee.Services.Inventory;
using SolarCoffee.Web.Serialization;
using SolarCoffee.Web.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SolarCoffee.Web.Controllers
{
    [ApiController]
    public class InventoryController: ControllerBase
    {
        private readonly IInventoryService _inventory;
        private readonly ILogger<InventoryController> _logger;

        public InventoryController(IInventoryService inventory, ILogger<InventoryController> logger)
        {
            _inventory = inventory;
            _logger = logger;
        }

        [HttpGet("/api/inventory")]
        public ActionResult GetCurrentInventory()
        {
            _logger.LogInformation("Getting all inventory");
            var inventory = _inventory.GetCurrentInventory()
                .Select(pi => new ProductInventoryModel
                {
                    Id=pi.Id,
                    Product=ProductMapper.SerializeProductModel(pi.Product),
                    IdealQuantity=pi.IdealQuantity,
                    QuantityOnHand=pi.QuantityOnHand
                })
              .OrderBy(inv => inv.Product.Name)
              .ToList();

            return Ok(inventory);
        }

        [HttpPatch("/api/inventory")]
        public ActionResult UpdateInventory([FromBody] ShipmentModel shipment)
        {
            _logger.LogInformation($"Updating inventory for {shipment.ProductId} - Adjustment: {shipment.Adjustment}");

            var id = shipment.ProductId;
            var adjustment = shipment.Adjustment;
            var inventory = _inventory.UpdateUnitsAvailable(id, adjustment);
            return Ok(inventory);
        }
    }
}
