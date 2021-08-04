using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cgm.Ecoupon.Domain.Branch
{
    public class CustomerModel
    {
        public Guid Id { get; set; }
        public string OkAccountNumber { get; set; }
        public string CustomerName { get; set; }
        public DateTime CreatedDate { get; set; }
        public bool IsActive { get; set; }
    }
}
