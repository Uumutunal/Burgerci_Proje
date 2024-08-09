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
        private readonly IHamburgerService _hamburgerService;
        private readonly IMapper _mapper;
        public OrderController(IOrderService orderService, IMapper mapper, IOrderDetailService orderDetailService, IHamburgerService hamburgerService)
        {
            _orderService = orderService;
            _mapper = mapper;
            _orderDetailService = orderDetailService;
            _hamburgerService = hamburgerService;
        }

        [HttpGet]
        public IActionResult OrderMenu()
        {
            var menuDataJson = TempData["MenuData"] as string;
            var menuDto = JsonConvert.DeserializeObject<MenuDto>(menuDataJson);
            var menuViewModel = _mapper.Map<MenuViewModel>(menuDto);

            return View(menuViewModel);
        }

        [HttpGet]
        public IActionResult OrderHamburger()
        {
            var hamburgerDataJson = TempData["HamburgerData"] as string;
            var hamburgerDto = JsonConvert.DeserializeObject<HamburgerDto>(hamburgerDataJson);
            var hamburgerViewModel = _mapper.Map<HamburgerViewModel>(hamburgerDto);

            return RedirectToAction("AddHamburgerToOrder");
        }
        [HttpGet]
        public IActionResult OrderDrink()
        {
            var drinkDataJson = TempData["DrinkData"] as string;
            var drinkDto = JsonConvert.DeserializeObject<DrinkDto>(drinkDataJson);
            var drinkViewModel = _mapper.Map<DrinkViewModel>(drinkDto);

            return RedirectToAction("AddDrinkToOrder");
        }
        [HttpGet]
        public IActionResult OrderExtra()
        {
            var extraDataJson = TempData["ExtraData"] as string;
            var extraDto = JsonConvert.DeserializeObject<ExtraDto>(extraDataJson);
            var extraViewModel = _mapper.Map<ExtraViewModel>(extraDto);

            return RedirectToAction("AddExtraToOrder");
        }

        //Sepet
        //tüm orderları listele
        [HttpGet]
        public async Task<IActionResult> AllOrders()
        {
            Guid.TryParse(HttpContext.Session.GetString("UserId"), out Guid userGuid);


            var allOrders = await _orderService.GetAllOrders();
            var userOrder = allOrders.FirstOrDefault(x => x.UserId == userGuid);

            if(userOrder != null)
            {

                var OrderDetailsInclude = await _orderDetailService.GetOrderDetailWithIncludes(new[]{"Hamburger", "Drink", "Extra", "Menu"});

                var userOrderDetails = OrderDetailsInclude.Where(x => x.OrderId == userOrder.Id);


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


        [HttpPost]
        public async Task<IActionResult> AddMenuToOrder(MenuViewModel menuViewModel)
        {
            Guid.TryParse(HttpContext.Session.GetString("UserId"), out Guid userGuid);


            var activeOrder = await _orderService.GetActiveOrder(userGuid);

            if(activeOrder == null || activeOrder.Id == Guid.Empty)
            {
                var order = new OrderViewModel();
                

                order.UserId = userGuid;
                order.CreatedDate = DateTime.Now;
                order.Status = "active";
                order.IsActive = true;
                order.TotalPrice = menuViewModel.Price;

                var orderId = await _orderService.CreateOrder(_mapper.Map<OrderDto>(order));


                var orderDetail = new OrderDetailViewModel();
                orderDetail.MenuId = menuViewModel.Id;
                orderDetail.OrderId = orderId;
                orderDetail.Price = menuViewModel.Price * menuViewModel.Quantity;
                orderDetail.DrinkId = menuViewModel.DrinkId;
                orderDetail.Quantity = menuViewModel.Quantity;
                orderDetail.Size = menuViewModel.Size;


                var orderDetailDto = _mapper.Map<OrderDetailDto>(orderDetail);


                await _orderDetailService.CreateOrderDetail(orderDetailDto);

            }
            else
            {
                var orderDetail = new OrderDetailViewModel();
                orderDetail.MenuId = menuViewModel.Id;
                orderDetail.OrderId = activeOrder.Id;
                orderDetail.Price = menuViewModel.Price * menuViewModel.Quantity;
                orderDetail.Quantity = menuViewModel.Quantity;
                orderDetail.Size = menuViewModel.Size;

                activeOrder.TotalPrice += menuViewModel.Price * menuViewModel.Quantity;
                await _orderService.UpdateOrder(activeOrder);

                var orderDetailDto = _mapper.Map<OrderDetailDto>(orderDetail);
                await _orderDetailService.CreateOrderDetail(orderDetailDto);
            }



            return RedirectToAction("AllOrders");
        }


        [HttpGet]
        public async Task<IActionResult> AddHamburgerToOrder()
        {
            var hamburgerDataJson = TempData["HamburgerData"] as string;
            var hamburgerDto = JsonConvert.DeserializeObject<HamburgerDto>(hamburgerDataJson);
            var hamburgerViewModel = _mapper.Map<HamburgerViewModel>(hamburgerDto);

            Guid.TryParse(HttpContext.Session.GetString("UserId"), out Guid userGuid);

            var activeOrder = await _orderService.GetActiveOrder(userGuid);


            if (activeOrder == null || activeOrder.Id == Guid.Empty)
            {
                var order = new OrderViewModel();


                order.UserId = userGuid;
                order.CreatedDate = DateTime.Now;
                order.Status = "active";
                order.IsActive = true;
                order.TotalPrice = hamburgerViewModel.Price;

                var orderId = await _orderService.CreateOrder(_mapper.Map<OrderDto>(order));


                var orderDetail = new OrderDetailViewModel();
                orderDetail.HamburgerId = hamburgerViewModel.Id;
                orderDetail.OrderId = orderId;
                orderDetail.Price = hamburgerViewModel.Price * hamburgerViewModel.Quantity;
                orderDetail.Quantity = hamburgerViewModel.Quantity;
                orderDetail.Size = hamburgerViewModel.Size;



                var orderDetailDto = _mapper.Map<OrderDetailDto>(orderDetail);


                await _orderDetailService.CreateOrderDetail(orderDetailDto);

            }
            else
            {

                var orderDetail = new OrderDetailViewModel();
                orderDetail.HamburgerId = hamburgerViewModel.Id;
                orderDetail.OrderId = activeOrder.Id;
                orderDetail.Quantity = hamburgerViewModel.Quantity;
                orderDetail.Price = hamburgerViewModel.Price * hamburgerViewModel.Quantity;
                orderDetail.Size = hamburgerViewModel.Size;


                activeOrder.TotalPrice += hamburgerViewModel.Price * hamburgerViewModel.Quantity;
                await _orderService.UpdateOrder(activeOrder);

                var orderDetailDto = _mapper.Map<OrderDetailDto>(orderDetail);
                await _orderDetailService.CreateOrderDetail(orderDetailDto);
            }

            return RedirectToAction("AllOrders");
        }

        [HttpGet]
        public async Task<IActionResult> AddDrinkToOrder()
        {

            var drinkDataJson = TempData["DrinkData"] as string;
            var drinkDto = JsonConvert.DeserializeObject<DrinkDto>(drinkDataJson);
            var drinkViewModel = _mapper.Map<DrinkViewModel>(drinkDto);

            Guid.TryParse(HttpContext.Session.GetString("UserId"), out Guid userGuid);

            var activeOrder = await _orderService.GetActiveOrder(userGuid);


            if (activeOrder == null || activeOrder.Id == Guid.Empty)
            {
                var order = new OrderViewModel();
                

                order.UserId = userGuid;
                order.CreatedDate = DateTime.Now;
                order.Status = "active";
                order.IsActive = true;
                order.TotalPrice = drinkViewModel.Price;

                var orderId = await _orderService.CreateOrder(_mapper.Map<OrderDto>(order));


                var orderDetail = new OrderDetailViewModel();
                orderDetail.DrinkId = drinkViewModel.Id;
                orderDetail.OrderId = orderId;
                orderDetail.Price = drinkViewModel.Price * drinkViewModel.Quantity;
                orderDetail.Quantity = drinkViewModel.Quantity;
                orderDetail.Size = drinkViewModel.Size;



                var orderDetailDto = _mapper.Map<OrderDetailDto>(orderDetail);


                await _orderDetailService.CreateOrderDetail(orderDetailDto);

            }
            else
            {

                var orderDetail = new OrderDetailViewModel();
                orderDetail.DrinkId = drinkViewModel.Id;
                orderDetail.OrderId = activeOrder.Id;
                orderDetail.Quantity = drinkViewModel.Quantity;
                orderDetail.Price = drinkViewModel.Price * drinkViewModel.Quantity;
                orderDetail.Size = drinkViewModel.Size;

                activeOrder.TotalPrice += drinkViewModel.Price * drinkViewModel.Quantity;
                await _orderService.UpdateOrder(activeOrder);

                var orderDetailDto = _mapper.Map<OrderDetailDto>(orderDetail);
                await _orderDetailService.CreateOrderDetail(orderDetailDto);
            }

            return RedirectToAction("AllOrders");
        }

        [HttpGet]
        public async Task<IActionResult> AddExtraToOrder()
        {
            var extraDataJson = TempData["ExtraData"] as string;
            var extraDto = JsonConvert.DeserializeObject<ExtraDto>(extraDataJson);
            var extraViewModel = _mapper.Map<ExtraViewModel>(extraDto);


            Guid.TryParse(HttpContext.Session.GetString("UserId"), out Guid userGuid);

            var activeOrder = await _orderService.GetActiveOrder(userGuid);


            if (activeOrder == null || activeOrder.Id == Guid.Empty)
            {
                var order = new OrderViewModel();


                order.UserId = userGuid;
                order.CreatedDate = DateTime.Now;
                order.Status = "active";
                order.IsActive = true;
                order.TotalPrice = extraViewModel.Price;

                var orderId = await _orderService.CreateOrder(_mapper.Map<OrderDto>(order));


                var orderDetail = new OrderDetailViewModel();
                orderDetail.ExtraId = extraViewModel.Id;
                orderDetail.OrderId = orderId;
                orderDetail.Price = extraViewModel.Price * extraViewModel.Quantity;
                orderDetail.Quantity = extraViewModel.Quantity;
                orderDetail.Size = extraViewModel.Size;


                var orderDetailDto = _mapper.Map<OrderDetailDto>(orderDetail);


                await _orderDetailService.CreateOrderDetail(orderDetailDto);

            }
            else
            {

                var orderDetail = new OrderDetailViewModel();
                orderDetail.ExtraId = extraViewModel.Id;
                orderDetail.OrderId = activeOrder.Id;
                orderDetail.Quantity = extraViewModel.Quantity;
                orderDetail.Price = extraViewModel.Price * extraViewModel.Quantity;
                orderDetail.Size = extraViewModel.Size;

                activeOrder.TotalPrice += extraViewModel.Price * extraViewModel.Quantity;
                await _orderService.UpdateOrder(activeOrder);

                var orderDetailDto = _mapper.Map<OrderDetailDto>(orderDetail);
                await _orderDetailService.CreateOrderDetail(orderDetailDto);
            }

            return RedirectToAction("AllOrders");
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

        [HttpPost]
        public async Task<IActionResult> ConfirmOrder(Guid id)
        {
            var orderInclude = await _orderService.GetOrderWithIncludes(new[] { "OrderDetails" });

            var activeOrder = orderInclude.FirstOrDefault(x => x.Id == id);




            if (activeOrder != null)
            {
                var isMenuSelected = activeOrder.OrderDetailDtos.Any(x => x.MenuId == Guid.Empty || x.HamburgerId == Guid.Empty);

                if (!isMenuSelected)
                {
                    activeOrder.IsActive = false;
                    await _orderService.UpdateOrder(activeOrder);
                }


            }



            return RedirectToAction("AllOrders");

        }

    }
}
