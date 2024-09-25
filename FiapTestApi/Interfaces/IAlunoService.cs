using System;
using FiapTestApi.Entities;

namespace FiapTestApi.Interfaces;

public interface IAlunoService
{
    Aluno RetornarAluno(int id);

    int CriarAluno(Aluno dadosAluno);
    List<Aluno> RetornarAlunos();
}
