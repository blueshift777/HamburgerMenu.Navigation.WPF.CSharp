using Caliburn.Micro;
using System;
using System.Collections.Generic;
using System.Runtime.Versioning;

namespace DesktopApp
{
    [SupportedOSPlatform("windows")]
    internal class AppInitializer : BootstrapperBase
    {
        private readonly SimpleContainer m_oSimpleIOCContainer
            = new SimpleContainer();

        public AppInitializer()
        {
            Initialize();
        }


        /// <summary>
        /// Displays the main view of the application
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected override void OnStartup(object sender, System.Windows.StartupEventArgs e)
        {
            DisplayRootViewForAsync<InitialViewModel>();
        }

        //See http://caliburnmicro.codeplex.com/wikipage?title=The%20Simple%20IoC%20Container&referringTitle=Documentation
        // "Creation and Configuration section"
        protected override void Configure()
        {
            base.Configure();

            m_oSimpleIOCContainer.Singleton<IEventAggregator, EventAggregator>();
            m_oSimpleIOCContainer.Singleton<IWindowManager, WindowManager>();
            m_oSimpleIOCContainer.Singleton<InitialViewModel>();
        }

        protected override object GetInstance(Type tService, string strKey)
        {
            return m_oSimpleIOCContainer.GetInstance(tService, strKey);
        }

        protected override IEnumerable<object> GetAllInstances(Type tServiceType)
        {
            return m_oSimpleIOCContainer.GetAllInstances(tServiceType);
        }

        protected override void BuildUp(object oInstance)
        {
            m_oSimpleIOCContainer.BuildUp(oInstance);
        }


    }
}
