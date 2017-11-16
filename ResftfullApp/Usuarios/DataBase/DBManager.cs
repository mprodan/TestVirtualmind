using System.Data.Entity;
using System.Data.SQLite;
using System.Data;
using System.Text;
using System.Threading.Tasks;
using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration.Conventions;
using System.Linq;
using System.ComponentModel.DataAnnotations;
using System.Diagnostics;
using System.Data.Entity.Core.Common;
using System.Data.SQLite.EF6;

namespace ResftfullApp
{
    public class SQLiteConfiguration : DbConfiguration
    {
        public SQLiteConfiguration()
        {
            SetProviderFactory("System.Data.SQLite", SQLiteFactory.Instance);
            SetProviderFactory("System.Data.SQLite.EF6", SQLiteProviderFactory.Instance);
            SetProviderServices("System.Data.SQLite", (DbProviderServices)SQLiteProviderFactory.Instance.GetService(typeof(DbProviderServices)));
        }
    }

    public class Usuarios
    {
        [Key]
        public int ID { get; set; }
        public string Nombre { get; set; }
        public string Apellido { get; set; }
        public string Mail { get; set; }
        public string Password { get; set; }
    }

    public class MyContext : DbContext
    {
        public MyContext() : base(new SQLiteConnection()
        {
            ConnectionString = new SQLiteConnectionStringBuilder() { DataSource = @".\usuarios.db", ForeignKeys = true }.ConnectionString
        }, true)
        {
        }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Conventions.Remove<PluralizingTableNameConvention>();
            base.OnModelCreating(modelBuilder);
        }

        public DbSet<Usuarios> Usuarios { get; set; }
    }

    public class DBManager
    {
        private MyContext context = new MyContext();
        public DBManager()
        {
            context.Database.CreateIfNotExists();
            context.Usuarios.Load();
        }

        public Usuarios CreateUser(Usuarios usuario)
        {
            context.Usuarios.Add(usuario);
            context.SaveChanges();
            return usuario;
        }

        public Usuarios UpdateUser(Usuarios usuario)
        {
            var u = context.Usuarios.Where(p => p.ID == usuario.ID).SingleOrDefault();
            if (u != null)
            {
                u.Nombre = usuario.Nombre;
                u.Apellido = usuario.Apellido;
                u.Mail = usuario.Mail;
                u.Password = usuario.Password;
                context.SaveChanges();
            }
            else
                throw new Exception("usuario inexistente");
            return usuario;
        }

        public void DeleteUser(Usuarios usuario)
        {
            
            var u = context.Usuarios.Where(p => p.ID == usuario.ID).SingleOrDefault();
            if (u != null)
            {
                context.Usuarios.Remove(u);
                context.SaveChanges();
            }
            else
                throw new Exception("usuario inexistente");
        }

        public List<Usuarios> GetAll()
        {
            return context.Usuarios.ToList();
        }

    }
}
