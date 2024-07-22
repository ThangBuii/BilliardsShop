using Client.WebRequests;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Share.DTO.OrderDTO;
using Share.DTO.ProductDTO;
using Share.DTO.UserDTO;
using Share.Models;
using System.IdentityModel.Tokens.Jwt;
using System.Text.Json;

namespace Client.Pages
{
	public class CheckOutModel : PageModel
	{
		private readonly IHttpContextAccessor _httpContext;
		private readonly ICustomHttpClient _request;

		public CheckOutModel(IHttpContextAccessor httpContext, ICustomHttpClient request)
		{
			_httpContext = httpContext;
			_request = request;
			Carts = new List<ProductCartDTO>();
			SubTotal = 0;
		}
		public List<ProductCartDTO> Carts { get; set; }
		public int SubTotal { get; set; }

		[BindProperty]
		public string Address { get; set; }
		[BindProperty]
		public string Note { get; set; }
		public void OnGet()
		{
			var cartsJson = HttpContext.Session.GetString("Carts");
			var subTotalJson = HttpContext.Session.GetString("SubTotal");
			Carts = JsonSerializer.Deserialize<List<ProductCartDTO>>(cartsJson);
			SubTotal = JsonSerializer.Deserialize<int>(subTotalJson);


		}

		public async Task<IActionResult> OnPostAsync()
		{
			var userIdString = HttpContext.Session.GetString("userId");
			if (string.IsNullOrEmpty(userIdString) || !int.TryParse(userIdString, out var userId))
			{
				// If userId is not found or is invalid, redirect to error page
				return Redirect("/Error404");
			}
			var cartsJson = HttpContext.Session.GetString("Carts");
			var subTotalJson = HttpContext.Session.GetString("SubTotal");
			Carts = JsonSerializer.Deserialize<List<ProductCartDTO>>(cartsJson);
			SubTotal = JsonSerializer.Deserialize<int>(subTotalJson);
			AddOrderDTO order = new AddOrderDTO
			{
				Date = DateTime.Now,
				Note = Note,
				UserId = userId,
				ShippingAddress = Address,
				Status = 0,
				Total = SubTotal,
			};
			var response = await _request.PostJsonAsync("https://localhost:5000/api/Order", order);
			if (!response.IsSuccessStatusCode)
			{
				return Redirect("/Error404");
			}
			var orderRes = await response.Content.ReadFromJsonAsync<Order>();
			foreach (var product in Carts)
			{
				var orderDetail = new AddOrderDetailDTO
				{
					OrderId = orderRes.Id,
					ProductId = product.Id,
					Quantity = product.Quantity,
					UnitPrice = product.Price,

				};
				var response1 = await _request.PostJsonAsync("https://localhost:5000/api/OrderDetail", orderDetail);
				if (!response1.IsSuccessStatusCode)
				{
					return Redirect("/Error404");
				}

			}
			HttpContext.Session.Remove("Carts");
			HttpContext.Session.Remove("SubTotal");
			HttpContext.Session.Remove("cart");

			return Redirect("/Account/Order/Index");


		}
	}
}
