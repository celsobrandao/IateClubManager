namespace IateClubManager.Domain.Navegacao.Entities
{
    public class Passageiro
    {
        public int Id { get; set; }
        public string Nome { get; set; }
        public string Telefone { get; set; }

        public bool EhValido()
            => !string.IsNullOrEmpty(Nome) && !string.IsNullOrEmpty(Telefone);
    }
}
