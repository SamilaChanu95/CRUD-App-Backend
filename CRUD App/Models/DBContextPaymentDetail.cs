using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace CRUD_App.Models
{
    public class DBContextPaymentDetail : DbContext
    {
        /*private readonly DbContextOptions _options; */
        public DBContextPaymentDetail(DbContextOptions options) : base(options)
        {
        }

        public DbSet<PaymentDetail> PaymentDetails { get; set; }
    }
}
