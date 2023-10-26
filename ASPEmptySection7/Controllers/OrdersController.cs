using ASPEmptySection7.Models;
using Microsoft.AspNetCore.Mvc;

namespace ASPEmptySection7.Controllers
{
    public class OrdersController : Controller
    {
        [HttpPost]
        [Route("/order")]
        public IActionResult Index(Order order)
        {
            if (!ModelState.IsValid)
            {
                string errors = string.Join("\n",ModelState.Values
                    .SelectMany(value => value.Errors)
                    .Select(err => err.ErrorMessage));
                return BadRequest(errors);
            }
            Random r = new();
            order.OrderNo = r.Next(1, 99999);
            return Json(order.OrderNo);
        }
    }
}
