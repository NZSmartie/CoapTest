﻿using System.Reactive.Disposables;
using ReactiveUI;
using ReactiveUI.XamForms;
using Xamarin.Forms.Xaml;

using CoapTest.ViewModels;
using System.Reactive.Linq;

namespace CoapTest.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class DevicesListView : ReactiveContentPage<DevicesListViewModel>
    {
        public DevicesListView()
        {
            InitializeComponent();
            this.WhenActivated(disposable =>
            {
                ViewModel.SelectedDevice = null;

                this.OneWayBind(ViewModel, 
                        vm => vm.Devices, 
                        v => v.DeviceListView.ItemsSource)
                    .DisposeWith(disposable);

                // Clear device cache and perform discovery request
                this.BindCommand(ViewModel, 
                        vm => vm.DiscoverDevicesCommand, 
                        v => v.RefreshToolbarIcon,
                        Observable.Return(true))
                    .DisposeWith(disposable);
                
                this.BindCommand(ViewModel,
                        vm => vm.DiscoverDevicesCommand,
                        v => v.DeviceListView,
                        nameof(DeviceListView.Refreshing))
                    .DisposeWith(disposable);

                this.OneWayBind(ViewModel,
                        vm => vm.IsRefreshing,
                        v => v.DeviceListView.IsRefreshing)
                    .DisposeWith(disposable);

                this.Bind(ViewModel, 
                        vm => vm.SelectedDevice, 
                        v => v.DeviceListView.SelectedItem)
                    .DisposeWith(disposable);
            });
        }
    }
}
