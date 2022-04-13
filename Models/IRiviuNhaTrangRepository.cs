using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Su_Project.Models
{
    public interface IRiviuNhaTrangRepository
    {
        IQueryable<User> Users { get; }
    }
}
