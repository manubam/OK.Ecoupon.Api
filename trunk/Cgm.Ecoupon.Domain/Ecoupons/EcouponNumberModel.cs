using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cgm.Ecoupon.Domain.Ecoupons
{
    public class EcouponNumberModel
    {
        public System.Guid Id { get; set; }
        public System.Guid EcouponMetadataId { get; set; }
        public Nullable<System.Guid> EcouponAllocationId { get; set; }
        public int status { get; set; }
        public string EcouponNo { get; set; }
        public System.DateTime CreatedDate { get; set; }
    }
}
