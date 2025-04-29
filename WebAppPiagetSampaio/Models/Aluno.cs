namespace WebAppPiagetSampaio.Models
{
    public class Aluno : Base
    {
        /// <summary>
        /// Classe Aluno
        /// </summary>


        public Guid id { get; set; }
        public string? nome { get; set; }
        public string? email { get; set; }
        public string? telefone { get; set; }
    }
}
