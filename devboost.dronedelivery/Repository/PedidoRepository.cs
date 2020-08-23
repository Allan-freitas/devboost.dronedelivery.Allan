using devboost.dronedelivery.Model;
using devboost.dronedelivery.Repository.Context;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace devboost.dronedelivery.Repository
{
    public class PedidoRepository
    {
        readonly DataContext _dataContext;

        public PedidoRepository(DataContext dataContext)
        {
            _dataContext = dataContext;
        }

        public async Task AddPedido(Pedido pedido)
        {
            _dataContext.Pedido.Add(pedido);
            await _dataContext.SaveChangesAsync();
        }

        public async Task UpdatePedido(Pedido pedido)
        {
            _dataContext.Pedido.Update(pedido);
            await _dataContext.SaveChangesAsync();
        }

        public async Task<List<Pedido>> ListarPedidos()
        {
            return await _dataContext.Pedido.ToListAsync();
        }

        public async Task AddPedidoDrone(PedidoDrone pedido)
        {
            _dataContext.PedidosDrones.Add(pedido);
            await _dataContext.SaveChangesAsync();
        }
    }
}
