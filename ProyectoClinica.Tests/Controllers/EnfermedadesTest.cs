using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using ProyectoClinica;
using ProyectoClinica.Controllers;

namespace ProyectoClinica.Tests.Controllers
{
    [TestClass]
    public class EnfermedadesTest
    {

        EnfermedadesController controller = new EnfermedadesController();
        [TestMethod]
        public void TestEnfermedadesCreate()
        {
           
            Enfermedades enfermedad = new Enfermedades();
            enfermedad.nombre = "enfermedadPrueba";
            enfermedad.descripcion = "enfermedadPruebaDescripcion";
            Assert.IsNotNull(controller.Create(enfermedad));
           
        }

        [TestMethod]
        public void TestEnfermedadesDelete()
        {
            Assert.IsNotNull(controller.DeleteConfirmed(1004));
        }

        [TestMethod]
        public void TestEnfermedadesFind()
        {
           Assert.AreNotEqual("System.Web.Mvc.HttpNotFoundResult", controller.Details(1).ToString());
        }

        [TestMethod]
        public void TestEnfermedadesEdit()
        {

            Enfermedades enfermedad = new Enfermedades();
            enfermedad.nombre = "enfermedadPruebaEDITADA";
            enfermedad.descripcion = "enfermedadPruebaDescripcionEDITADA";
            enfermedad.idEnfermedad = 1005;
            Assert.IsNotNull(controller.Edit(enfermedad));

        }
    }
}
