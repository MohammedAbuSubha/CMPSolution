using CMP.Business.DTO.Complaint;
using CMP.Business.Services.Complaint;
using Microsoft.AspNet.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;

namespace CMP.Web.Controllers
{
    [Authorize]
    public class ComplaintController : Controller
    {
        // GET: Complaint
        public ActionResult ComplaintsList()
        {
            using (ComplaintService complaintService = new ComplaintService())
            {
                return View(complaintService.GetComplaints(User.Identity.GetUserId(), User.IsInRole("Admin")));
            }
        }

        // Post: Complaint
        [System.Web.Http.HttpPost]
        public async Task<JsonResult> Create(ComplaintViewModel complaint)
        {
            try
            {
                using (ComplaintService complaintService = new ComplaintService())
                {
                  await complaintService.Create(complaint, User.Identity.GetUserId());
                }

                return Json("Success", JsonRequestBehavior.AllowGet);
            }
            catch (System.Exception ex)
            {

                throw;
            }
        }

        // Get: Complaint
        [System.Web.Http.HttpGet]
        public JsonResult Get(int complaintId)
        {
            try
            {
                using (ComplaintService complaintService = new ComplaintService())
                {
                    return Json(complaintService.Get(complaintId), JsonRequestBehavior.AllowGet);
                }

            }
            catch (System.Exception ex)
            {

                throw;
            }
        }

        [Authorize(Roles = "Admin")]
        [System.Web.Http.HttpPost]
        public JsonResult UpdateStatus(int complaintId, int statusId)
        {
            try
            {
                using (ComplaintService complaintService = new ComplaintService())
                {
                    complaintService.UpdateStatus(complaintId, statusId, User.Identity.GetUserId());

                    return Json("Success", JsonRequestBehavior.AllowGet);
                }
            }
            catch (System.Exception ex)
            {

                throw;
            }
        }
        
    }
}