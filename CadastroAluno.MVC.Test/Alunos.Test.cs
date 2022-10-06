using CadastroAluno.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace CadastroAluno.MVC.Test
{
    public class Alunos
    {
        [Theory]
        [InlineData("Thomas Shelby", "Turma A")]
        [InlineData("Thomas Shelby", "")]
        [InlineData("", "Turma A")]
        [InlineData(null, "Turma A")]
        public void AtualizaDados_AlteraNomeTurma_RetornaNovaPropriedade(string nome, string turma)
        {
            //arrange 
            Aluno aluno = new Aluno();
            aluno.Nome = "Henry Cavil";
            aluno.Turma = "Turma X";
            //act 
            aluno.AtualizarDados(nome, turma);
            //assert
            Assert.Equal(aluno.Nome, nome);
            Assert.Equal(aluno.Turma, turma);
        }

        [Fact]
        public void VerificaAprovacao()
        {
            //arrange
            Aluno aluno = new Aluno();
            aluno.Media = 10;

            //act
           
            //assert
            Assert.True(aluno.VerificaAprovacao());
        }

        [Fact]
        public void VerificaAprovacaoFalsa()
        {
            //Arrange

            Aluno aluno = new Aluno();
            aluno.Media = 4;
            //Act

            //Assert
            Assert.False(aluno.VerificaAprovacao());
        }

        [Fact]
        public void AtualizarMediaDoAluno()
        {
            //Arrange

            Aluno aluno = new Aluno();
            aluno.Media = 4;
            //Act
            aluno.AtualizaMedia(10);
            //Assert
            Assert.Equal(10, aluno.Media);

        }



    }
}
