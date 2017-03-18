/*
  In App.xaml:
  <Application.Resources>
      <vm:ViewModelLocator xmlns:vm="clr-namespace:CrazyHacks"
                           x:Key="Locator" />
  </Application.Resources>
  
  In the View:
  DataContext="{Binding Source={StaticResource Locator}, Path=ViewModelName}"

  You can also use Blend to do all this with the tool's support.
  See http://www.galasoft.ch/mvvm
*/

using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Ioc;
using Microsoft.Practices.ServiceLocation;
using Microsoft.Practices.Unity;

namespace CrazyHacks.ViewModel
{
    /// <summary>
    /// This class contains static references to all the view models in the
    /// application and provides an entry point for the bindings.
    /// </summary>
    public class ViewModelLocator
    {

        private static BootStrapper _bootStrapper;

        static ViewModelLocator()
        {
            if (_bootStrapper == null)
                _bootStrapper = new BootStrapper();
        }
        
        public MainWindowViewModel Main
        {
            get { return _bootStrapper.Container.Resolve<MainWindowViewModel>(); }
        }

        public MainControlViewModel MainControl
        {
            get { return _bootStrapper.Container.Resolve<MainControlViewModel>(); }

        }

        public ChromeControlViewModel ChromeControl
        {
            get { return _bootStrapper.Container.Resolve<ChromeControlViewModel>(); }

        }

        public XssControlViewModel XssControl
        {
            get { return _bootStrapper.Container.Resolve<XssControlViewModel>(); }

        }

        public static void Cleanup()
        {
            // TODO Clear the ViewModels
        }
    }
}