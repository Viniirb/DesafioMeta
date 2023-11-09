namespace DesafioMeta.Dtos
{
    /// <summary>
    /// Classe responsavel por transicionar os dados de Pessoa entre banco de dados e a aplicação
    /// </summary>
    public class PessoaDto
    {
        public int Id { get; set; }
        public string Nome { get; set; }
        public int Idade { get; set; }
        public string? CPF { get; set; }
        public string? Email { get; set; }
        public string Nacionalidade { get;set; }
        public string Genero { get; set; }

    }
}
