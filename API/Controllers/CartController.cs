using System.Threading.Tasks;
using API.Dtos;
using AutoMapper;
using Core.Entities;
using Core.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{
    public class CartController : BaseApiController
    {
        private readonly ICartRepository _CartRepository;
        private readonly IMapper _mapper;
        public CartController(ICartRepository CartRepository, IMapper mapper)
        {
            _mapper = mapper;
            _CartRepository = CartRepository;
        }

        [HttpGet]
        public async Task<ActionResult<CustomerCart>> GetCartById(string id)
        {
            var Cart = await _CartRepository.GetCartAsync(id);

            return Ok(Cart ?? new CustomerCart(id));
        }

        [HttpPost]
        public async Task<ActionResult<CustomerCart>> UpdateCart(CustomerCartDto Cart)
        {
            var customerCart = _mapper.Map<CustomerCartDto, CustomerCart>(Cart);

            var updatedCart = await _CartRepository.UpdateCartAsync(customerCart);

            return Ok(updatedCart);
        }

        [HttpDelete]
        public async Task DeleteCartAsync(string id)
        {
            await _CartRepository.DeleteCartAsync(id);
        }
    }
}