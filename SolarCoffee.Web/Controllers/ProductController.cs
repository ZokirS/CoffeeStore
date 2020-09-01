using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using SolarCoffee.Services.Product;
using SolarCoffee.Web.Serialization;
using System.Threading;

namespace SolarCoffee.Web.Controllers
{
    [ApiController]
    public class ProductController : ControllerBase
    {
        private readonly ILogger<ProductController> _logger;
        private readonly IProductService _productService;

        public ProductController(ILogger<ProductController> logger, IProductService productService)
        {
            _logger = logger;
            _productService = productService;
        }

        [HttpGet("/api/product")]
        public ActionResult GetProduct()
        {
            Thread thread = Thread.CurrentThread;
            _logger.LogInformation("Getting all products");
            _logger.LogInformation($"Name of thread: {thread.Name}");
            _logger.LogInformation($"IsAlive: {thread.IsAlive}");
            _logger.LogInformation($"Thread State: {thread.ThreadState}");
            _logger.LogInformation($"Priority: {thread.Priority}");
            var products= _productService.GetAllProducts();
            var productViewModels = products
                .Select(ProductMapper.SerializeProductModel);
            
            return Ok(productViewModels); 
        }
        //[HttpGet("/api/products")]
        //public ActionResult Product()
        //{
           
        //    _logger.LogInformation("Getting all products");
        //    _logger.LogInformation($"Name of thread: {thread.Name}");
        //    _logger.LogInformation($"IsAlive: {thread.IsAlive}");
        //    _logger.LogInformation($"Thread State: {thread.ThreadState}");
        //    _logger.LogInformation($"Priority: {thread.Priority}");
        //    var products = _productService.GetAllProducts();
        //    var productViewModels = products
        //        .Select(ProductMapper.SerializeProductModel);
        //    return Ok(productViewModels);
        //}
    }
}
