using Microsoft.EntityFrameworkCore;
using System;

namespace EcommerceCRUD.Database
{
    public class EcommerceCRUDContext : DbContext
    {
        public EcommerceCRUDContext(DbContextOptions<EcommerceCRUDContext> options)
        : base
            (options)
        {

        }
    }
}

