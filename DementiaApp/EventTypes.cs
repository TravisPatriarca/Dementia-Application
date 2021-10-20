using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assignment1
{
    public enum eventTypes
    {
        tweet,
        facebook_post,
        image,
        video,
        tracklog,
        person
    }

    static class EventTypes
    {
        public static string GetString(this eventTypes eventType)
        {
            switch (eventType)
            {
                case eventTypes.tweet:
                    return "tweet";

                case eventTypes.facebook_post:
                    return "facebook_post";

                case eventTypes.image:
                    return "image";

                case eventTypes.video:
                    return "video";

                case eventTypes.tracklog:
                    return "tracklog";

                case eventTypes.person:
                    return "person";

                default:
                    return null;
            }
        }
    }
}
