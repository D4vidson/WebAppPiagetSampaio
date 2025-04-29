namespace WebAppPiagetSampaio.Models
{
    public class Professor:Base
    {
        /// <summary>
        /// Classe Professor
        /// </summary>
        public string? nome { get; set; }
        public string? email { get; set; }
        public string? telefone { get; set; }
        public Aluno? aluno { get; set; }
    }
}
