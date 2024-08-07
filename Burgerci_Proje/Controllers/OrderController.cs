using AutoMapper;
using BLL.Abstract;
using BLL.DTOs;
using Burgerci_Proje.Models;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

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
        public IActionResult Index()
        {
            var menuDataJson = TempData["MenuData"] as string;
            var menuViewModel = JsonConvert.DeserializeObject<MenuViewModel>(menuDataJson);

            return View(menuViewModel);
        }

        //Sepet
        //tüm orderları listele
        [HttpGet]
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


        //GUIDler deneme için eklendi
        [HttpPost]
        public async Task<IActionResult> AddMenuToOrder(MenuViewModel menuViewModel)
        {
            Guid.TryParse(HttpContext.Session.GetString("UserId"), out Guid userGuid);

            Guid userGuiddeneme = new Guid("97A7EFFD-490D-4673-9C91-8F0C2401EFF4");

            //var userOrder = orders.Where(x => x.UserId == userGuid).ToList();

            var activeOrders = await _orderService.GetActiveOrder(userGuiddeneme);

            if(activeOrders.Count == 0)
            {
                var order = new OrderViewModel();
                
                Guid orderGuid = new Guid("22DAAD28-A7FE-4D6A-7FC0-08DCB640D8A5");

                order.UserId = userGuiddeneme;
                order.CreatedDate = DateTime.Now;
                order.Status = "active";
                order.IsActive = true;
                order.TotalPrice = menuViewModel.Price;

                await _orderService.CreateOrder(_mapper.Map<OrderDto>(order));


                Guid drinkDuid = new Guid("771459ef-ef8d-4a02-b5eb-6c446de04c74");


                var orderDetail = new OrderDetailViewModel();
                orderDetail.MenuId = menuViewModel.Id;
                orderDetail.OrderId = orderGuid;
                orderDetail.Price = menuViewModel.Price * menuViewModel.Quantity;
                orderDetail.DrinkId = drinkDuid;

                var orderDetailDto = _mapper.Map<OrderDetailDto>(orderDetail);


                await _orderDetailService.CreateOrderDetail(orderDetailDto);

            }
            else
            {

                var order = activeOrders.FirstOrDefault();

                var orderDetail = new OrderDetailViewModel();
                orderDetail.MenuId = menuViewModel.Id;
                orderDetail.OrderId = order.Id;

                order.TotalPrice += menuViewModel.Price * menuViewModel.Quantity;
                await _orderService.UpdateOrder(order);

                var orderDetailDto = _mapper.Map<OrderDetailDto>(orderDetail);
                await _orderDetailService.CreateOrderDetail(orderDetailDto);
            }



            return View();
        }

        [HttpPost]
        public async Task<IActionResult> AddHamburgerToOrder(HamburgerViewModel hamburgerViewModel)
        {
            Guid.TryParse(HttpContext.Session.GetString("UserId"), out Guid userGuid);

            var activeOrders = await _orderService.GetActiveOrder(userGuid);


            if (activeOrders.Count == 0)
            {
                var order = new OrderViewModel();

                order.UserId = userGuid;

                await _orderService.CreateOrder(_mapper.Map<OrderDto>(order));

                var orderDetail = new OrderDetailViewModel();
                orderDetail.HamburgerId = hamburgerViewModel.Id;
                orderDetail.OrderId = order.Id;
                orderDetail.Price = hamburgerViewModel.Price * hamburgerViewModel.Quantity;

                order.OrderDetailViewModels.Add(orderDetail);

                var orderDetailDto = _mapper.Map<OrderDetailDto>(orderDetail);
                await _orderDetailService.CreateOrderDetail(orderDetailDto);

            }
            else
            {
                var order = activeOrders.FirstOrDefault();

                var orderDetail = new OrderDetailViewModel();
                orderDetail.HamburgerId = hamburgerViewModel.Id;
                orderDetail.OrderId = order.Id;

                order.TotalPrice += hamburgerViewModel.Price * hamburgerViewModel.Quantity;
                await _orderService.UpdateOrder(order);

                var orderDetailDto = _mapper.Map<OrderDetailDto>(orderDetail);
                await _orderDetailService.CreateOrderDetail(orderDetailDto);
            }

            return View();
        }

        [HttpPost]
        public async Task<IActionResult> AddDrinkToOrder(DrinkViewModel drinkViewModel)
        {
            Guid.TryParse(HttpContext.Session.GetString("UserId"), out Guid userGuid);

            var activeOrders = await _orderService.GetActiveOrder(userGuid);


            if (activeOrders.Count == 0)
            {
                var order = new OrderViewModel();

                order.UserId = userGuid;

                await _orderService.CreateOrder(_mapper.Map<OrderDto>(order));

                var orderDetail = new OrderDetailViewModel();
                orderDetail.DrinkId = drinkViewModel.Id;
                orderDetail.OrderId = order.Id;
                orderDetail.Price = drinkViewModel.Price * drinkViewModel.Quantity;

                order.OrderDetailViewModels.Add(orderDetail);

                var orderDetailDto = _mapper.Map<OrderDetailDto>(orderDetail);
                await _orderDetailService.CreateOrderDetail(orderDetailDto);

            }
            else
            {
                var order = activeOrders.FirstOrDefault();

                var orderDetail = new OrderDetailViewModel();
                orderDetail.DrinkId = drinkViewModel.Id;
                orderDetail.OrderId = order.Id;

                order.TotalPrice += drinkViewModel.Price * drinkViewModel.Quantity;
                await _orderService.UpdateOrder(order);

                var orderDetailDto = _mapper.Map<OrderDetailDto>(orderDetail);
                await _orderDetailService.CreateOrderDetail(orderDetailDto);
            }

            return View();
        }

        [HttpPost]
        public async Task<IActionResult> AddExtraToOrder(ExtraViewModel extraViewModel)
        {
            Guid.TryParse(HttpContext.Session.GetString("UserId"), out Guid userGuid);

            var activeOrders = await _orderService.GetActiveOrder(userGuid);


            if (activeOrders.Count == 0)
            {
                var order = new OrderViewModel();

                order.UserId = userGuid;

                await _orderService.CreateOrder(_mapper.Map<OrderDto>(order));

                var orderDetail = new OrderDetailViewModel();
                orderDetail.ExtraId = extraViewModel.Id;
                orderDetail.OrderId = order.Id;
                orderDetail.Price = extraViewModel.Price * extraViewModel.Quantity;

                order.OrderDetailViewModels.Add(orderDetail);

                var orderDetailDto = _mapper.Map<OrderDetailDto>(orderDetail);
                await _orderDetailService.CreateOrderDetail(orderDetailDto);

            }
            else
            {
                var order = activeOrders.FirstOrDefault();

                var orderDetail = new OrderDetailViewModel();
                orderDetail.ExtraId = extraViewModel.Id;
                orderDetail.OrderId = order.Id;

                order.TotalPrice += extraViewModel.Price * extraViewModel.Quantity;
                await _orderService.UpdateOrder(order);

                var orderDetailDto = _mapper.Map<OrderDetailDto>(orderDetail);
                await _orderDetailService.CreateOrderDetail(orderDetailDto);
            }

            return View();
        }


        [HttpPost]
        public async Task<IActionResult> ApproveOrder(OrderViewModel orderViewModel)
        {
            await _orderService.ApproveOrder(orderViewModel.Id);

            return RedirectToAction("AllOrders");

        }

        [HttpPost]
        public async Task<IActionResult> DeleteOrder(OrderViewModel orderViewModel)
        {
            await _orderService.DeleteOrder(orderViewModel.Id);

            return RedirectToAction("AllOrders");

        }

    }
}
