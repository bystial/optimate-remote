using Optimate;
using Optimate.ViewModels;
using OptiMate.ViewModels;
using Prism.Events;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Xml.Serialization;
using VMS.TPS.Common.Model.API;

namespace OptiMate.Models
{
    public struct StructureGeneratedEventInfo
    {
        public GeneratedStructure Structure;
        public int IndexInQueue;
        public int TotalToGenerate;
        public List<string> Warnings;
    }
    public struct InstructionRemovedEventInfo
    {
        public GeneratedStructure Structure;
        public Instruction RemovedInstruction;
    }
    public struct InstructionAddedEventInfo
    {
        public GeneratedStructure Structure;
        public Instruction AddedInstruction;
    }
    public struct NewTemplateStructureEventInfo
    {
        public TemplateStructure Structure;
    }
    public struct RemovedTemplateStructureEventInfo
    {
        public TemplateStructure RemovedStructure;
    }
    public struct RemovedGeneratedStructureEventInfo
    {
        public string RemovedStructureId;
    }
    public struct NewGeneratedStructureEventInfo
    {
        public GeneratedStructure NewStructure;
    }
    public class RemovedInstructionEvent : PubSubEvent<InstructionRemovedEventInfo> { }
    public class ModelInitializedEvent : PubSubEvent { }
    public class AddedInstructionEvent : PubSubEvent<InstructionAddedEventInfo> { }
    public class StructureGeneratedEvent : PubSubEvent<StructureGeneratedEventInfo> { }
    public class NewTemplateStructureEvent : PubSubEvent<NewTemplateStructureEventInfo> { }
    public class RemovedTemplateStructureEvent : PubSubEvent<RemovedTemplateStructureEventInfo> { }
    public class RemovedGeneratedStructureEvent : PubSubEvent<RemovedGeneratedStructureEventInfo> { }
    public class NewGeneratedStructureEvent : PubSubEvent<NewGeneratedStructureEventInfo> { }
    public interface IMainModel
    {
        string StructureSetId { get; }
        //void Initialize(); //to be changed..
        Task InitializeAsync();
        List<string> GetEclipseStructureIds(string thisGenStructureId = "");
        List<string> GetGeneratedStructureIds();
        List<string> GetAvailableTemplateTargetIds(string thisGenStructureId = "");
        Task<(bool, List<string>)> GenerateStructures();
        List<TemplateStructure> GetAugmentedTemplateStructures(string structureId);
        List<string> GetTemplateStructureIds();
        void SetEventAggregator(IEventAggregator ea);
        OptiMateTemplate LoadTemplate(TemplatePointer value);
        string GetNewTemplateStructureId();
        string GetNewGenStructureId();
        TemplateStructure AddTemplateStructure();
        void RemoveTemplateStructure(string templateStructureId);
        void RemoveInstruction(string structureId, Instruction instruction);
        int GetInstructionNumber(string structureId, Instruction instruction);
        Instruction AddInstruction(GeneratedStructure generatedStructure, OperatorTypes selectedOperator, int index);
        Instruction ReplaceInstruction(GeneratedStructure parentGeneratedStructure, Instruction instruction, OperatorTypes selectedOperator);
        Instruction CreateInstruction(OperatorTypes selectedOperator);
        bool IsEmpty(string eclipseStructureId);
        GeneratedStructure AddGeneratedStructure();
        void RemoveGeneratedStructure(string structureId);
        bool IsGeneratedStructureIdValid(string value);
        bool IsTemplateStructureIdValid(string value);
    }
    public sealed class MainModel
    {
        private readonly IMainModel model;
        private readonly string structureSetId;
        public string StructureSetId
        {
            get { return structureSetId; }
        }
        public MainModel(IMainModel model)
        {
            this.model = model;
        }
        //public void Initialize()
        //{
        //    model.Initialize();
        //}
        public Task InitializeAsync()
        {
            return model.InitializeAsync();
        }
        public List<string> GetEclipseStructureIds(string thisGenStructureId = "")
        {
            return model.GetEclipseStructureIds(thisGenStructureId);
        }
        public List<string> GetGeneratedStructureIds()
        {
            return model.GetGeneratedStructureIds();
        }
        public List<string> GetAvailableTemplateTargetIds(string thisGenStructureId = "")
        {
            return model.GetAvailableTemplateTargetIds(thisGenStructureId);
        }
        public Task<(bool, List<string>)> GenerateStructures()
        {
            return model.GenerateStructures();
        }
        public List<TemplateStructure> GetAugmentedTemplateStructures(string structureId)
        {
            return model.GetAugmentedTemplateStructures(structureId);
        }
        public List<string> GetTemplateStructureIds()
        {
            return model.GetTemplateStructureIds();
        }
        public void SetEventAggregator(IEventAggregator ea)
        {
            model.SetEventAggregator(ea);
        }
        public OptiMateTemplate LoadTemplate(TemplatePointer value)
        {
            return model.LoadTemplate(value);
        }
        public string GetNewTemplateStructureId()
        {
            return model.GetNewTemplateStructureId();
        }
        public string GetNewGenStructureId()
        {
            return model.GetNewGenStructureId();
        }
        public TemplateStructure AddTemplateStructure()
        {
            return model.AddTemplateStructure();
        }
        public void RemoveTemplateStructure(string templateStructureId)
        {
            model.RemoveTemplateStructure(templateStructureId);
        }
        public void RemoveInstruction(string structureId, Instruction instruction)
        {
            model.RemoveInstruction(structureId, instruction);
        }
        public int GetInstructionNumber(string structureId, Instruction instruction)
        {
            return model.GetInstructionNumber(structureId, instruction);
        }
        public Instruction AddInstruction(GeneratedStructure generatedStructure, OperatorTypes selectedOperator, int index)
        {
            return model.AddInstruction(generatedStructure, selectedOperator, index);
        }
        public Instruction ReplaceInstruction(GeneratedStructure parentGeneratedStructure, Instruction instruction, OperatorTypes selectedOperator)
        {
            return model.ReplaceInstruction(parentGeneratedStructure, instruction, selectedOperator);
        }
        public Instruction CreateInstruction(OperatorTypes selectedOperator)
        {
            return model.CreateInstruction(selectedOperator);
        }
        public bool IsEmpty(string eclipseStructureId)
        {
            return model.IsEmpty(eclipseStructureId);
        }
        public GeneratedStructure AddGeneratedStructure()
        {
            return model.AddGeneratedStructure();
        }
        public void RemoveGeneratedStructure(string structureId)
        {
            model.RemoveGeneratedStructure(structureId);
        }
        public bool IsGeneratedStructureIdValid(string value)
        {
            return model.IsGeneratedStructureIdValid(value);
        }
        public bool IsTemplateStructureIdValid(string value)
        {
            return model.IsTemplateStructureIdValid(value);
        }
    }
    public class MainModel_Default : IMainModel
    {
        private readonly EsapiWorker ew = null;
        private IEventAggregator ea = null;
        private OptiMateTemplate template = null;

        private List<string> availableStructureIds = new List<string>();
        private string ssID; 
        public string StructureSetId { get { return ssID; } }
        public MainModel_Default(EsapiWorker ew)
        {
            this.ew = ew;
        }
        private MainModel_Default() { }
        /*
         * Can assign this task to a property to avoid some potential problems
         * https://blog.stephencleary.com/2013/01/async-oop-2-constructors.html
         * -HL
        */
        public async Task InitializeAsync()
        {
            bool done = await Task.Run(() => ew.AsyncRunStructureContext((p, ss, ui) =>
            {
                p.BeginModifications();
                availableStructureIds = ss.Structures.Select(x => x.Id).ToList();
                ssID = ss.Id;
                // one time initialization
                isStructureEmpty = new Dictionary<string, bool>();
                foreach (var s in ss.Structures)
                {
                    isStructureEmpty.Add(s.Id, s.IsEmpty);
                }
            }));
            ea.GetEvent<ModelInitializedEvent>().Publish();
        }
        public List<string> GetEclipseStructureIds(string thisGenStructureId = "")
        {
            return new List<string>(availableStructureIds);
        }

        public List<string> GetGeneratedStructureIds()
        {
            return new List<string>(template.GeneratedStructures.Select(x => x.StructureId));
        }
        public List<string> GetAvailableTemplateTargetIds(string thisGenStructureId = "")
        {
            var availableStructures = template.TemplateStructures.Select(x => x.TemplateStructureId).ToList();
            availableStructures.AddRange(template.GeneratedStructures.Take(template.GeneratedStructures.Select(x => x.StructureId).ToList().IndexOf(thisGenStructureId)).Select(x => x.StructureId));
            return availableStructures;
        }

        public async Task<(bool, List<string>)> GenerateStructures()
        {
            int index = 0;
            List<string> completionWarnings = new List<string>();
            foreach (var genStructure in template.GeneratedStructures)
            {
                List<TemplateStructure> augmentedList = GetAugmentedTemplateStructures(genStructure.StructureId);
                var structureModel_Imp = new GenerateStructureModel_Default(ew, ea, genStructure, augmentedList);
                var structureModel = new GenerateStructureModel(structureModel_Imp);
                await structureModel.GenerateStructure();
                completionWarnings.AddRange(structureModel.GetCompletionWarnings());
                ea.GetEvent<StructureGeneratedEvent>().Publish(new StructureGeneratedEventInfo { Structure = genStructure, IndexInQueue = index++, TotalToGenerate = template.GeneratedStructures.Count() });
            }
            if (completionWarnings.Count > 0)
            {
                return (true, completionWarnings);
            }
            else
            {
                return (false, completionWarnings);
            }
        }

        public List<TemplateStructure> GetAugmentedTemplateStructures(string structureId)
        {
            var augmentedList = template.TemplateStructures.ToList();
            foreach (var genStructure in template.GeneratedStructures.Take(template.GeneratedStructures.Select(x => x.StructureId).ToList().IndexOf(structureId)))
            {
                augmentedList.Add(new TemplateStructure() { TemplateStructureId = genStructure.StructureId, EclipseStructureId = genStructure.StructureId});
            }
            return augmentedList;
        }

        public List<string> GetTemplateStructureIds()
        {
            return new List<string>(template.TemplateStructures.Select(x => x.TemplateStructureId));
        }
        public void SetEventAggregator(IEventAggregator ea)
        {
            this.ea = ea;
        }

        public OptiMateTemplate LoadTemplate(TemplatePointer value)
        {
            XmlSerializer Ser = new XmlSerializer(typeof(OptiMateTemplate));
            if (value != null)
            {
                try
                {
                    using (StreamReader templateData = new StreamReader(value.TemplatePath))
                    {
                        template = (OptiMateTemplate)Ser.Deserialize(templateData);
                    }
                }
                catch (Exception ex)
                {
                    Helpers.SeriLog.AddError(string.Format("Unable to read protocol file: {0}", value.TemplatePath, ex));
                    MessageBox.Show(string.Format("Unable to read/interpret protocol file {0}, see log for details.", value.TemplatePath));
                }

            }
            else
            {
                template = null;
            }
            if (template != null)
            {
                Helpers.SeriLog.AddLog($"Protocol [{value.TemplateDisplayName}] selected");
                return template;
            }
            else return null;

        }

        public string GetNewTemplateStructureId()
        {
            int count = 1;
            string baseId = "NewTS";
            while (!IsTemplateStructureIdValid(baseId + count))
            {
                count++;
            }
            return baseId + count;
        }
        public string GetNewGenStructureId()
        {
            int count = 1;
            string baseId = "NewGS";
            while (!IsGeneratedStructureIdValid(baseId + count))
            {
                count++;
            }
            return baseId + count;
        }
        public TemplateStructure AddTemplateStructure()
        {
            var newTemplateStructure = new TemplateStructure()
            {
                TemplateStructureId = GetNewTemplateStructureId()
            };
            var templateList = template.TemplateStructures.ToList();
            templateList.Add(newTemplateStructure);
            template.TemplateStructures = templateList.ToArray();
            ea.GetEvent<NewTemplateStructureEvent>().Publish(new NewTemplateStructureEventInfo { Structure = newTemplateStructure });
            return newTemplateStructure;
        }

        public void RemoveTemplateStructure(string templateStructureId)
        {
            var templateStructures = template.TemplateStructures.ToList();
            var removedStructure = templateStructures.FirstOrDefault(x => x.TemplateStructureId == templateStructureId);
            templateStructures.Remove(removedStructure);
            template.TemplateStructures = templateStructures.ToArray();
            ea.GetEvent<RemovedTemplateStructureEvent>().Publish(new RemovedTemplateStructureEventInfo { RemovedStructure = removedStructure });
        }

        public void RemoveInstruction(string structureId, Instruction instruction)
        {
            var genStructure = template.GeneratedStructures.FirstOrDefault(x => x.StructureId == structureId);
            var instructionItems = genStructure.Instructions.Items.ToList();
            instructionItems.Remove(instruction);
            template.GeneratedStructures.FirstOrDefault(x => x.StructureId == structureId).Instructions.Items = instructionItems.ToArray();
            ea.GetEvent<RemovedInstructionEvent>().Publish(new InstructionRemovedEventInfo { Structure = genStructure, RemovedInstruction = instruction });
        }

        public int GetInstructionNumber(string structureId, Instruction instruction)
        {
            var genStructure = template.GeneratedStructures.FirstOrDefault(x => x.StructureId == structureId);
            var temp = genStructure.Instructions.Items.ToList().IndexOf(instruction);
            return temp;
        }

        public Instruction AddInstruction(GeneratedStructure generatedStructure, OperatorTypes selectedOperator, int index)
        {
            var newInstruction = CreateInstruction(selectedOperator);
            var instructionItems = generatedStructure.Instructions.Items.ToList();
            instructionItems.Insert(index, newInstruction);
            generatedStructure.Instructions.Items = instructionItems.ToArray();
            return newInstruction;
        }

        public Instruction ReplaceInstruction(GeneratedStructure parentGeneratedStructure, Instruction instruction, OperatorTypes selectedOperator)
        {
            var genStructure = template.GeneratedStructures.FirstOrDefault(x => x.StructureId == parentGeneratedStructure.StructureId);
            var instructionItems = genStructure.Instructions.Items.ToList();
            var index = instructionItems.IndexOf(instruction);
            instructionItems.Remove(instruction);
            var newInstruction = CreateInstruction(selectedOperator);
            instructionItems.Insert(index, newInstruction);
            genStructure.Instructions.Items = instructionItems.ToArray();
            return newInstruction;
        }

        public Instruction CreateInstruction(OperatorTypes selectedOperator)
        {

            switch (selectedOperator)
            {
                case OperatorTypes.and:
                    return new And();
                case OperatorTypes.or:
                    return new Or();
                case OperatorTypes.asymmetricMargin:
                    return new AsymmetricMargin();
                case OperatorTypes.sub:
                    return new Sub();
                case OperatorTypes.crop:
                    return new Crop();
                case OperatorTypes.margin:
                    return new Margin();
                case OperatorTypes.convertDose:
                    return new ConvertDose();
                default:
                    return new Instruction();
            }
        }

        private Dictionary<string, bool> isStructureEmpty = null;
        public bool IsEmpty(string eclipseStructureId)
        {

            if (isStructureEmpty.ContainsKey(eclipseStructureId))
            {
                return isStructureEmpty[eclipseStructureId];
            }
            else
            {
                return true;
            }
        }

        public GeneratedStructure AddGeneratedStructure()
        {
            var newGeneratedStructure = new GeneratedStructure()
            {
                StructureId = GetNewGenStructureId(),
                Instructions = new GeneratedStructureInstructions() { Items = new Instruction[] {new Copy() } }
            };
            var genStructures = template.GeneratedStructures.ToList();
            genStructures.Add(newGeneratedStructure);
            template.GeneratedStructures = genStructures.ToArray();
            ea.GetEvent<NewGeneratedStructureEvent>().Publish(new NewGeneratedStructureEventInfo { NewStructure = newGeneratedStructure });
            return newGeneratedStructure;
        }

        public void RemoveGeneratedStructure(string structureId)
        {
            var genStructures = template.GeneratedStructures.ToList();
            genStructures.Remove(genStructures.FirstOrDefault(x => x.StructureId == structureId));
            template.GeneratedStructures = genStructures.ToArray();
            ea.GetEvent<RemovedGeneratedStructureEvent>().Publish(new RemovedGeneratedStructureEventInfo { RemovedStructureId = structureId });
        }

        public bool IsGeneratedStructureIdValid(string value)
        {
            if (value.Length <=16 
                && value.Length>0 
                && !template.GeneratedStructures.Select(x=>x.StructureId).Contains(value, StringComparer.OrdinalIgnoreCase)
                && !template.TemplateStructures.Select(x=>x.TemplateStructureId).Contains(value, StringComparer.OrdinalIgnoreCase))
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public bool IsTemplateStructureIdValid(string value)
        {
            if (value.Length <= 16
                && value.Length > 0
                && !template.GeneratedStructures.Select(x => x.StructureId).Contains(value, StringComparer.OrdinalIgnoreCase)
                && !template.TemplateStructures.Select(x => x.TemplateStructureId).Contains(value, StringComparer.OrdinalIgnoreCase))
            {
                return true;
            }
            else
            {
                return false;
            }
        }
    }
}

