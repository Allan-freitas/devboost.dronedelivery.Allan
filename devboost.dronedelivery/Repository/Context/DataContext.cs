using devboost.dronedelivery.Model;
using Microsoft.EntityFrameworkCore;

namespace devboost.dronedelivery.Repository.Context
{
    public class DataContext : DbContext
    {
        public DataContext(DbContextOptions<DataContext> options)
            : base(options)
        {
        }

        public DbSet<Drone> Drone { get; set; }

        public DbSet<Pedido> Pedido { get; set; }

        public DbSet<PedidoDrone> PedidosDrones { get; set; }

        //protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        //{
        //    optionsBuilder.UseSqlServer(
        //           @"my connection string",
        //           x => x.UseNetTopologySuite());
        //}

        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.Entity<Drone>().HasKey(x => x.Id);
            builder.Entity<Drone>().Property(x => x.StatusDrone).HasColumnName("Status");

            builder.Entity<Pedido>().HasKey(x => x.Id);

            //builder.Entity<Pedido>().HasOne(x => x.Drone)
            //    .WithMany(x => x.Pedidos)
            //    .HasForeignKey(x => x.DroneId);

            builder.Entity<PedidoDrone>().ToTable("Pedido_Drone");

            builder.Entity<PedidoDrone>()
                .HasKey(x => new { x.PedidoId, x.DroneId });

            builder.Entity<PedidoDrone>()
                .Property(x => x.PedidoId)
                .HasColumnName("Pedido_Id");

            builder.Entity<PedidoDrone>()
                .Property(x => x.DroneId)
                .HasColumnName("Drone_Id");

            builder.Entity<PedidoDrone>()
                .HasOne(x => x.Pedido)
                .WithMany(x => x.PedidosDrones)
                .HasForeignKey(x => x.PedidoId);

            builder.Entity<PedidoDrone>()
                .HasOne(x => x.Drone)
                .WithMany(x => x.PedidosDrones)
                .HasForeignKey(x => x.DroneId);
        }
    }
}
