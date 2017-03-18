using CrazyHacks.ViewModel;
using Microsoft.Practices.Unity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CrazyHacks
{
    public class BootStrapper
    {
        public IUnityContainer Container { get; set; }

        public BootStrapper()
        {
            Container = new UnityContainer();

            ConfigureContainer();
        }

        /// <summary>
        /// We register here every service / interface / viewmodel.
        /// </summary>
        private void ConfigureContainer()
        {
            //Container.RegisterInstance<INoteRepository>(new NoteRepository("notes"));
            //Container.RegisterInstance<ICategoryRepository>(new CategoryRepository("categories"));
            Container.RegisterType<MainWindowViewModel>();
            Container.RegisterType<MainControlViewModel>();
            Container.RegisterType<ChromeControlViewModel>();
            Container.RegisterType<XssControlViewModel>();
        }
    }
}
