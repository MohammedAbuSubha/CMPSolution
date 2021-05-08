using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CMP.DataAccess.Model
{
    public  class ComplaintStatus
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        public int ComplaintId { get; set; }
        public int Status { get; set; }
        public string CreateBy { get; set; }
        public DateTime CreateOn { get; set; }
        [ForeignKey(nameof(CreateBy))]
        public virtual ApplicationUser CreateByUser { get; set; }

    }
}
