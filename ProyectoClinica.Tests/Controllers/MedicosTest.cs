using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using ProyectoClinica.Controllers;

namespace ProyectoClinica.Tests.Controllers
{
    [TestClass]
    public class MedicosTest
    {

        readonly MedicosController controller = new MedicosController();
        [TestMethod]
        public void TestMedicosCreate()
        {

            Medicos medico = new Medicos();
            medico.nombre = "Nombre Prueba4";
            medico.apellido = "apellido prueba4";
            medico.identificacion = "10941234";
            Assert.IsNotNull(controller.Create(medico));

        }

        [TestMethod]
        public void TestMedicosDelete()
        {
            Assert.IsNotNull(controller.DeleteConfirmed(6));
        }

        [TestMethod]
        public void TestMedicosFind()
        {
            Assert.AreNotEqual("System.Web.Mvc.HttpNotFoundResult", controller.Details(1).ToString());
        }

        [TestMethod]
        public void TestMedicosEdit()
        {

            Medicos medico = new Medicos();
            medico.nombre = "Nombre Prueba";
            medico.apellido = "apellido prueba";
            medico.identificacion = "10941234";
            medico.idMedico = 1;
            Assert.IsNotNull(controller.Edit(medico));

        }
    }
}
