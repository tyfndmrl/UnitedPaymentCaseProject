using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UnitedPayment.DDD.Entities.Bases.Interfaces
{
    public interface IHasModificationDate
    {
        DateTime? LastModificationDate { get; set; }
    }
}
