using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assignment1
{
    //DESIGN PATTERN: Factory
    static class FormFactory
    {
        public static void OpenForm(string eventType, Event eventItem)
        {
            switch (eventType)
            {
                case "tweet":
                    new FormTweet(eventItem as EventTweet).ShowDialog();
                    break;

                case "facebook_post":
                    new FormFacebookpost(eventItem as EventFacebookpost).ShowDialog();
                    break;

                case "image":
                    new FormImage(eventItem as EventImage).ShowDialog();
                    break;

                case "video":
                    new FormVideo(eventItem as EventVideo).ShowDialog();
                    break;

                case "person":
                    new FormPerson(eventItem as EventPerson).ShowDialog();
                    break;
            }
        }
    }
}
