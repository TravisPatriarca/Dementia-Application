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
    public partial class FormPerson : Form
    {
        private Coord location;
        private bool edit;
        private string eventID;

        public FormPerson()
        {
            InitializeComponent();
            personCombobox.DisplayMember = "Name";
            personCombobox.DataSource = PersonDB.GetPeople();
            dateTimePicker1.Format = DateTimePickerFormat.Custom;
            dateTimePicker1.CustomFormat = "dd/MM/yyyy hh:mm";
            dateTimePicker1.ShowUpDown = true;

            dateTimePicker2.Format = DateTimePickerFormat.Custom;
            dateTimePicker2.CustomFormat = "dd/MM/yyyy hh:mm";
            dateTimePicker2.ShowUpDown = true;
            relationLabel.Text = PersonDB.GetPeople()[personCombobox.SelectedIndex].Relation;

            edit = false;
        }

        public FormPerson(EventPerson ev) : this()
        {
            var imageUrl = PersonDB.GetPeople()[personCombobox.SelectedIndex].ImageUrl;
            if (!string.IsNullOrEmpty(imageUrl))
            {
                imageShowcase.Image = new Bitmap(imageUrl);
            }
            dateTimePicker1.Value = ev.StartTime;
            dateTimePicker2.Value = ev.EndTime;
            personCombobox.SelectedItem = ev.person;
            relationLabel.Text = ev.person.Relation;
            detailsTextbox.Text = ev.Details;
            edit = true;
            eventID = ev.EventID;
            location = ev.Location;
        }

        public FormPerson(Coord loc) : this()
        {
            location = loc;
        }

        private void saveButton_Click(object sender, EventArgs e)
        {
            var eventObj = new EventPerson();
            eventObj.Type = eventTypes.person.GetString();
            eventObj.Location = location;
            eventObj.person = personCombobox.SelectedItem as Person;
            eventObj.StartTime = dateTimePicker1.Value;
            eventObj.EndTime = dateTimePicker2.Value;
            eventObj.Details = detailsTextbox.Text;

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

        private void personCombobox_SelectedIndexChanged(object sender, EventArgs e)
        {
            relationLabel.Text = PersonDB.GetPeople()[personCombobox.SelectedIndex].Relation;
            var imageUrl = PersonDB.GetPeople()[personCombobox.SelectedIndex].ImageUrl;
            if (!string.IsNullOrEmpty(imageUrl))
            {
                imageShowcase.Image = new Bitmap(imageUrl);
            }
        }
    }
}
