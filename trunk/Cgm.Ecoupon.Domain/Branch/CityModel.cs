using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cgm.Ecoupon.Domain.Branch
{
    public class CityModel
    {
        public System.Guid CityId { get; set; }
        public System.Guid TownShipId { get; set; }
        public string Name { get; set; }
        public string BurmeseName { get; set; }
        public string Code { get; set; }

    }
}
