using System.ComponentModel.DataAnnotations;

namespace projetointegrador.API.Model
{
	public class Cliente
	{
		[Key]
		public int Id { get; set; }

		[Required(ErrorMessage ="Nome é um valor obrigatório")]
		[StringLength(100, ErrorMessage ="O nome pode conter até 100 caracteres")]
		public string Nome { get; set; } = string.Empty;

		[Required(ErrorMessage = "Email é um valor obrigatório")]
		[EmailAddress(ErrorMessage ="Email inválido.")]
		public string Email { get; set; } = string.Empty;

		[Required(ErrorMessage = "CPF é um valor obrigatório")]
		[StringLength(14, ErrorMessage = "CPF deve conter 14 caracteres no formato XXX.XXX.XXX-XX")]
		[RegularExpression(@"^\d{3}\.\d{3}\.\d{3}-\d{2}$", ErrorMessage = "CPF deve estar no formato XXX.XXX.XXX-XX")]
		public string CPF { get; set; } = string.Empty;

		public DateTime DataCadastro { get; set; }

		public bool Ativo { get; set; }

		public List<Endereco> Enderecos { get; set; } = [];

		public Cliente() {

			DataCadastro = DateTime.UtcNow;
			Ativo = true;
		
		}




	}

	

}
