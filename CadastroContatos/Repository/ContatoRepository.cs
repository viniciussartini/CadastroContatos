using CadastroContatos.Data;
using CadastroContatos.Models;

namespace CadastroContatos.Repository
{
    public class ContatoRepository : IContatoRepository
    {
        private readonly BancoContext _bancoContext;
        public ContatoRepository(BancoContext bancoContext)
        {
            _bancoContext = bancoContext;
        }

        public List<ContatoModel> SearchAll()
        {
            return _bancoContext.Contatos.ToList();
        }

        public ContatoModel Add(ContatoModel contato)
        {
            _bancoContext.Contatos.Add(contato);
            _bancoContext.SaveChanges();
            return contato;
        }
    }
}
