using System;
using FiapTestApi.Entities;

namespace FiapTestApi.Interfaces;

public interface IAlunoRepository
{
    int Inserir(Aluno aluno);
    List<Aluno> ObterTodos();
    Aluno Retornar(int id);
}
