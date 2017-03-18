using CrazyHacks.Command;
using CrazyHacks.Message;
using CrazyHacks.Model;
using CrazyHacks.Util;
using Fiddler;
using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.CommandWpf;
using GalaSoft.MvvmLight.Messaging;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace CrazyHacks.ViewModel
{
    public class MainWindowViewModel : ViewModelBase
    {
        private string _FilterDomain;
        public string FilterDomain { get {
                return _FilterDomain;
            } set {
                _FilterDomain = value;
                RaisePropertyChanged("");
                RaisePropertyChanged("IsFilterDomainEnabeld");
            }
        }

        public bool IsFilterDomainEnabeld
        {
            get { return FiddlerHelper.CanStartCapture(); }
        }

        public RelayCommand StartCaptureCommand { get; private set; }
        public RelayCommand StopCaptureCommand { get; private set; }
        public RelayCommand InstallCertCommand { get; private set; }
        public RelayCommand UninstallCertCommand { get; private set; }
        public RelayCommand ClearCache { get; private set; }
        public RelayCommand FilterDomainUpdate { get; private set; }
        // ClearCache

        public MainWindowViewModel()
        {
            StartCaptureCommand = new RelayCommand(StartCapture, FiddlerHelper.CanStartCapture);
            StopCaptureCommand = new RelayCommand(StopCapture, FiddlerHelper.CanStopCapture);
            InstallCertCommand = new RelayCommand(InstallCert, FiddlerHelper.CanInstallCert);
            UninstallCertCommand = new RelayCommand(UninstallCert, FiddlerHelper.CanUninstallCert);
            ClearCache = new RelayCommand(ClearFiddlerCache);
            FilterDomainUpdate = new RelayCommand(ClearFiddlerCache);
        }

        private void ClearFiddlerCache()
        {
            Messenger.Default.Send(new FiddlerStateMessage
            {
                Execute = false,
                RegsiterCert = false,
                Stop = false,
                UnRegisterCert = false,
                ClearCache = true,
                FilterDomain = FilterDomain
            });

        }

        private void StartCapture() {
            Messenger.Default.Send(new FiddlerStateMessage {
                Execute = true,
                RegsiterCert = false,
                Stop = false,
                UnRegisterCert = false,
                ClearCache = false,
                FilterDomain = FilterDomain
            });
            RaisePropertyChanged("IsFilterDomainEnabeld");
        }


        private void StopCapture()
        {
            Messenger.Default.Send(new FiddlerStateMessage
            {
                Execute = false,
                RegsiterCert = false,
                Stop = true,
                UnRegisterCert = false,
                ClearCache = false,
                FilterDomain = FilterDomain
            });
            RaisePropertyChanged("IsFilterDomainEnabeld");
        }

        private void InstallCert()
        {
            Messenger.Default.Send(new FiddlerStateMessage
            {
                Execute = false,
                RegsiterCert = true,
                Stop = false,
                UnRegisterCert = false,
                ClearCache = false,
                FilterDomain = FilterDomain
            });
        }

        private void UninstallCert()
        {
            Messenger.Default.Send(new FiddlerStateMessage
            {
                Execute = false,
                RegsiterCert = false,
                Stop = false,
                UnRegisterCert = true,
                ClearCache = false,
                FilterDomain = FilterDomain
            });
        }
    }
}
