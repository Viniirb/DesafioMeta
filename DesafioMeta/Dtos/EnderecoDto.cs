namespace DesafioMeta.Dtos
{
    /// <summary>
    /// Classe responsável por trancisionar  os dados de endereço entre o banco de dados e a aplicação
    /// </summary>
    public class EnderecoDto
    {
        public int Id { get; set; }
        public int PessoaId { get; set; }
        public string Logradouro { get; set; }
        public string? Numero { get; set; }
        public string? Complemento { get; set; }
        public string? Bairro { get; set; }
        public string Cidade { get; set; }
        public string? Estado { get; set; }
        public string? CodigoPostal { get; set; }
    }
}
