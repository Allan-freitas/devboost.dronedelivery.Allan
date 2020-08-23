using System;

namespace devboost.dronedelivery.Model
{
    public class PedidoDrone
    {
        public Guid PedidoId { get; set; }

        public int DroneId { get; set; }

        public virtual Pedido Pedido { get; set; }

        public virtual Drone Drone { get; set; }
    }
}
