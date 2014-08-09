using Caliburn.Metro.Core;
using MahApps.Metro.Controls;

namespace GeoPhotoSlideshow.UI
{
    public class AppWindowManager : MetroWindowManager
    {
        public override MetroWindow CreateCustomWindow(object view, bool windowIsView)
        {
            if (windowIsView)
            {
                return view as MainWindow;
            }

            return new MainWindow
            {
                Content = view
            };
        }
    }
}