using CadastroContatos.Models;
using CadastroContatos.Repository;
using Microsoft.AspNetCore.Mvc;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace CadastroContatos.Controllers
{
    public class ContatoController : Controller
    {
        private readonly IContatoRepository _contatoRepository;
        public ContatoController(IContatoRepository contatoRepository) 
        { 
            _contatoRepository = contatoRepository;
        }
        public IActionResult Index()
        {
            List<ContatoModel> contatos = _contatoRepository.SearchAll();
            return View(contatos);
        }

        public IActionResult Criar()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Criar(ContatoModel contato)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    _contatoRepository.Add(contato);
                    TempData["MensagemSucesso"] = "Contato cadastrado com sucesso.";
                    return RedirectToAction("Index");
                }
                return View(contato);
            }
            catch (Exception error)
            {
                TempData["MensagemErro"] = $"Cadastro não relizado, tente novamente. {error.Message}";
                return RedirectToAction("Index");
            }
        }

        public IActionResult Editar(int id)
        {
            ContatoModel contato = _contatoRepository.ListId(id);
            return View(contato);
        }
        [HttpPost]
        public IActionResult Alterar(ContatoModel contato)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    _contatoRepository.Atualizar(contato);
                    TempData["MensagemSucesso"] = "Contato alterado com sucesso.";
                    return RedirectToAction("Index");
                }
                return View("Editar", contato);
            }
            catch(Exception error)
            {
                TempData["MensagemErro"] = $"Alteração não foi atualizada, tente novamente. {error.Message}";
                return RedirectToAction("Index");
            }
        }

        public IActionResult Apagar(int id)
        {
            ContatoModel contato = _contatoRepository.ListId(id);
            return View(contato);
        }

        public IActionResult ConfApagar(int id)
        {
            try 
            {
                bool apagado = _contatoRepository.ConfApagar(id);

                if (apagado)
                {
                    TempData["MensagemSucesso"] = "Exclusão realizada com sucesso.";
                }
                else 
                {
                    TempData["MensagemErro"] = "Exclusão não realizada.";
                }
                
                return RedirectToAction("Index");
            }
            catch(Exception error)
            {
                TempData["MensagemErro"] = $"Exclusão nao realizada, tente novamente. {error.Message}";
                return RedirectToAction("Index");
            }
        }
    }
}
