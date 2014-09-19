using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace ApiControlBobinas.Models
{
    public class menus
    {
        public int id { get; set; }
        public int menus_id { get; set; }
        public string texto { get; set; }
        public int orden { get; set; }
        public string imagen { get; set; }
    }

    public class ApiControlBobinasDBContext: DbContext
    {
        public DbSet<menus> menus { get; set; }
    }

}