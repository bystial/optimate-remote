using Microsoft.VisualStudio.TestTools.UnitTesting;
using OptiMate;
using OptiMate.ViewModels;
using Prism.Events;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VMS.TPS.Common.Model.API;
using OptiMate.Logging;
using System.Windows.Media;
using OptiMate.Converters;
using System.Windows;
using OptiMate.Models;
using Moq;

namespace UnitTests
{
    [TestClass]
    public class UnitTests_GSMVM
    {
        [TestMethod]
        public void TestMethod_GSMVM_xx()
        {
            var IM_Mock = new Mock<IInstructionModel>();
            IM makeIM = new IM(IM_Mock.Object);
            
            var GSMVM_Mock = new Mock<IGeneratedStructureModel>();
            var obj = GSMVM_Mock.Setup(x => x.AddInstruction(It.IsAny<OperatorTypes>(), It.IsAny<int>()))
                .Returns();
        }
    }
    public class GSMVM
    {
        private readonly IGeneratedStructureModel intr;
        bool ClearFirst { get; set; }
        bool isStructureIdValid { get; }
        System.Windows.Media.Color StructureColor { get; set; }
        string StructureId { get; set; }
        bool OverwriteColor { get; set; }
        CleanupOptions CleanupOption { get; set; }
        public GSMVM(IGeneratedStructureModel intr)
        {
            this.intr = intr;
        }
        InstructionModel AddInstruction(OperatorTypes selectedOperator, int index)
        { return intr.AddInstruction(selectedOperator, index); }
        List<IInstructionModel> GetInstructions()
        { return intr.GetInstructions(); }
        System.Windows.Media.Color GetStructureColor()
        { return intr.GetStructureColor(); }
        int GetInstructionNumber(IInstructionModel instruction)
        {  return intr.GetInstructionNumber(instruction); }
        InstructionModel ReplaceInstruction(IInstructionModel instruction, OperatorTypes selectedOperator)
        { return intr.ReplaceInstruction(instruction, selectedOperator); }
        bool GenStructureWillBeEmpty()
        { return intr.GenStructureWillBeEmpty(); }
    }
    public class IM
    {
        private readonly IInstructionModel instr;
        public IM(IInstructionModel instr)
        {
            this.instr = instr;
        }
        ushort? AntMargin { get; set; }
        string DefaultInstructionTargetId { get; set; }
        ushort? DoseLevel { get; set; }
        bool? IsDoseLevelAbsolute { get; set; }
        bool IsDoseLevelValid { get; }
        int Index { get; set; }
        ushort? InfMargin { get; set; }
        InstructionTargetModel InstructionTarget { get; set; }
        bool IsAntMarginValid { get; }
        bool IsInfMarginValid { get; }
        bool isInstructionTargetIdValid { get; }
        bool IsIsoMarginValid { get; }
        bool IsLeftMarginValid { get; }
        ushort? IsoMargin { get; set; }
        bool IsPostMarginValid { get; }
        bool IsRightMarginValid { get; }
        bool IsSupMarginValid { get; }
        ushort? LeftMargin { get; set; }
        MarginTypes? MarginType { get; set; }
        OperatorTypes Operator { get; }
        ushort? PostMargin { get; set; }
        ushort? RightMargin { get; set; }
        ushort? SupMargin { get; set; }
        ushort? IsoCropOffset { get; set; }
        bool IsIsoCropOffsetValid { get; }
        ushort? LeftCropOffset { get; set; }
        bool IsLeftCropOffsetValid { get; }
        ushort? RightCropOffset { get; set; }
        bool IsRightCropOffsetValid { get; }
        ushort? SupCropOffset { get; set; }
        bool IsSupCropOffsetValid { get; }
        ushort? InfCropOffset { get; set; }
        bool IsInfCropOffsetValid { get; }
        ushort? AntCropOffset { get; set; }
        bool IsAntCropOffsetValid { get; }
        ushort? PostCropOffset { get; set; }
        bool IsPostCropOffsetValid { get; }
        bool? InternalCrop { get; set; }
        Guid InstructionId { get; }
        double? SupBound { get; set; }
        double? InfBound { get; set; }
        bool IsSupBoundValid { get; }
        bool IsInfBoundValid { get; }
        short? HUValue { get; set; }
        bool IsHUValueValid { get; }
        List<InstructionTargetModel> GetAvailableTargets()
        { return instr.GetAvailableTargets(); }
        InstructionModel ReplaceInstruction(OperatorTypes value)
        { return instr.ReplaceInstruction(value); }
        void Remove()
        {  instr.Remove(); }
        bool InstructionHasTarget()
        { return instr.InstructionHasTarget(); }
    }
}
