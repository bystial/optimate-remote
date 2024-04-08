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
using System.Reflection;

namespace UnitTesting
{
    [TestClass]
    public class UnitTest_MainModel
    {
        [TestMethod]
        public void Test_GetEclipseStructureIds_List()
        {
            var mainModelMock = new Mock<IMainModel>();
            mainModelMock.Setup(x => x.GetEclipseStructureIds(It.IsAny<string>())).Returns(new List<string> { "1", "2", "3" });
            MainModel mod0 = new MainModel(mainModelMock.Object);
            var doSomething = mod0.GetEclipseStructureIds();
            Assert.AreEqual(3, doSomething.Count);
        }
        [TestMethod]
        public void Test_LoadTemplate_Name()
        {
            var mainModelMock = new Mock<IMainModel>();
            mainModelMock.Setup(x => x.LoadTemplate(It.IsAny<TemplatePointer>()))
                .Returns(new OptiMateTemplate() { TemplateDisplayName = "Test" });
            MainModel mod0 = new MainModel(mainModelMock.Object);
            var doSomething = mod0.LoadTemplate(It.IsAny<TemplatePointer>());
            Assert.AreEqual("Test", doSomething.TemplateDisplayName);
        }
        [TestMethod]
        public void TestTest()
        {
            
        }
    }
    [TestClass]
    public class UnitTest_GenerateStructureModel
    {
        //[TestMethod]
        //public void Test_GetTargetstructure_xx()
        //{
            
        //    var gsmMock = new Mock<IGenerateStructureModel>();
        //    gsmMock.Setup(x => x.GetTargetStructure(It.IsAny<StructureSet>(), It.IsAny<TemplateStructure>()))
        //        .Returns();
        //}
    }
}
