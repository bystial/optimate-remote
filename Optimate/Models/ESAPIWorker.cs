using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Threading;
using VMS.TPS.Common.Model.API;
using VMS.TPS.Common.Model.Types;
using Ninject;
using Ninject.Modules;

namespace OptiMate
{
    public interface IEsapiWorker
    {
        string UserId { get; }
        PlanSetup PlanSetup { get; }
        StructureSet StructureSet { get; }
        Patient Patient { get; }
        Dispatcher Dispatcher { get; }
        Task<bool> AsyncRunStructureContext(Action<Patient, StructureSet, Dispatcher> a);
        Task<bool> AsyncRunPlanContext(Action<Patient, PlanSetup, StructureSet, Dispatcher> a);
    }
    public class EsapiWorker : IEsapiWorker
    {
        private readonly StructureSet ss = null;
        private readonly PlanSetup pl = null;
        private readonly Patient p = null;
        private readonly Dispatcher dispatcher = null;
        private readonly string uid;
        public string UserId { get { return uid; } }
        public PlanSetup PlanSetup { get { return pl; } }
        public StructureSet StructureSet { get { return ss; } }
        public Patient Patient { get { return p; } }
        public Dispatcher Dispatcher { get { return dispatcher; } }
        
        public EsapiWorker(ScriptContext context)
        {
            p = context.Patient;
            uid = context.CurrentUser.Id;
            ss = context.StructureSet;
            dispatcher = Dispatcher.CurrentDispatcher;

            if (context.PlanSetup != null)
            {
                this.pl = context.PlanSetup;
            }
        }

        public EsapiWorker(Patient p, StructureSet ss, string userId)
        {
            this.p = p;
            uid = userId;
            this.ss = ss;
            dispatcher = Dispatcher.CurrentDispatcher;
        }

        public EsapiWorker(Patient p, PlanSetup pl, StructureSet ss, string userId)
        {
            this.p = p;
            this.pl = pl;
            this.uid = userId;
            this.ss = ss;
            dispatcher = Dispatcher.CurrentDispatcher;
        }

        public delegate void D(Patient p, StructureSet s);
        public async Task<bool> AsyncRunStructureContext(Action<Patient, StructureSet, Dispatcher> a)
        {
            await dispatcher.BeginInvoke(a, p, ss, dispatcher);
            return true;
        }

        public async Task<bool> AsyncRunPlanContext(Action<Patient, PlanSetup, StructureSet, Dispatcher> a)
        {
            await dispatcher.BeginInvoke(a, p, pl, ss, dispatcher);
            return true;
        }
    }
}
