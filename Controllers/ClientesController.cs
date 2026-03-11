using Microsoft.AspNetCore.Mvc;
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
		//Annotation que referencia o método Get
		[HttpGet("GetAll")]
		public IActionResult GetAllClientes()
		{
			//Utilizando, por enquanto, dados mockados
			var clientes = new[] {

			 new { Id = 1, Nome = "Diego Áquila Almeida Sampaio", Email = "diego@diegoaquila.com.br" },
			 new { Id = 2, Nome = "Miguel de Souza Palmeirense", Email = "miguel@palmeiras.com.br" },
			 new { Id = 3, Nome = "Raí Joga Muito no São Paulo", Email = "rai@spfc.com.br" },

			};

			//Retorna HTTTP 200 - Sucesso - Retorna dados no body(corpo da resposta) como JSON
			return Ok(clientes);
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

	}
}
