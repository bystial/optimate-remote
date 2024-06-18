using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Threading;
using OptiMate;
using OptiMate.ViewModels;
using OptiMate.Models;
using System.Collections;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Hosting.WindowsServices;
using Ninject;
using VMS.TPS.Common.Model.API;
using Ninject.Modules;

namespace OptiMate.Services
{
    public class EWorker
    {
        readonly IEsapiWorker worker;
        public EWorker(IEsapiWorker worker)
        {
            this.worker = worker;
        }
    }

    public class EWorkerModule : NinjectModule
    {
        public override void Load()
        {
            Bind<IEsapiWorker>().To<EsapiWorker>();
        }
    }
}
