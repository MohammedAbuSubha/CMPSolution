using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CMP.DataAccess.Model
{
    public class Complaint
    {
        public Complaint()
        {
            ComplaintStatuses = new HashSet<ComplaintStatus>();
        }
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        public string Title { get; set; }
        public int CategoryId { get; set; }
        public string Description { get; set; }
        public bool IsClosedByCustomer { get; set; }
        public string CreateBy { get; set; }
        public DateTime CreateOn { get; set; }

        [ForeignKey(nameof(CreateBy))]
        public ApplicationUser CreateByUser { get; set; }
        public ICollection<ComplaintStatus> ComplaintStatuses { get; set; }
    }
}
