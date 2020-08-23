using GeoLocation;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace devboost.dronedelivery.Model
{
    public class Pedido
    {
        public Guid Id { get; set; }

        public int Peso { get; set; }

        //public SqlGeography LatLong { get; set; }
        public double Latitude { get; set; }

        public double Longitude { get; set; }

        public DateTime DataHora { get; set; }

        //public int? DroneId { get; set; }

        //public Drone Drone { get; set; }

        public StatusPedido StatusPedido { get; set; }

        public List<PedidoDrone> PedidosDrones { get; set; }

        [NotMapped]
        public double DistanciaParaDestino
        {
            get
            {
                double distance = new Coordinates(-23.5880684, -46.6564195).DistanceTo(new Coordinates(Latitude, Longitude), UnitOfLength.Kilometers);
                return distance;
            }
        }
    }

    public enum StatusPedido
    {
        aguardandoAprovacao = 0,
        reprovado = 1,
        aguardandoEntrega = 2,
        despachado = 3,
        entregue = 4
    }
}
