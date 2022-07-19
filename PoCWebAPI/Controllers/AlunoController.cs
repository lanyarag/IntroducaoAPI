using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using PoCWebAPI.Models;

namespace PoCWebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AlunoController : ControllerBase
    {
        private EscolaContext _context;
        public AlunoController(EscolaContext escola)
        {
            _context = escola;
        }

        [HttpGet]
        public Aluno[] AcessarAlunos ()
        {
            return _context.Alunos.ToArray();
        }

        [HttpGet ("{Id}")]
        public Aluno BuscaAlunoId(int Id)
        {

            return _context.Alunos.Find(Id);
        }

        [HttpPost]
        public Aluno CadastrarAluno(Aluno novoAluno)
        {
            _context.Alunos.Add(novoAluno);
            _context.SaveChanges();
            return novoAluno;
        }

        [HttpDelete]
        public Aluno RemoveAlunoId(int Id)
        {
            var alunoRemove = _context.Alunos.Find(Id);
            _context.Alunos.Remove(alunoRemove);
            _context.SaveChanges();
            return alunoRemove;
        }

    }
}
