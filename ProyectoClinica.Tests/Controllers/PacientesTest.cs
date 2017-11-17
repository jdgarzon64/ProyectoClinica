using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using ProyectoClinica.Controllers;

namespace ProyectoClinica.Tests.Controllers
{
    [TestClass]
    public class PacientesTest
    {
        PacientesController controller = new PacientesController();

        [TestMethod]
        public void TestPacientesDelete()
        {
            Assert.IsNotNull(controller.DeleteConfirmed(2));
        }

        [TestMethod]
        public void TestPacientesFind()
        {
            Assert.AreNotEqual("System.Web.Mvc.HttpNotFoundResult", controller.Details(3).ToString());
        }
     
    }
}
