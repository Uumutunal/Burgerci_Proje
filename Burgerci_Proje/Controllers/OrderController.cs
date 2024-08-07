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
            Guid.TryParse(HttpContext.Session.GetString("UserId"), out Guid userGuid);

            Guid userGuiddeneme = new Guid("B552F964-3A7E-44E8-B22E-D849EC558968");

            var allOrders = await _orderService.GetAllOrders();
            var userOrder = allOrders.FirstOrDefault(x => x.UserId == userGuiddeneme);

            if(userOrder != null)
            {
                var userOrderDetails = await _orderDetailService.GetAllOrderDetails(userOrder.Id);
                var mapped = _mapper.Map<List<OrderDetailViewModel>>(userOrderDetails);
                return View(mapped);
            }

            return View();

        }

        [HttpPost]
        public async Task<IActionResult> DeleteOrderDetail(Guid orderDetailId, Guid orderId)
        {
            await _orderDetailService.DeleteOrderDetail(orderDetailId);

            var orders = await _orderDetailService.GetAllOrderDetails(orderId);

            if(!orders.Any())
            {
                await _orderService.DeleteOrder(orderId);
            }

            return RedirectToAction("AllOrders");
        }


        //GUIDler deneme için eklendi
        [HttpPost]
        public async Task<IActionResult> AddMenuToOrder(MenuViewModel menuViewModel)
        {
            Guid.TryParse(HttpContext.Session.GetString("UserId"), out Guid userGuid);

            Guid userGuiddeneme = new Guid("B552F964-3A7E-44E8-B22E-D849EC558968");

            //var userOrder = orders.Where(x => x.UserId == userGuid).ToList();

            var activeOrder = await _orderService.GetActiveOrder(userGuiddeneme);

            if(activeOrder.Id == Guid.Empty)
            {
                var order = new OrderViewModel();
                

                order.UserId = userGuiddeneme;
                order.CreatedDate = DateTime.Now;
                order.Status = "active";
                order.IsActive = true;
                order.TotalPrice = menuViewModel.Price;

                var orderId = await _orderService.CreateOrder(_mapper.Map<OrderDto>(order));


                //Guid drinkDuid = new Guid("771459ef-ef8d-4a02-b5eb-6c446de04c74");


                var orderDetail = new OrderDetailViewModel();
                orderDetail.MenuId = menuViewModel.Id;
                orderDetail.OrderId = orderId;
                orderDetail.Price = menuViewModel.Price * menuViewModel.Quantity;
                orderDetail.DrinkId = menuViewModel.DrinkId;

                var orderDetailDto = _mapper.Map<OrderDetailDto>(orderDetail);


                await _orderDetailService.CreateOrderDetail(orderDetailDto);

            }
            else
            {


                var orderDetail = new OrderDetailViewModel();
                orderDetail.MenuId = menuViewModel.Id;
                orderDetail.OrderId = activeOrder.Id;

                //activeOrder.TotalPrice += menuViewModel.Price * menuViewModel.Quantity;
                //await _orderService.UpdateOrder(activeOrder);

                var orderDetailDto = _mapper.Map<OrderDetailDto>(orderDetail);
                await _orderDetailService.CreateOrderDetail(orderDetailDto);
            }



            return RedirectToAction("AllOrders");
        }

        [HttpPost]
        public async Task<IActionResult> AddHamburgerToOrder(HamburgerViewModel hamburgerViewModel)
        {
            Guid.TryParse(HttpContext.Session.GetString("UserId"), out Guid userGuid);

            var activeOrder = await _orderService.GetActiveOrder(userGuid);


            if (activeOrder.Id == Guid.Empty)
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

                var orderDetail = new OrderDetailViewModel();
                orderDetail.HamburgerId = hamburgerViewModel.Id;
                orderDetail.OrderId = activeOrder.Id;

                activeOrder.TotalPrice += hamburgerViewModel.Price * hamburgerViewModel.Quantity;
                await _orderService.UpdateOrder(activeOrder);

                var orderDetailDto = _mapper.Map<OrderDetailDto>(orderDetail);
                await _orderDetailService.CreateOrderDetail(orderDetailDto);
            }

            return View();
        }

        [HttpPost]
        public async Task<IActionResult> AddDrinkToOrder(DrinkViewModel drinkViewModel)
        {
            Guid.TryParse(HttpContext.Session.GetString("UserId"), out Guid userGuid);

            var activeOrder = await _orderService.GetActiveOrder(userGuid);


            if (activeOrder.Id == Guid.Empty)
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

                var orderDetail = new OrderDetailViewModel();
                orderDetail.DrinkId = drinkViewModel.Id;
                orderDetail.OrderId = activeOrder.Id;

                activeOrder.TotalPrice += drinkViewModel.Price * drinkViewModel.Quantity;
                await _orderService.UpdateOrder(activeOrder);

                var orderDetailDto = _mapper.Map<OrderDetailDto>(orderDetail);
                await _orderDetailService.CreateOrderDetail(orderDetailDto);
            }

            return View();
        }

        [HttpPost]
        public async Task<IActionResult> AddExtraToOrder(ExtraViewModel extraViewModel)
        {
            Guid.TryParse(HttpContext.Session.GetString("UserId"), out Guid userGuid);

            var activeOrder = await _orderService.GetActiveOrder(userGuid);


            if (activeOrder.Id == Guid.Empty)
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

                var orderDetail = new OrderDetailViewModel();
                orderDetail.ExtraId = extraViewModel.Id;
                orderDetail.OrderId = activeOrder.Id;

                activeOrder.TotalPrice += extraViewModel.Price * extraViewModel.Quantity;
                await _orderService.UpdateOrder(activeOrder);

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
