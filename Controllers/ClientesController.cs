using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using projetointegrador.API.Data;
using projetointegrador.API.Model;
using projetointegrador.API.Model.DTO;
using System.ComponentModel.DataAnnotations;

namespace projetointegrador.API.Controllers
{
	// Anotação que indica que esta classe é um controlador de API
	[ApiController] // -> DataAnnotation

	// Define a rota para este controlador.
	// O [controller] será substituído pelo nome do controlador, ou seja, "clientes".
	[Route("api/[controller]")] // -> DataAnnotation


	public class ClientesController : ControllerBase
	{
		private readonly AppDbContext _clienteDbContext;


		public ClientesController(AppDbContext context) {

			_clienteDbContext = context;

		}

		//Annotation que referencia o método Get
		[HttpGet("GetAll")]
		public async Task<IActionResult> GetAllClientes()
		{
		   List<Cliente> listaClientes = await _clienteDbContext.Cliente.ToListAsync();

		   return Ok(listaClientes);
		}

		[HttpGet("GetById/{id}")]
		public IActionResult GetById([FromRoute]int id) {

			var clientes = new[] {

			 new { Id = 1, Nome = "Diego Áquila Almeida Sampaio", Email = "diego@diegoaquila.com.br" },
			 new { Id = 2, Nome = "Miguel de Souza Palmeirense", Email = "miguel@palmeiras.com.br" },
			 new { Id = 3, Nome = "Raí Joga Muito no São Paulo", Email = "rai@spfc.com.br" },
			 new { Id = 5, Nome = "Benjamin ", Email = "benjamin@spfc.com.br" },
			 new { Id = 6, Nome = "Stephany", Email = "stephany@spfc.com.br" },

			};

			var cliente = clientes.FirstOrDefault(cliente => cliente.Id == id);

			//
			if (cliente == null)
			{
				return NotFound(

					//Retorno em formato JSON
					new { 
						Erro = true,
						Mensagem = $"O cliente com o id {id} não foi encontrado"
					}

					);
				
			}

			//Retorna o cliente encontrado no formato JSON 
			return Ok(cliente);

		}

		[HttpPost("CriarCliente")]
		public async Task<IActionResult> CriarCliente([FromBody] CriarClienteDTO dadosCliente) {

			if (!ModelState.IsValid)
			{
				return BadRequest(ModelState);

			}

			Cliente? clienteEncontrado = await _clienteDbContext.Cliente.FirstOrDefaultAsync(cliente => cliente.CPF == dadosCliente.CPF);

			if (clienteEncontrado != null) { 
				return BadRequest($"Já existe um cliente cadastrado com o CPF {dadosCliente.CPF}");
			}

			Cliente cliente = new Cliente
			{
				Nome = dadosCliente.Nome,
				Email = dadosCliente.Email,
				CPF = dadosCliente.CPF,
				
			};

			_clienteDbContext.Cliente.Add(cliente);
			int resultadoGravacao = await _clienteDbContext.SaveChangesAsync();

			if (resultadoGravacao > 0)
				return Created();

			return BadRequest("Erro ao criar cliente");


		}

	}
}
