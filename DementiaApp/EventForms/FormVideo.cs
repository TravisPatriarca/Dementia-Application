using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Assignment1
{
    public partial class FormVideo : Form
    {
        private Coord location;
        private string fileName;
        private bool edit;
        private string eventID;

        public FormVideo()
        {
            InitializeComponent();
            dateTimePicker1.Format = DateTimePickerFormat.Custom;
            dateTimePicker1.CustomFormat = "dd/MM/yyyy hh:mm";
            dateTimePicker1.ShowUpDown = true;
            fileName = null;
        }

        public FormVideo(EventVideo ev) : this()
        {
            videoPlayer.URL = ev.Filepath;
            dateTimePicker1.Value = ev.StartTime;
            edit = true;
            eventID = ev.EventID;
            location = ev.Location;
        }

        public FormVideo(Coord loc) : this()
        {
            location = loc;
        }

        private void saveButton_Click(object sender, EventArgs e)
        {
            if (fileName != null)
            {
                var eventObj = new EventVideo();
                eventObj.Type = eventTypes.video.GetString();
                eventObj.Location = location;
                eventObj.StartTime = dateTimePicker1.Value;
                eventObj.EndTime = dateTimePicker1.Value;
                eventObj.Filepath = fileName;

                if (edit)
                {
                    EventDB.SetEvent(eventObj, eventID);
                }
                else
                {
                    EventDB.AddEvent(eventObj);
                    MapController.AddMarker(location.X, location.Y, eventObj.Icon);
                }

                this.Close();
            }
        }

        private void uploadButton_Click(object sender, EventArgs e)
        {
            // SOURCE CODE: https://www.c-sharpcorner.com/UploadFile/e628d9/playing-audio-and-video-files-using-C-Sharp/
            OpenFileDialog open = new OpenFileDialog(); //open file explorer to select a file
            open.Filter = "(mp3,wav,mp4,mov,wmv,mpg)|*.mp3;*.wav;*.mp4;*.mov;*.wmv;*.mpg|all files|*.*"; //determines which file types will be shown in the file explorer
            if (open.ShowDialog() == DialogResult.OK) //if loading file is successfull
            {
                videoPlayer.URL = open.FileName; //set video player url to file name of opened file
                fileName = open.FileName;
            }
        }

        private void FormVideo_FormClosing(object sender, FormClosedEventArgs e)
        {
            videoPlayer.close();
        }
    }
}
