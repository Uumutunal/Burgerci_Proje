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

        public Task DeleteOrderDetail(Guid orderDetailId)
        {
            throw new NotImplementedException();
        }

        public Task<List<OrderDetailDto>> GetAllOrderDetails()
        {
            throw new NotImplementedException();
        }
    }
}
