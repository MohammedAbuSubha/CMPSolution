using CMP.Business.DTO.Complaint;
using CMP.DataAccess.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Data.Entity;
using CMP.Infrastructure.Common.Enums;

namespace CMP.Business.Services.Complaint
{
    public class ComplaintService : BaseService
    {
        public List<ComplaintViewModel> GetComplaints(string userId, bool isAdmin = false)
        {
            using (ApplicationDbContext applicationDbContext = new ApplicationDbContext())
            {
                if (!isAdmin)
                {
                    return AutoMapper.AutoMapperConfiguration.Mapper.Map<List<ComplaintViewModel>>(applicationDbContext.Complaints
                        .Include(a => a.CreateByUser)
                        .Include(c => c.ComplaintStatuses)
                        .Where(c => c.CreateBy == userId)
                        .OrderByDescending(o => o.CreateOn)
                        .ToList());
                }
                else
                {
                    return AutoMapper.AutoMapperConfiguration.Mapper.Map<List<ComplaintViewModel>>(applicationDbContext.Complaints
                        .Include(a => a.CreateByUser)
                        .Include(c => c.ComplaintStatuses)
                        .OrderByDescending(o => o.CreateOn)
                        .ToList());
                }
            }
        }

        public async Task<int> Create(ComplaintViewModel complaintViewModel, string createdBy)
        {
            using (ApplicationDbContext applicationDbContext = new ApplicationDbContext())
            {
                var complaint = AutoMapper.AutoMapperConfiguration.Mapper.Map<CMP.DataAccess.Model.Complaint>(complaintViewModel);

                complaint.CreateBy = createdBy;
                complaint.CreateOn = DateTime.Now;
                complaint.ComplaintStatuses.Add(new ComplaintStatus()
                {
                    ComplaintId = complaint.Id,
                    CreateBy = createdBy,
                    CreateOn = DateTime.Now,
                    Status = (int)ComplaintStatusEnum.Pending
                });

                applicationDbContext.Complaints.Add(complaint);
                return await applicationDbContext.SaveChangesAsync();
            }
        }

        public void UpdateStatus(int complaintId, int statusId, string createdBy)
        {
            using (ApplicationDbContext applicationDbContext = new ApplicationDbContext())
            {
                var existingComplaint = applicationDbContext.Complaints.FirstOrDefault(a => a.Id == complaintId);

                if(existingComplaint != null)
                {
                    applicationDbContext.ComplaintStatuses.Add(new ComplaintStatus()
                    {
                        ComplaintId = complaintId,
                        CreateBy = createdBy,
                        CreateOn = DateTime.Now,
                        Status = statusId
                    });

                    applicationDbContext.SaveChanges();
                }
            }
        }

        public ComplaintViewModel Get(int complaintId)
        {
            using (ApplicationDbContext applicationDbContext = new ApplicationDbContext())
            {
                return AutoMapper.AutoMapperConfiguration.Mapper.Map<ComplaintViewModel>(applicationDbContext.Complaints
                        .Include(a => a.CreateByUser)
                        .Include(c => c.ComplaintStatuses)
                        .FirstOrDefault(c => c.Id == complaintId));
            }
        }
    }
}
