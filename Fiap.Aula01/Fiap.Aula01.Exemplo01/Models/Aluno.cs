
namespace Fiap.Aula01.Exemplo01.Models
{
    class Aluno
    {
        //Atributos (Campos ou Fields)
        private int _rm;
        private string _nome;

        //Getters e Setters (Propriedades)
        public string Turma { get; set; }

        public int Rm
        {
            get { return _rm; }
            set { _rm = value; }
        }

        public string Nome
        {
            get { return _nome; }
            set { _nome = value; }
        }

    }
}
