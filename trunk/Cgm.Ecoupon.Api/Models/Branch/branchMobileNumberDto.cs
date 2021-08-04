using System;

namespace Cgm.Ecoupon.Api.Models.Branch
{
    public class BranchMobileNumberDtoAdd
    {
        public string BranchReceiverName { get; set; }

        public string BranchReceiverMobileNumber { get; set; }

    }
    public class BranchMobileNumberDtoUpdate
    {
        public Guid BranchMobileNumberId { get; set; }

        public Guid BranchId { get; set; }

        public string BranchReceiverName { get; set; }

        public string BranchReceiverMobileNumber { get; set; }

        public bool IsActive { get; set; }
    }
}