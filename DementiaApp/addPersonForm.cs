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
    public partial class addPersonForm : Form
    {
        private string fileName;

        public addPersonForm()
        {
            InitializeComponent();
            personPicturebox.Image = Properties.Resources.imageDefault;

            personListbox.DisplayMember = "Name";

            foreach(Person person in PersonDB.people)
            {
                personListbox.Items.Add(person);
            }
            fileName = "";
        }

        private void personPicturebox_Click(object sender, EventArgs e)
        {
            // SOURCE CODE: https://www.c-sharpcorner.com/UploadFile/mirfan00/uploaddisplay-image-in-picture-box-using-C-Sharp/
            OpenFileDialog open = new OpenFileDialog();
            open.Filter = "Image Files(*.jpg; *.jpeg; *.gif; *.bmp, *.png)|*.jpg; *.jpeg; *.gif; *.bmp; *.png;";
            if (open.ShowDialog() == DialogResult.OK)
            {
                personPicturebox.Image = new Bitmap(open.FileName);
                fileName = open.FileName;
            }
        }

        private void addPersonButton_Click(object sender, EventArgs e)
        {
            var name = personName.Text;
            if (!String.IsNullOrEmpty(name)) {
                var relation = personRelationship.Text;
                Person person = new Person(name, relation, fileName);
                PersonDB.AddPerson(person);
                personListbox.Items.Add(person);
            }
        }

        private void personListbox_SelectedIndexChanged(object sender, EventArgs e)
        {
            personName.Text = PersonDB.people[personListbox.SelectedIndex].Name;
            personRelationship.Text = PersonDB.people[personListbox.SelectedIndex].Relation;
            var imageUrl = PersonDB.people[personListbox.SelectedIndex].ImageUrl;

            if (!string.IsNullOrEmpty(imageUrl))
            {
                personPicturebox.Image = new Bitmap(imageUrl);
            }
        }
    }
}
