using System;
using System.Reactive.Linq;
using System.Threading.Tasks;

namespace GeoPhotoSlideshow.Core
{
    public class DataService
    {
        private readonly IDataLoader _dataLoader;

        public DataService(IDataLoader dataLoader)
        {
            _dataLoader = dataLoader;
        }

        public IObservable<Photo> GetDataStream(TimeSpan streamInterval)
        {

            return
                Observable.FromAsync(_dataLoader.LoadPhotos)
                    .SelectMany(s => s)
                    .Zip(Observable.Interval(streamInterval), (p, t) => p);
        }
    }

    public class Photo
    {
        public string Source { get; set; }
        public Location Location { get; set; }
        public string Title { get; set; }
    }

    public class Location
    {
        private readonly int _xOffset;
        private readonly int _yOffset;

        public Location(int xOffset, int yOffset)
        {
            _xOffset = xOffset;
            _yOffset = yOffset;
        }

        public int XOffset
        {
            get { return _xOffset; }
        }

        public int YOffset
        {
            get { return _yOffset; }
        }
    }

    public interface IDataLoader
    {
        Task<Photo[]> LoadPhotos();
    }

    public class StaticDataLoader:IDataLoader
    {
        public Task<Photo[]> LoadPhotos()
        {
            return Task.Factory.StartNew(
                () => new[]
                {
                    new Photo
                    {
                        Title="First Image",
                        Source="http://placekitten.com/200/300",
                        Location = new Location(1,1)
                    },
                    new Photo
                    {
                        Title="Second Image",
                        Source="http://www.placecage.com/200/300",
                        Location = new Location(2,2)
                    },
                    new Photo
                    {
                        Title="Third Image",
                        Source="http://www.fillmurray.com/200/300",
                        Location = new Location(3,3)
                    },
                    new Photo
                    {
                        Title="Fourth Image",
                        Source="http://www.placebear.com/200/300",
                        Location = new Location(4,4)
                    }
                });
        }
    }
}
