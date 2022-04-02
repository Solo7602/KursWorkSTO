using BuisnessLogic.BuisnessLogic;
using BuisnessLogic.BuisnessLogicInterfaces;
using BuisnessLogic.StorageInterfaces;
using DatabaseImplement.Implements;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using Unity;
using Unity.Lifetime;

namespace ClientView
{
    internal static class Program
    {
        private static IUnityContainer container = null;
        public static IUnityContainer Container
        {
            get
            {
                if (container == null)
                {
                    container = BuildUnityContainer();
                }
                return container;
            }
        }
        /// <summary>
        ///  The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.SetHighDpiMode(HighDpiMode.SystemAware);
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            //Application.Run(new FormMain());
            Application.Run(Container.Resolve<FormMain>());
        }
        private static IUnityContainer BuildUnityContainer()
        {
            var currentContainer = new UnityContainer();
            currentContainer.RegisterType<IEmployeeStorage,
            EmployeeStorage>(new HierarchicalLifetimeManager());
            currentContainer.RegisterType<IStaffStorage, StaffStorage>(new
            HierarchicalLifetimeManager());
            currentContainer.RegisterType<IWorkStorage, WorkStarage>(new
            HierarchicalLifetimeManager());
            currentContainer.RegisterType<IEmployeeLogic, EmployeeLogic>(new
            HierarchicalLifetimeManager());
            currentContainer.RegisterType<IWorkLogic, WorkLogic>(new
            HierarchicalLifetimeManager());
            currentContainer.RegisterType<IStaffLogic, StaffLogic>(new
            HierarchicalLifetimeManager());
            return currentContainer;
        }
    }
}
