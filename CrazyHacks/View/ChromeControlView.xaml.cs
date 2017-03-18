using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using CefSharp.Internals;
using CefSharp;

namespace CrazyHacks.View
{
    /// <summary>
    /// ChromeControlView.xaml에 대한 상호 작용 논리
    /// </summary>
    public partial class ChromeControlView : UserControl
    {
        public ChromeControlView()
        {
            InitializeComponent();
            // Delegate 를 이용해서 handler를 추가하는 것은 어떤가??
        }
        
    }
}
