using MStrudel.Domain.Abstract;
using MStrudel.Domain.Entities;
using MStrudel.WebUI.Models;
using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;

namespace MStrudel.WebUI.Controllers
{
    public class OrderController : Controller
    {
        private IOrderRepository _orderRepository;
        private IOrderProcessor _orderProcessor;

        public OrderController(IOrderRepository orderRepo, IOrderProcessor proc)
        {
            _orderRepository = orderRepo;
            _orderProcessor = proc;
        }

        [HttpGet]
        public ViewResult Index()
        {
            return View(_orderRepository.Orders.OrderByDescending(o => o.DeliveryTime).ToList());
        }

        [HttpDelete]
        public ActionResult Delete(int orderId)
        {
            _orderRepository.DeleteOrder(orderId);
            return RedirectToAction("Index");
        }

        public ViewResult AddOrder(Cart cart)
        {
            return View(new OrderListViewModel { Cart = cart, Order = new Order() });
        }

        [HttpPost]
        public ActionResult AddOrder(OrderListViewModel model, Cart cart)
        {
            // Change to some message
            if(cart.Lines.Count() == 0)
            {
                ModelState.AddModelError("", "Вибачте, Ваша корзина порожня! Неможливо зареєструвати замовлення");
            }

            if(ModelState.IsValid)
            {
                Order order = new Order { OrderedProducts = new List<OrderedProduct>() };
                order.Name = model.Order.Name;
                order.LastName = model.Order.LastName;
                order.Phone = model.Order.Phone;
                order.DeliveryTime = model.Order.DeliveryTime;
                order.Adress = model.Order.Adress;
                order.Comment = model.Order.Comment;

                foreach(var cartLine in cart.Lines)
                {
                    order.OrderedProducts.Add(new OrderedProduct { Price = cartLine.Product.Price, Quantity = cartLine.Quantity, ProductId = cartLine.Product.ProductID });
                }

                _orderRepository.SaveOrder(order);
                _orderProcessor.ProcessOrder(order, cart);

                cart.Clear();

                return RedirectToAction("Completed");
            }
            return RedirectToAction("Index", "Product");
        }

        public ViewResult Completed()
        {
            return View("Completed");
        }
    }
}
