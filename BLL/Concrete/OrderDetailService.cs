using AutoMapper;
using BLL.Abstract;
using BLL.DTOs;
using DAL.AbstractRepositories;
using DAL.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.Concrete
{
    public class OrderDetailService : IOrderDetailService
    {
        private readonly IMapper _mapper;
        private readonly IRepository<OrderDetail> _OrderDetailRepository;
        public OrderDetailService(IRepository<OrderDetail> orderDetailRepository, IMapper mapper)
        {
            _OrderDetailRepository = orderDetailRepository;
            _mapper = mapper;
        }
        public async Task CreateOrderDetail(OrderDetailDto orderDetailDto)
        {
            var orderDetail = _mapper.Map<OrderDetail>(orderDetailDto);
            await _OrderDetailRepository.AddAsync(orderDetail);
        }

        public async Task DeleteOrderDetail(Guid orderDetailId)
        {
            await _OrderDetailRepository.DeleteAsync(orderDetailId);
        }

        public async Task<List<OrderDetailDto>> GetAllOrderDetails(Guid orderId)
        {
            var allOrderDetails = await _OrderDetailRepository.GetAllAsync();

            return _mapper.Map<List<OrderDetailDto>>(allOrderDetails.Where(x => x.OrderId == orderId).ToList());
        }
        public async Task<List<OrderDetailDto>> GetOrderDetailWithIncludes(string[] includes)
        {

            var orderDetails = await _OrderDetailRepository.GetAllWithIncludes(includes);

            var orderDetailDtos = _mapper.Map<List<OrderDetailDto>>(orderDetails.ToList());

            return orderDetailDtos;
        }
    }
}
