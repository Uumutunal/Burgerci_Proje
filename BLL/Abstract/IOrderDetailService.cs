using BLL.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.Abstract
{
    public interface IOrderDetailService
    {
        Task<List<OrderDetailDto>> GetAllOrderDetails(Guid orderId);
        Task CreateOrderDetail(OrderDetailDto orderDetailDto);
        Task DeleteOrderDetail(Guid orderDetailId);
        Task<List<OrderDetailDto>> GetOrderDetailWithIncludes(string[] includes);
    }
}
