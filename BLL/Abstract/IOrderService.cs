﻿using BLL.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.Abstract
{
    public interface IOrderService
    {
        Task<List<OrderDto>> GetAllOrders();
        Task<Guid> CreateOrder(OrderDto orderDto);
        Task DeleteOrder(Guid orderId);
        Task AddOrderDetail(Guid orderDetailId);
        Task ApproveOrder(Guid orderId);
        Task UpdateOrder(OrderDto orderDto);
        Task<OrderDto> GetActiveOrder(Guid userId);
        Task<OrderDto> GetById(Guid orderId);
        Task<List<OrderDto>> GetOrderWithIncludes(string[] includes);

    }
}
