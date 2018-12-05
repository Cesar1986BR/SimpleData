using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Cors;
using WebApp.Models;

namespace WebApp.Controllers
{
    [EnableCors("*","*","*")]
    public class AlunoController : ApiController
    {
        // GET: api/Aluno
        public IEnumerable<Aluno> Get()
        {

            Aluno _aluno = new Aluno();

            return _aluno.ListarAluno();
        }

        // GET: api/Aluno/5
        public Aluno Get(int id)
        {
            Aluno _aluno = new Aluno();

            return _aluno.ListarAluno().Where(x => x.Id == id).FirstOrDefault();
        }

        // POST: api/Aluno
        public List<Aluno> Post(Aluno aluno)
        {
           Aluno _alunos = new Aluno();
           _alunos.Inserir(aluno);
            return _alunos.ListarAluno();

        }

        // PUT: api/Aluno/5
        public Aluno Put(int id, Aluno aluno)
        {
            Aluno _alunos = new Aluno();

            return  _alunos.Atualizar(id, aluno);
        }

        // DELETE: api/Aluno/5
        public void Delete(int id)
        {
            Aluno _alunos = new Aluno();
            _alunos.Deletar(id);
        }
        public   void teste()
        {
           
        }
    }
}
