using Caliburn.Micro;

namespace GeoPhotoSlideshow.UI.ViewModels
{
    public class AppViewModel : PropertyChangedBase, IHaveDisplayName
    {
        private string _displayName = "Photo Slideshow";

        public string DisplayName
        {
            get { return _displayName; }
            set { _displayName = value; }
        }
    }
}