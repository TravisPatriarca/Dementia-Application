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
    public partial class eventForm : Form
    {
        private Coord location;

        public eventForm(Coord loc)
        {
            InitializeComponent();
            location = loc;
        }

        private void facebookPicturebox_Click(object sender, EventArgs e)
        {
            FormFacebookpost ev = new FormFacebookpost(location);
            ev.ShowDialog();            
        }

        private void twitterPicturebox_Click(object sender, EventArgs e)
        {
            FormTweet ev = new FormTweet(location);
            ev.ShowDialog();
        }

        private void imagePicturebox_Click(object sender, EventArgs e)
        {
            FormImage ev = new FormImage(location);
            ev.ShowDialog();
        }

        private void videoPicturebox_Click(object sender, EventArgs e)
        {
            FormVideo ev = new FormVideo(location);
            ev.ShowDialog();
        }

        private void personPicturebox_Click(object sender, EventArgs e)
        {
            FormPerson ev = new FormPerson(location);
            ev.ShowDialog();
        }
    }
}
