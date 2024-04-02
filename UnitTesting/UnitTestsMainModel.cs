using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using Optimate;
using Optimate.ViewModels;
using OptiMate.ViewModels;
using Prism.Events;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Xml.Serialization;
using VMS.TPS.Common.Model.API;
using Moq;
using OptiMate.Models;

namespace UnitTesting
{
    [TestClass]
    public class UnitTest_MainModel
    {
        [TestMethod]
        public void TestMethod()
        {
            var mainModelMock = new Mock<IMainModel>();
            mainModelMock.Setup(x => x.GetEclipseStructureIds(It.IsAny<string>())).Returns(new List<string> { "1", "2", "3" });
        }
    }
}
