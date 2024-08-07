using AutoMapper;
using BLL.Abstract;
using BLL.DTOs;
using Burgerci_Proje.Entities;
using DAL.AbstractRepositories;
using DAL.Entities;

namespace BLL.Concrete
{
    public class OrderService : IOrderService
    {
        private readonly IMapper _mapper;
        private readonly IRepository<Order> _orderRepository;
        public OrderService(IRepository<Order> orderRepository, IMapper mapper)
        {
            _orderRepository = orderRepository;
            _mapper = mapper;
        }

        public Task AddOrderDetail(Guid orderDetailId)
        {
            throw new NotImplementedException();
        }

        public async Task<Guid> CreateOrder(OrderDto orderDto)
        {
            var order = _mapper.Map<Order>(orderDto);
            var id = await _orderRepository.AddAsync(order);
            return id;
        }

        public async Task DeleteOrder(Guid orderId)
        {
            await _orderRepository.DeleteAsync(orderId);
        }

        public async Task<List<OrderDto>> GetAllOrders()
        {
            var orders = await _orderRepository.GetAllAsync();
            var orderDtos = _mapper.Map<List<OrderDto>>(orders.Where(w => w.IsActive));
            return orderDtos;
        }
        public async Task ApproveOrder(Guid orderId)
        {
            var orderTobeApproved = await _orderRepository.GetByIdAsync(orderId);
            orderTobeApproved.IsActive = false;
            await _orderRepository.UpdateAsync(orderTobeApproved);
        }

        public async Task UpdateOrder(OrderDto orderDto)
        {
            await _orderRepository.UpdateAsync(_mapper.Map<Order>(orderDto));
        }

        public async Task<List<OrderDto>> GetActiveOrder(Guid userId)
        {
            var allOrders = await _orderRepository.GetAllAsync();
            var activeOrders = allOrders.Where(x => x.IsActive && x.UserId == userId).ToList();

            return _mapper.Map<List<OrderDto>>(activeOrders);
        }

        public async Task<OrderDto> GetById(Guid orderId)
        {

            var order = await _orderRepository.GetByIdAsync(orderId);

            return _mapper.Map<OrderDto>(order);
        }
    }
}
