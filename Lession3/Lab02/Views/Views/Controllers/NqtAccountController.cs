using Microsoft.AspNetCore.Mvc;
using Microsoft.VisualStudio.Web.CodeGenerators.Mvc.Templates.BlazorIdentity.Pages.Manage;
using System.Xml.Linq;
using Views.Models;
namespace Views.Controllers
{
	public class NqtAccountController : Controller
	{
		public IActionResult NqtIndex()
		{
			List<NqtAccount> accounts = new List<NqtAccount>
			{
				new NqtAccount()
				{
					Id = 1,
					Name = "Nguyễn Quang Tâm",
					Email = "nguyenquangtam6666@gmail.com",
					Addess = "VN",
					Phone = "0",
					Avatar = "img/Avatar/01.png",
					Bio = "0",
					Gender = "0",
				}
			};
			ViewBag.Accounts = accounts;
			return View();
		}
		[Route("ho-so-cua-toi", Name = "profile")]
		public IActionResult NqtProfile(int id)
		{
			List<NqtAccount> accounts = new List<NqtAccount>

			{
				new NqtAccount()
				{
					Id = 1,
					Name = "Nguyễn Quang Tâm",
					Email = "nguyenquangtam6666@gmail.com",
					Addess = "VN",
					Phone = "0",
					Avatar = "img/Avatar/01.png",
					Bio = "0",
					Gender = "0",
					Bithday = DateTime.Parse("2005-06-26"),
				}

			};
			NqtAccount account = accounts.FirstOrDefault(ac => ac.Id == id);
			ViewBag.Account = account;
			return View();
		}
	}
}
