using CadastroAluno.Contract;
using CadastroAluno.Controllers;
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

        public AlunosControllerTest()
        {
            AlunosController controller = new AlunosController(_repository.Object);
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

    }
}
