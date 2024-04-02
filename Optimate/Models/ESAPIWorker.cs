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

namespace Optimate
{
    public interface IEspaiWorker
    {
        StructureSet SS { get; }
        Patient P { get; }
        Dispatcher Dispatcher { get; }
        Task<bool> AsyncRunStructureContext(Action<Patient, StructureSet, Dispatcher> a);
    }
    public class EsapiWorker
    {
        private readonly IEspaiWorker worker;
        public EsapiWorker(IEspaiWorker worker)
        {
            this.worker = worker;
        } 
        public async Task<bool> AsyncRunStructureContext(Action<Patient, StructureSet, Dispatcher> a)
        {
            return await worker.AsyncRunStructureContext(a);
        }
    }
    public class EsapiWorker_Default : IEspaiWorker
    {
        private readonly StructureSet ss = null;
        private readonly Patient p = null;
        private readonly Dispatcher dispatcher = null;
        public StructureSet SS
        {
            get { return ss; }
        }
        public Patient P
        {
            get { return p; }
        }
        public Dispatcher Dispatcher
        {
            get { return dispatcher; }
        }
        public EsapiWorker_Default(Patient p, StructureSet ss)
        {
            this.p = p;
            this.ss = ss;
            dispatcher = Dispatcher.CurrentDispatcher;
        }
    
        public delegate void D(Patient p, StructureSet s);
        public async Task<bool> AsyncRunStructureContext(Action<Patient, StructureSet, Dispatcher> a)
        {
            await dispatcher.BeginInvoke(a, p, ss, dispatcher);
            return true;
        }
    }
}
