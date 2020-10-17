using System;
using Microsoft.AspNetCore.JsonPatch;
using Microsoft.AspNetCore.Mvc;
using SimpleAPI.Models;
using SimpleAPI.Repositories;

namespace SimpleAPI.Controllers
{
    [Route("api/order")]
    [ApiController]
    public class OrderController : ControllerBase
    {
        private readonly IOrderRepository _orderRepository;

        public OrderController(IOrderRepository orderRepository)
        {
            _orderRepository = orderRepository;
        }

        [HttpGet]
        public IActionResult Get()
        {
            return Ok(_orderRepository.Get());
        }

        [HttpGet("{id:guid}")]
        public IActionResult GetById(Guid id)
        {
            return Ok(_orderRepository.Get(id));
        }

        [HttpPost]
        public IActionResult Post(Order request)
        {
            var order = new Order
            {
                Id = Guid.NewGuid(),
                ItemsIds = request.ItemsIds
            };

            _orderRepository.Add(order);
            // return Ok();
            return CreatedAtAction(nameof(GetById), new {id = order.Id}, null);
        }

        [HttpPut("{id:guid}")]
        public IActionResult Put(Guid id, Order request)
        {
            if (request.ItemsIds == null)
                return BadRequest();

            var order = _orderRepository.Get(id);

            if (order == null)
                return NotFound(new {Message = $"Item with id {id} not exist."});

            order.ItemsIds = request.ItemsIds;
            _orderRepository.Update(id, order);
            return Ok();
        }

        [HttpPatch("{id:guid}")]
        public IActionResult Patch(Guid id, JsonPatchDocument<Order> requestOp)
        {
            var order = _orderRepository.Get(id);
            if (order == null)
            {
                return NotFound(new {Message = $"Item with id {id} not exist."});
            }

            requestOp.ApplyTo(order);
            _orderRepository.Update(id, order);
            return Ok();
        }

        [HttpDelete("{id:guid}")]
        public IActionResult Delete(Guid id)
        {
            var order = _orderRepository.Get(id);
            if (order == null)
            {
                return NotFound(new {Message = $"Item with id {id} not exist."});
            }
            
            _orderRepository.Delete(id);
            return NoContent();
        }
    }
}