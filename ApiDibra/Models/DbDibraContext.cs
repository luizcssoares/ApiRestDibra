using MySql.Data.Entity;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Data.Entity.ModelConfiguration.Conventions;
using System.Linq;
using System.Web;

namespace ApiDibra.Models
{
    [DbConfigurationType(typeof(MySqlEFConfiguration))]
    public class DbDibraContext : DbContext
    {
        public DbDibraContext() : base("DbDibra")
        {

        }

        public DbSet<Chamado> Chamados { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            Database.SetInitializer(new CreateDatabaseIfNotExists<DbContext>());  //cria o banco se não existir
            modelBuilder.Conventions.Remove<PluralizingTableNameConvention>();   //remove a pluralização         
        }
    }
}