using Microsoft.AspNetCore.Mvc;
using NETCOREAPI.Models;

namespace NETCOREAPI.Controllers
{
    [ApiController]
    [Route("cliente")]
    public class ClienteController : ControllerBase
    {
        [HttpGet]
        [Route("listar")]
        public dynamic listarCliente()
        {
            List<Cliente> clientes = new List<Cliente>
            {
                new Cliente
                {
                    id = "1",
                    correo = "esteban@gmail.com",
                    edad = "21",
                    nombre = "Esteban Chinchay"
                },
                new Cliente
                {
                    id = "2",
                    correo = "samantha@gmail.com",
                    edad = "14",
                    nombre = "Sam Chinchay"
                }
            };

            return clientes;
        }

        [HttpGet]
        [Route("listarxid")]
        public dynamic listarClientexid( string _id)
        {
            List<Cliente> clientes = new List<Cliente>
            {
                new Cliente
                {
                    id = _id,
                    correo = "samantha@gmail.com",
                    edad = "14",
                    nombre = "Sam Chinchay"
                }
            };

            return clientes;
        }

        [HttpPost]
        [Route("guardar")]
        public dynamic guardarCliente(Cliente cliente)
        {
            cliente.id = "3";

            return new
            {
                success = true,
                message = "Cliente registrado",
                result = cliente
            };
        }

        [HttpPost]
        [Route("eliminar")]
        public dynamic eliminarCliente(Cliente cliente)
        {
            string token = Request.Headers.Where(x => x.Key == "Authorization").FirstOrDefault().Value;

            if(token != "marco123")
            {
                return new
                {
                    success = false,
                    message = "token incorrecto",
                    result = ""
                };
            }

            return new
            {
                success = true,
                message = "eliminado",
                result = cliente
            };
        }
    }
}
