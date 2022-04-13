using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Su_Project.DataContext;

namespace Su_Project.Models
{
    public class EFRiviuNhaTrangRepository :IRiviuNhaTrangRepository
    {
        private RiviuNhaTrangDBContext context;
        public EFRiviuNhaTrangRepository(RiviuNhaTrangDBContext ctx){context = ctx;}
        public IQueryable<User> Users => context.Users;

    }
}
