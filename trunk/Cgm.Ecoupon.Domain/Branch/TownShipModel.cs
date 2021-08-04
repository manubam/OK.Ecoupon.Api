using System;

namespace Cgm.Ecoupon.Domain.Branch
{
    public class TownShipModel
    {
        public System.Guid TownShipId { get; set; }
        public string Name { get; set; }
        public string BurmeseName { get; set; }
        public Nullable<System.Guid> DivisionId { get; set; }
        public string Code { get; set; }

    }
}
