using Microsoft.AspNetCore.Mvc;
using Lesson05_Models.Models.DataModels;

namespace Lesson05_Models.Controllers
{
    public class NqtMemberController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult NqtGetMember()
        {
            var NqtMember = new NqtMember();
            NqtMember.NqtMemberId = Guid.NewGuid().ToString();
            NqtMember.NqtUserName = "nqtam6666";
            NqtMember.NqtFullName = "Nguyên Quang Tâm";
            NqtMember.NqtPassword = "11111";
            NqtMember.NqtEmail = "nguyenquangtam179@gmail.com";

            ViewBag.NqtMember = NqtMember;
            return View();
        }
    }
}