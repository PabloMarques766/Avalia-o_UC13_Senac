using CadastroAluno.Contract;
using CadastroAluno.Controllers;
using CadastroAluno.Models;
using Microsoft.AspNetCore.Mvc;
using Moq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace CadastroAluno.MVC.Test
{
    public class AlunosControllerTest
    {

        Mock<IAlunoRepository> _repository;
        Aluno alunoMoq;

        public AlunosControllerTest()
        {
            _repository = new Mock<IAlunoRepository>();
        }
        [Fact]
        public async void Index_RetornaOkResult()
        {
            //arrange 
            AlunosController controller = new AlunosController(_repository.Object);
            //act
            var alunos = await controller.Index();
            //assert
            Assert.IsType<ViewResult>(alunos);
        }

        [Fact]
        public async void DetailEncontrarAlunoNoBanco()
        {
            //arrange
            AlunosController controller = new AlunosController(_repository.Object);

            Aluno aluno = new Aluno();
            aluno.Id = 1;

            _repository.Setup(a => a.GetAluno(1))
               .ReturnsAsync(aluno);

            //act
            var alunos = await controller.Details(1);
            //assert
            Assert.IsType<ViewResult>(alunos);
        }

        [Fact]
        public async void DetailsBadRequestIdInvalido()
        {
            //arrange
            AlunosController controller = new AlunosController(_repository.Object);

            Aluno aluno = new Aluno();
            aluno.Id = 1;

            _repository.Setup(a => a.GetAluno(1000))
               .ReturnsAsync(aluno);

            //act
            var alunos = await controller.Details(1);
            //assert
            Assert.IsType<NotFoundResult>(alunos);
        }

        [Fact]
        public async void DetailsBadRequest()
        {
            //arrange
            AlunosController controller = new AlunosController(_repository.Object);

            //act
            var alunos = await controller.Details(-5);
            //assert
            Assert.IsType<BadRequestResult>(alunos);
        }

        [Fact]
        public async void Index_RetornaRepositorio_UmaVez()
        {
            //Arrange
            var controller = new AlunosController(_repository.Object);

            _repository.Setup(a => a.GetAlunos());

            //Act
            await controller.Index();

            //Assert
            _repository.Verify(alunoRepo => alunoRepo.GetAlunos(), Times.Once);

        }


    }
}
