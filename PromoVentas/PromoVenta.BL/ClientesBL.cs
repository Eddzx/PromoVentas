using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PromoVenta.BL
{
   public class ClientesBL
    {
        Contexto _contexto;

        public List<Clientes> ListadeClientes { get; set; }
        public int Id { get; private set; }

        public ClientesBL()
        {
            _contexto = new Contexto();
            ListadeClientes = new List<Clientes>();
        }

        public List<Clientes> ObtenerClientes()
        {
            ListadeClientes = _contexto.Clientes.ToList();

            return ListadeClientes;
        }
        public void GuardarClientes(Clientes clientes)
        {
            if (clientes.Id == 0)
            {
                _contexto.Clientes.Add(clientes);
            }
            else
            {
                var clientesExistente = _contexto.Clientes.Find(clientes.Id);
                clientesExistente.NombreCliente = clientes.NombreCliente;
            }

            _contexto.SaveChanges();
        }

        public Clientes ObtenerClientes(int id)
        {
            var clientes = _contexto.Clientes.Find(id);

            return clientes;
        }

        public void EliminarCategoria(int id)
        {
            var clientes = _contexto.Clientes.Find(id);

            _contexto.Clientes.Remove(clientes);
            _contexto.SaveChanges();
        }

    }
}
