using System;
using System.Collections.Generic;
using System.Windows;
using Caliburn.Micro;
using GeoPhotoSlideshow.UI.ViewModels;
using GeoPhotoSlideshow.UI.Views;

namespace GeoPhotoSlideshow.UI
{
    public class Bootstrapper: BootstrapperBase
    {
        private SimpleContainer _container;

    public Bootstrapper()
    {
      Initialize();
    }

        protected override void Configure()
        {
            _container = new SimpleContainer();
            _container.Singleton<IWindowManager, AppWindowManager>();
            _container.PerRequest<AppView>();
            _container.PerRequest<AppViewModel>();
        }

        protected override object GetInstance(Type serviceType, string key)
    {
        return _container.GetInstance(serviceType, key);
    }

    protected override IEnumerable<object> GetAllInstances(Type serviceType)
    {
        return _container.GetAllInstances(serviceType);
    }

    protected override void BuildUp(object instance)
    {
        _container.BuildUp(instance);
    }

    protected override void OnStartup(object sender, StartupEventArgs e)
    {
      DisplayRootViewFor<AppViewModel>();
    }
  }
}
