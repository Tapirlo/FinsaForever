using Xunit;
using FluentAssertions;
using Microsoft.AspNetCore.Mvc;
using CorsiOnline.Models.Database;
using CorsiOnline.Models.Core;
using CorsiOnline.Models;
using Moq;
using CorsiOnline.Controllers;
using Xunit.Abstractions;
using CorsiOnline.ViewModels;
using System.Collections;
using CorsiOnline.Controllers.ApiControllers;
using CorsiOnline.ViewModels.DTOS;

namespace XUnitTestProject1.ControllerTest
{
        public class CorsoControllerTest
        {
        private Mock<IRepositoryCorsi> mockRepositoryCorsi;
        private ITestOutputHelper output;
        public CorsoControllerTest(ITestOutputHelper o)
        {
            output = o;
            mockRepositoryCorsi = new Mock<IRepositoryCorsi>();

            mockRepositoryCorsi.SetReturnsDefault<bool>(true);
            Corso[] corsi ={
                new Corso { IDCorso="1",Nome="corso1"},
                new Corso { IDCorso = "2", Nome = "corso2" }
                    };
            mockRepositoryCorsi.Setup(x=>x.GetCorsiByName("test")).Returns(corsi);
            mockRepositoryCorsi.Setup(x => x.GetCorsoByID("3")).Returns(new Corso { IDCorso = "3", Nome = "corso1" });
        }

        [Fact]
        public void UpdateCorso()
        {
            var corsoController = new CorsoApiController(mockRepositoryCorsi.Object);
            var result = corsoController.UpdateCorso(new Corso());
            result.Should().BeOfType<OkObjectResult>();
        }

        [Fact]
        public void ListaCorsi()
        {
            var corsoController = new CorsoApiController(mockRepositoryCorsi.Object);
            var result = corsoController.ListaCorsi("test");
            IEnumerable list = (IEnumerable)((OkObjectResult)result).Value;

            foreach(CorsoModels c in list)
            {
                output.WriteLine(c.ToString());
            }

            result.Should().BeOfType<OkObjectResult>();
            

        }

        [Fact]
        public void CorsoPerID()
        {
            var corsoController = new CorsoApiController(mockRepositoryCorsi.Object);
            var result = corsoController.CorsoPerID("3");
            result.Should().BeOfType<OkObjectResult>();
            ((OkObjectResult)result).Value.Should().BeOfType<Corso>();
        }
    }
}
