using AutoMapper;
using BLL.Abstract;
using BLL.DTOs;
using Burgerci_Proje.Models;
using Microsoft.AspNetCore.Mvc;

namespace Burgerci_Proje.Controllers
{
    public class OrderController : Controller
    {
        private readonly IOrderService _orderService;
        private readonly IOrderDetailService _orderDetailService;
        private readonly IMapper _mapper;
        public OrderController(IOrderService orderService, IMapper mapper, IOrderDetailService orderDetailService)
        {
            _orderService = orderService;
            _mapper = mapper;
            _orderDetailService = orderDetailService;
        }

        [HttpGet]
        public IActionResult Index(MenuViewModel menuViewModel)
        {
            return View(menuViewModel);
        }

        //Sepet
        //tüm orderları listele
        public async Task<IActionResult> AllOrders()
        {
            var allOrders = await _orderService.GetAllOrders();
            var mapped = _mapper.Map<List<OrderDto>>(allOrders);

            return View(mapped);
        }
        public async Task<IActionResult> DeleteOrderDetail(Guid orderId)
        {
            await _orderService.DeleteOrder(orderId);

            return RedirectToAction("AllOrders");
        }


        [HttpPost]
        public async Task<IActionResult> AddMenuToOrder(MenuViewModel menuViewModel)
        {
            Guid.TryParse(HttpContext.Session.GetString("UserId"), out Guid userGuid);

            var orders = await _orderService.GetAllOrders();
            //TODO:ordera tamamlanıp tamamlanmadığını ekle
            var userOrder = orders.Where(x => x.UserId == userGuid).ToList();

            if(userOrder.Count == 0)
            {
                var order = new OrderViewModel();

                order.UserId = userGuid;

                await _orderService.CreateOrder(_mapper.Map<OrderDto>(order));

                var orderDetail = new OrderDetailViewModel();
                orderDetail.MenuId = menuViewModel.Id;
                orderDetail.OrderId = order.Id;

                var orderDetailDto = _mapper.Map<OrderDetailDto>(orderDetail);
                await _orderDetailService.CreateOrderDetail(orderDetailDto);

            }
            else
            {
                var orderDetail = new OrderDetailViewModel();
                orderDetail.MenuId = menuViewModel.Id;
                orderDetail.OrderId = userOrder.FirstOrDefault().Id;

                var orderDetailDto = _mapper.Map<OrderDetailDto>(orderDetail);
                await _orderDetailService.CreateOrderDetail(orderDetailDto);
            }



            return View();
        }

    }
}
