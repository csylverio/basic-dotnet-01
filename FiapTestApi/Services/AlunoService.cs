using System;
using FiapTestApi.Entities;
using FiapTestApi.Interfaces;

namespace FiapTestApi.Services;

public class AlunoService : IAlunoService
{
    private readonly IAlunoRepository alunoRepository;

    public AlunoService(IAlunoRepository alunoRepository) {
        this.alunoRepository = alunoRepository;
    }

    public Aluno RetornarAluno(int id)
    {
        return alunoRepository.Retornar(id);
    }

    public int CriarAluno(Aluno dadosAluno)
    {
        return alunoRepository.Inserir(dadosAluno);
    }

    public List<Aluno> RetornarAlunos()
    {
        return alunoRepository.ObterTodos();
    }
}
