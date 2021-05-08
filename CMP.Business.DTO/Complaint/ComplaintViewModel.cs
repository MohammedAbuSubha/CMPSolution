using CMP.Business.DTO.Identity;
using CMP.Infrastructure.Common.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CMP.Business.DTO.Complaint
{
    public class ComplaintViewModel
    {
        public ComplaintViewModel()
        {
            ComplaintStatuses = new List<ComplaintStatusViewModel>();
        }
        public int Id { get; set; }
        public string Title { get; set; }
        public int CategoryId { get; set; }
        public string CategoryText { 
            get {
                switch ((ComplaintCategoryEnum)CategoryId)
                {
                    case ComplaintCategoryEnum.WebSiteIssue:
                        return "Web Site Issue";
                    case ComplaintCategoryEnum.CustomerServiceIssue:
                        return "Customer Service Issue";

                    case ComplaintCategoryEnum.ContentIssue:
                        return "Content Issue";
                    default:
                        return "Web Site Issue";

                }
            }
        }
        public string Description { get; set; }
        public bool IsClosedByCustomer { get; set; }
        public string CreateBy { get; set; }
        public DateTime CreateOn { get; set; }
        public string CreateOnFormattedString => CreateOn.ToString("dd/MM/yyyy HH:mm tt");

        public UserViewModel CreateByUser { get; set; }
        public string CreateByUserName { get; set; }
        public List<ComplaintStatusViewModel> ComplaintStatuses { get; set; }
        public int LastStatusId
        {
            get
            {
                if (ComplaintStatuses.Any())
                    return ComplaintStatuses.OrderByDescending(c => c.CreateOn).FirstOrDefault().Status;

                return (int)ComplaintStatusEnum.Pending;
            }
        }
        public string LastStatusText
        {
            get
            {
                switch ((ComplaintStatusEnum)LastStatusId)
                {
                    case ComplaintStatusEnum.Pending:
                        return "Pending";
                    case ComplaintStatusEnum.Resolution:
                        return "Resolution";
                    case ComplaintStatusEnum.Resolved:
                        return "Resolved";
                    case ComplaintStatusEnum.Dismissed:
                        return "Dismissed";
                    default:
                        return "Pending";
                }
            }
        }
    }
}
