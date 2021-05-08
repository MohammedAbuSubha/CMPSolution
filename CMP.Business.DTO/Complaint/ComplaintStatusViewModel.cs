using CMP.Business.DTO.Identity;
using System;

namespace CMP.Business.DTO.Complaint
{
    public class ComplaintStatusViewModel
    {
        public int Id { get; set; }
        public int ComplaintId { get; set; }
        public int Status { get; set; }
        public string CreateBy { get; set; }
        public DateTime CreateOn { get; set; }
        public ComplaintViewModel Complaint { get; set; }
        public UserViewModel CreateByUser { get; set; }
    }
}
