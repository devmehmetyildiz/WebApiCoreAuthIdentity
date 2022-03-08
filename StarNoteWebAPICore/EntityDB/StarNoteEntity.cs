using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using StarNoteWebAPICore.Models;
namespace StarNoteWebAPICore.EntityDB
{
    public class StarNoteEntity : DbContext
    {
       
        public DbSet<ParameterModel> tbl_case { get; set; }

        public DbSet<CompanyModel> tbl_company { get; set; }

        public DbSet<CostumerModel> tbl_costumer { get; set; }

        public DbSet<CostumerOrderModel> tbl_customerorder { get; set; }

        public DbSet<FilemanagementModel> tbl_filemanagement { get; set; }

        public DbSet<JobOrderModel> tbl_joborder { get; set; }

        public DbSet<ParameterModel> tbl_kdvsource { get; set; }

        public DbSet<LisanceModel> tbl_lisance { get; set; }

        public DbSet<ParameterModel> tbl_paymenttype { get; set; }

        public DbSet<ParameterModel> tbl_processtype { get; set; }

        public DbSet<ParameterModel> tbl_product { get; set; }

        public DbSet<RemindingModel> tbl_remember { get; set; }

        public DbSet<ParameterModel> tbl_rememberstatus { get; set; }

        public DbSet<ParameterModel> tbl_remembertype { get; set; }

        public DbSet<ParameterModel> tbl_salesman { get; set; }

        public DbSet<StokModel> tbl_stok { get; set; }

        public DbSet<ParameterModel> tbl_type { get; set; }

        public DbSet<ParameterModel> tbl_typedetail { get; set; }

        public DbSet<ParameterModel> tbl_unit { get; set; }

        public DbSet<UsersModel> tbl_users { get; set; }

    }
}
