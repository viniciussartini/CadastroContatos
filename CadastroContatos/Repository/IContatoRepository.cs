using CadastroContatos.Models;

namespace CadastroContatos.Repository
{
    public interface IContatoRepository
    {
        ContatoModel ListId(int id);
        List<ContatoModel> SearchAll();
        ContatoModel Add(ContatoModel contato);
        ContatoModel Atualizar(ContatoModel contato);
    }
}
