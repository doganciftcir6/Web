using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;


namespace shopapp.webui.Identity
{
    //entityframework gibi veritabanıyla iletişim sağlayacak burası
    public class ApplicationContext : IdentityDbContext<User>
    {
        //kanstraktır
        public ApplicationContext(DbContextOptions<ApplicationContext> options) : base(options)
        {

        }
    }
}
