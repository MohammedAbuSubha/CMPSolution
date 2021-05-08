using CMP.Business.DTO.Identity;
using CMP.Business.Services.Identity;
using CMP.DataAccess.Model;
using Microsoft.AspNet.Identity.Owin;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;

namespace CMP.Web.Controllers
{
    [Authorize(Roles = "Admin")]
    public class UserController : Controller
    {
        public UserController()
        {
        }

        public ApplicationUserManager UserManager { get; set; }

        [Authorize(Roles = "Admin")]
        // GET: User
        public ActionResult Index()
        {
            using (IdentityService identityService = new IdentityService())
            {
                return View(identityService.GetUsers());
            }
        }
        // Post: User
        [System.Web.Http.HttpPost]
        public async Task<JsonResult> Create(RegisterViewModel user)
        {
            try
            {
                var applicationUser = new ApplicationUser { UserName = user.Email, Email = user.Email, RoleId = user.RoleId };
                var result = await HttpContext.GetOwinContext().GetUserManager<ApplicationUserManager>().CreateAsync(applicationUser, user.Password);

                if (result.Succeeded)
                {
                    using (IdentityService identityService = new IdentityService())
                    {
                        await identityService.CreateNewUser(user.Email, user.RoleId);
                    }

                }

                return Json("Success", JsonRequestBehavior.AllowGet);
            }
            catch (System.Exception ex)
            {

                throw;
            }
        }
    }
}