using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using GMap.NET;
using GMap.NET.MapProviders;
using GMap.NET.WindowsForms;
using GMap.NET.WindowsForms.Markers;
using GMap.NET.WindowsForms.ToolTips;

namespace Assignment1
{
    public struct Coord
    {
        public Coord(double x, double y)
        {
            X = x;
            Y = y;
        }

        public double X { get; }
        public double Y { get; }
    }

    public partial class mainForm : Form
    {
        public Coord clickLocation;
        public EventDB eventDatabase;
        public PersonDB personDatabase;
        public MapController mapControl;
        public mainForm()
        {
            InitializeComponent();

            addPersonButton.TabStop = false;
            addPersonButton.FlatAppearance.BorderSize = 0;   

            clickLocation = new Coord(0, 0);

            //load person xml data
            personDatabase = PersonDB.Instance;
            personDatabase.LoadXml(@"data/contacts.xml");

            //load events xml data
            eventDatabase = EventDB.Instance;
            eventDatabase.LoadXml(@"data/lifelog-events.xml");

            mainMap.MapProvider = GMapProviders.GoogleMap;
            mainMap.Position = new PointLatLng(-31.94686104638828, 116.94113056856052); //map starts at perth
            mainMap.ShowCenter = false;

            //mainmap event handlers
            mainMap.OnMarkerClick += new MarkerClick(mainMap_OnMarkerClick);
            mainMap.MouseClick += new MouseEventHandler(mainMap_Click);
            mainMap.MouseMove += new MouseEventHandler(mainMap_MouseMove);

            mapControl = new MapController(mainMap);
            CreateMapOverlayItems();
        }

        private void CreateMapOverlayItems()
        {
            foreach (Event eventItem in EventDB.eventDictionary.Values)
            {
                if (eventItem.AddMarker)
                {
                    MapController.AddMarker(eventItem.Location.X, eventItem.Location.Y, eventItem.Icon);
                }

                if (eventItem.AddRoute)
                {
                    var trackLogItem = eventItem as EventTracklog;
                    var routeList = MapController.GPXtoPointList(trackLogItem.Filepath);
                    MapController.AddRoute(routeList);
                }
            }
        }

        private void mainMap_OnMarkerClick(GMapMarker item, MouseEventArgs e)
        {
            double x = item.Position.Lng;
            double y = item.Position.Lat;
            var eventItem = eventDatabase.GetEventFromPoint(x, y);

            if (eventItem != null)
            {
                FormFactory.OpenForm(eventItem.Type, eventItem);
            }
        }

        private void formPopup_Click(object sender, ToolStripItemClickedEventArgs e)
        {
            eventForm events = new eventForm(clickLocation);
            events.ShowDialog();
        }

        private void mainMap_Click(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                var formPopup = new ContextMenuStrip();
                formPopup.Items.Add("Add Event");
                formPopup.Show(this, new Point(e.X, e.Y));
                formPopup.ItemClicked += new ToolStripItemClickedEventHandler(this.formPopup_Click);
                clickLocation = new Coord(mainMap.FromLocalToLatLng(e.X, e.Y).Lng, mainMap.FromLocalToLatLng(e.X, e.Y).Lat);
            }
        }

        private void mainMap_MouseMove(object sender, MouseEventArgs e)
        {
            CoordLabel.Text = $"{Math.Round(mainMap.FromLocalToLatLng(e.X, e.Y).Lat, 2)}, {Math.Round(mainMap.FromLocalToLatLng(e.X, e.Y).Lng, 2)}";
        }

        private void addPersonButton_Click(object sender, EventArgs e)
        {
            addPersonForm personForm = new addPersonForm();
            personForm.ShowDialog();
        }

        private void mainForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            personDatabase.SaveXml(@"data/contacts.xml");
            eventDatabase.SaveXml(@"data/lifelog-events.xml");
        }
    }
}