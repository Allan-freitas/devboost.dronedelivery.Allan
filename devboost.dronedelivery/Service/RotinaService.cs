using devboost.dronedelivery.Model;
using devboost.dronedelivery.Repository;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace devboost.dronedelivery.Service
{
    public class RotinaService
    {
        readonly DroneRepository _droneRepository;
        readonly PedidoRepository _pedidoRepository;

        public RotinaService(DroneRepository droneRepository, PedidoRepository pedidoRepository)
        {
            _droneRepository = droneRepository;
            _pedidoRepository = pedidoRepository;
        }

        public async Task EnviarPedidos()
        {
            try
            {
                List<Pedido> listaPedidos = await _pedidoRepository.ListarPedidos();
                List<Drone> drones = await _droneRepository.GetDisponiveis();

                foreach (Drone drone in drones)
                {
                    double droneAutonomia = drone.Autonomia;
                    int droneCapacidade = drone.Capacidade;

                    foreach (Pedido pedido in listaPedidos)
                    {                        
                        if (droneAutonomia >= pedido.DistanciaParaDestino && droneCapacidade >= pedido.Peso)
                        {
                            drone.StatusDrone = StatusDrone.emTrajeto;
                            pedido.StatusPedido = StatusPedido.despachado;
                            await _pedidoRepository.AddPedidoDrone(new PedidoDrone { Drone = drone, Pedido = pedido });
                            await _pedidoRepository.UpdatePedido(pedido);
                            await _droneRepository.UpdateDrone(drone);

                            droneAutonomia -= pedido.DistanciaParaDestino;
                            droneCapacidade -= pedido.Peso;
                        }
                    }
                }
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }
    }
}
