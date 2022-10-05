using CadastroAluno.Contract;
using CadastroAluno.Data;
using CadastroAluno.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CadastroAluno.Repositories
{
        public class AlunoRepository : IAlunoRepository
        {
            private readonly CadastroAlunoContext _context;

            public AlunoRepository(CadastroAlunoContext context)
            {
                _context = context;
            }

            public async Task<List<Aluno>> GetAlunos()
            {
                return await _context.Aluno.ToListAsync();
            }

            public async Task<Aluno> GetAluno(int id)
            {
                return await _context.Aluno.FirstOrDefaultAsync(c => c.Id == id);
            }

            public async Task<Aluno> AddAluno(Aluno aluno)
            {

                _context.Aluno.Add(aluno);
                await _context.SaveChangesAsync();

                return aluno;
            }

            public async Task<int> UpdateAluno(int id, Aluno alunoAlterado)
            {
                var aluno = await _context.Aluno.FirstOrDefaultAsync(c => c.Id == id);

                if (aluno == null)
                    return 0;

                aluno.AtualizarDados(alunoAlterado.Nome, alunoAlterado.Turma);

                aluno.AtualizaMedia(alunoAlterado.Media);

                _context.Entry(aluno).State = EntityState.Modified;
                return await _context.SaveChangesAsync();
            }

            public async Task DeleteAluno(int id)
            {
                var cliente = await _context.Aluno.FirstOrDefaultAsync(c => c.Id == id);

                _context.Aluno.Remove(cliente);
                await _context.SaveChangesAsync();
            }
        }


    }
