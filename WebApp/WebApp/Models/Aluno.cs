using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Hosting;

namespace WebApp.Models
{
    public class Aluno
    {
        public int Id { get; set; }
        public string Nome { get; set; }
        public string SobreNome { get; set; }
        public string Telefone { get; set; }
        public int RU { get; set; }



        public List<Aluno> ListarAluno()
        {
            var filepath = HostingEnvironment.MapPath(@"~/App_Data/Base.json");
            var json = File.ReadAllText(filepath);
            var listaAlunos = JsonConvert.DeserializeObject<List<Aluno>>(json);
            return listaAlunos;
        }
        public bool ReescreveArquivo(List<Aluno> listaAluno)
        {
            var filepath = HostingEnvironment.MapPath(@"~/App_Data/Base.json");
            var json = JsonConvert.SerializeObject(listaAluno, Formatting.Indented);
            File.WriteAllText(filepath,json);
            return true;
        }

        public Aluno Inserir(Aluno alunos)
        {
            var listaAlunos = this.ListarAluno();

            var masId = listaAlunos.Max(p => p.Id);//pegar maior Id
            alunos.Id = masId + 1;//recebe maior ID + 1
            listaAlunos.Add(alunos);
            ReescreveArquivo(listaAlunos);
            return alunos;
        }

        public Aluno Atualizar(int id, Aluno aluno)
        {
            var listaAluno = this.ListarAluno();//recebe lista de aluno
            var intemIndex = listaAluno.FindIndex(p => p.Id == id);//encontra id correspondente
            if (intemIndex >= 0)
            {
                aluno.Id = id;
                listaAluno[intemIndex] = aluno;
            }
            else
            {
                return null;
            }

            ReescreveArquivo(listaAluno);

            return aluno;

        }

        public bool Deletar(int id)
        {
            var listaAluno = this.ListarAluno();
            var intenIndex = listaAluno.FindIndex(p => p.Id == id);
            if (intenIndex >= 0)
            {
                listaAluno.RemoveAt(intenIndex);
            }
            else
            {
                return false;
            }

            ReescreveArquivo(listaAluno);

            return true;
        }

    }
}