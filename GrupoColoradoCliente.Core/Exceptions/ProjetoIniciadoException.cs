namespace SistemaCliente.Core.Exceptions
{
    public class ProjetoIniciadoException : Exception
    {
        public ProjetoIniciadoException()
            : base("Não é possível iniciar um novo projeto, pois já existe um projeto iniciado.")
        {
        }
        public ProjetoIniciadoException(string message)
            : base(message)
        {
        }
        public ProjetoIniciadoException(string message, Exception inner)
            : base(message, inner)
        {
        }
    }
}
