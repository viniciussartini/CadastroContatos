using CadastroContatos.Models;

namespace CadastroContatos.Repository
{
    public interface IContatoRepository
    {
        List<ContatoModel> SearchAll();
        ContatoModel Add(ContatoModel contato);
    }
}
