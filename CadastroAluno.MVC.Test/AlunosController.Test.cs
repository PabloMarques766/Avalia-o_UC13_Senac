using CadastroAluno.Contract;
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
            _repository = new Mock<IAlunoRepository>();
        }
    }
}
