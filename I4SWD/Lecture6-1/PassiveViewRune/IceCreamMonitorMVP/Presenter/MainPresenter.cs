using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using IceCreamMonitorMVP.Model;
using System.Windows.Media;

namespace IceCreamMonitorMVP
{
    public class MainPresenter
    {
        private IceCreamMonitor iceCreamMonitor;
        private IMainWiew view;

        public MainPresenter(IMainWiew view, IceCreamMonitor iceCreamMonitor)
        {
            this.view = view;
            this.iceCreamMonitor = iceCreamMonitor;
            this.iceCreamMonitor.newStationId += iceCreamMonitor_newStationId;
            InitializeView();
        }

        void iceCreamMonitor_newStationId(object sender, EventArgs e)
        {
            view.InitMeasurements(iceCreamMonitor.GetStationIds());
        }

        internal void InitializeView()
        {
            view.SetTarget(iceCreamMonitor.Target.ToString());
            view.InitMeasurements(iceCreamMonitor.GetStationIds());
        }

        // TODO
        // Implement the missing parts of the presenter
    }
}
