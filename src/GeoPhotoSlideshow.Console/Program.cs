using System;
using System.Reactive.Linq;
using System.Threading;
using System.Threading.Tasks;
using GeoPhotoSlideshow.Core;

namespace GeoPhotoSlideshow.Console
{
    public class Program
    {
        static void Main(string[] args)
        {
            System.Console.WriteLine("Reading Data");

            var dataservice = new DataService(new StaticDataLoader());

            var dataLoadObservable = dataservice.GetDataStream(TimeSpan.FromSeconds(2));

            ConsoleKey key = ConsoleKey.Home;
            while (key != ConsoleKey.Escape)
            {
                CancellationTokenSource tokenSource = new CancellationTokenSource();

                dataLoadObservable.Subscribe(PrintPhoto, HandleError, HandleCompleted, tokenSource.Token);
                
                key = System.Console.ReadKey().Key;
                
                tokenSource.Cancel();
            }
            
            System.Console.WriteLine("Press any key");

            System.Console.ReadKey();
        }

        private static void HandleCompleted()
        {
            System.Console.WriteLine("Press Esc to exit");
        }

        private static void HandleError(Exception obj)
        {
            System.Console.WriteLine("Cancelled");
        }

        private static void PrintPhoto(Photo photo)
        {
            System.Console.WriteLine("Photo {0}({1}) at {2}", photo.Title, photo.Source, photo.Location);
        }
    }
}
