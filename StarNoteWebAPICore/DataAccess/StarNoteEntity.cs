using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using StarNoteWebAPICore.Models;

namespace StarNoteWebAPICore.DataAccess
{
    public class StarNoteEntity : DbContext
    {
        public StarNoteEntity(DbContextOptions<StarNoteEntity> options) : base(options)
        {

        }
        public DbSet<CaseModel> tbl_case { get; set; }

        public DbSet<CompanyModel> tbl_company { get; set; }

        public DbSet<CostumerModel> tbl_costumer { get; set; }

        public DbSet<CostumerOrderModel> tbl_customerorder { get; set; }

        public DbSet<FilemanagementModel> tbl_filemanagement { get; set; }

        public DbSet<JobOrderModel> tbl_joborder { get; set; }

        public DbSet<KdvModel> tbl_kdvsource { get; set; }

        public DbSet<LisanceModel> tbl_lisance { get; set; }

        public DbSet<PaymenttypeModel> tbl_paymenttype { get; set; }

        public DbSet<ProcesstypeModel> tbl_processtype { get; set; }

        public DbSet<ProductModel> tbl_product { get; set; }

        public DbSet<RemindingModel> tbl_remember { get; set; }

        public DbSet<RememberstatusModel> tbl_rememberstatus { get; set; }

        public DbSet<RemembertypeModel> tbl_remembertype { get; set; }

        public DbSet<SalesmanModel> tbl_salesman { get; set; }

        public DbSet<StokModel> tbl_stok { get; set; }

        public DbSet<TypeModel> tbl_type { get; set; }

        public DbSet<TypedetailModel> tbl_typedetail { get; set; }

        public DbSet<UnitModel> tbl_unit { get; set; }

        public DbSet<UsersModel> tbl_users { get; set; }

        public DbSet<partial_analysis> partial_analysis { get; set; }
        public DbSet<partial_saleschart> partial_saleschart { get; set; }
        public DbSet<partial_salesman> partial_salesman { get; set; }
        public DbSet<partial_salespie> partial_salespie { get; set; }

    }
}
