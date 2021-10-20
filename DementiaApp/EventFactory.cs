using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace Assignment1
{
    //DESIGN PATTERN: Factory
    static class EventFactory
    {
        public static Event GetEvent(XNamespace ns, XElement element)
        {
            string eventType = element.Attribute("type").Value; //Add exception here
            var eventObj = GetEventObj(eventType);
            if (eventObj != null)
            {
                eventObj.LoadXElement(ns, element);
            }

            return eventObj;
        }

        public static Event GetEvent(string eventType)
        {
            return GetEventObj(eventType);
        }

        private static Event GetEventObj(string eventType)
        {
            System.Diagnostics.Debug.WriteLine(eventType);
            switch (eventType)
            {
                case "tweet":
                    var tweetObj = new EventTweet();
                    tweetObj.Type = eventTypes.tweet.GetString();
                    return tweetObj;

                case "facebook_post":
                    var facebookObj = new EventFacebookpost();
                    facebookObj.Type = eventTypes.facebook_post.GetString();
                    return facebookObj;

                case "image":
                    var imageObj = new EventImage();
                    imageObj.Type = eventTypes.image.GetString();
                    return imageObj;

                case "video":
                    var videoObj = new EventVideo();
                    videoObj.Type = eventTypes.video.GetString();
                    return videoObj;

                case "tracklog":
                    var tracklogObj = new EventTracklog();
                    tracklogObj.Type = eventTypes.tracklog.GetString();
                    tracklogObj.AddMarker = false;
                    tracklogObj.AddRoute = true;
                    return tracklogObj;

                case "person":
                    var personObj = new EventPerson();
                    personObj.Type = eventTypes.person.GetString();
                    return personObj;

                default:
                    return null;
            }
        }
    }
}
