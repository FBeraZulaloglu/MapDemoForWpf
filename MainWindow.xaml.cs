using Microsoft.Maps.MapControl.WPF;
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

namespace MapDemoForWpf
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        MapPolyline route;
        Pushpin marker, marker1;
        public MainWindow()
        {
            InitializeComponent();
            myMap.Focus();// + ile yakınlaşı r- ile ise uzaklasır
            
            //aerial mode u true yapmak AerıalWithLabelı etkili hale getirir
            //myMap.Mode = new AerialMode(true);
            route = new MapPolyline();
            route.StrokeThickness = 6;
            route.Opacity = 0.7;
            route.Stroke = new System.Windows.Media.SolidColorBrush(System.Windows.Media.Colors.Red);
            marker = new Pushpin();
            marker1 = new Pushpin();
            
        }

        private void LoadToMap(object sender, RoutedEventArgs e)
        {
            var sateliteLocation = new Location(Convert.ToDouble(Satelite_Lat.Text), Convert.ToDouble(Satelite_Lng.Text));
            var myLocation = new Location(Convert.ToDouble(My_Lat.Text), Convert.ToDouble(My_Lng.Text));
            myMap.Center = sateliteLocation;
            route.Locations = new LocationCollection()
            {
                new Location(sateliteLocation),
                new Location(myLocation)
            };
            myMap.Children.Add(route);
            marker.Location = sateliteLocation;
            marker1.Location = myLocation;

            MapLayer.SetPosition(myMarker, sateliteLocation);
            //myMap.Children.Add(myMarker);
            
        }
    }
}
