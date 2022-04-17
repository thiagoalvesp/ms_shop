using System;
using System.Threading.Tasks;
using Basket.API.Entities;
using Basket.API.GrpcServices;
using Basket.API.Repositories;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace Basket.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BasketController : ControllerBase
    {

        private readonly ILogger<BasketController> _logger;
        private readonly IBasketRepository _repository;
        private readonly DiscountGrpcService _discountGrpcService;

        public BasketController(IBasketRepository repository, ILogger<BasketController> logger, DiscountGrpcService discountGrpcService = null)
        {
            _repository = repository ?? throw new ArgumentNullException(nameof(repository));
            _logger = logger;
            _discountGrpcService = discountGrpcService;

            _logger.LogInformation("NLog injected into BasketController");
        }

        [HttpGet("{userName}", Name ="GetBasket")]
        public async Task<ActionResult<ShoppingCart>> GetBasket(string userName)
        {

            _logger.LogInformation($"GetBasket called with userName:{userName}");

            var basket = await _repository.GetBasket(userName);

            return Ok(basket ?? new ShoppingCart(userName));
        }

        [HttpPost]
        public async Task<ActionResult<ShoppingCart>> UpdateBasket([FromBody] ShoppingCart basket) 
        {

            //Calcular os precos atuais dos produtos no carrinho de compras
            foreach (var item in basket.Items)
            {
              var coupon = await _discountGrpcService.GetDiscount(item.ProductName);
              item.Price -= coupon.Amount;
            }

            return Ok(await _repository.UpdateBasket(basket));
        }


        [HttpDelete("{userName}", Name ="DeleteBasket")]
        public async Task<ActionResult<ShoppingCart>> DeleteBasket(string userName)
        {
            await _repository.DeleteBasket(userName);
            return Ok();
        }


    }
}