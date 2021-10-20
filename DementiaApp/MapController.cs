using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GMap.NET.MapProviders;
/*
 * Class is used to control map functionality mainly marker and route overalys.
 */

using GMap.NET.WindowsForms;
using GMap.NET.WindowsForms.Markers;
using GMap.NET;
using GMap.NET.WindowsForms.ToolTips;
using System.Drawing;
using System.Xml.Linq;

namespace Assignment1
{
    public class MapController
    {
        public static GMapControl map;
        private static GMapOverlay markers;
        private static GMapOverlay routes;

        public MapController(GMapControl mainMap)
        {
            map = mainMap;

            routes = new GMapOverlay("routes"); //create route overlay
            markers = new GMapOverlay("markers"); //create marker overlay

            map.Overlays.Add(routes); //add routes to map overlays
            map.Overlays.Add(markers); //add markers to map overlays
        }

        //Add marker to map location
        public static void AddMarker(double x, double y, Bitmap icon)
        {
            GMarkerGoogle marker = new GMarkerGoogle(new PointLatLng(y, x), icon);
            markers.Markers.Add(marker);
        }

        //Add route to map through point list
        public static void AddRoute(List<PointLatLng> pointList)
        {
            GMapRoute route = new GMapRoute(pointList, "My Route");
            routes.Routes.Add(route);
        }

        //Retrieve point list from gpx file
        public static List<PointLatLng> GPXtoPointList(string gpxFilePath)
        {
            XDocument xmlDocument = XDocument.Load(AppDomain.CurrentDomain.BaseDirectory + gpxFilePath);
            XNamespace ns = xmlDocument.Root.GetDefaultNamespace();
            
            List<PointLatLng> pointList = XDocument.Load(AppDomain.CurrentDomain.BaseDirectory + gpxFilePath).Descendants(ns + "trkpt")
                .Select(x => new PointLatLng
                {
                    Lat = Convert.ToDouble(x.Attribute("lat").Value),
                    Lng = Convert.ToDouble(x.Attribute("lon").Value)
                }).ToList();

            return pointList;
        }
    }
}
