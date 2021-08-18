using Fiap.Aula01.Exemplo02.Exceptions;
using Fiap.Aula01.Exemplo02.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace Fiap.Aula01.Exemplo02.Repositories
{
    class EsporteRepository : IEsporteRepository
    {
        //Declarar um atributo de lista de Esportes para armazenar os esportes
        private IList<Esporte> _lista;

        public void Cadastrar(Esporte esporte)
        {
            //Validar se o esporte está vazio, se estiver, lançar uma exception
            if (esporte == null)
            {
                throw new ArgumentNullException("O esporte não pode estar vazio");
            }
            //Adicionar o esporte na lista
            _lista.Add(esporte);
        }

        public IList<Esporte> Listar() 
        {
            //Validar se a lista está vazia, se estiver lançar uma exception
            if (_lista.Count == 0)
            {
                throw new EmptyListException("Não existem esportes cadastrados");
            }
            return _lista;
        }

        //Criar um construtor para instanciar a lista
        //ctor tab tab
        public EsporteRepository()
        {
            _lista = new List<Esporte>();
        }

    }
}
