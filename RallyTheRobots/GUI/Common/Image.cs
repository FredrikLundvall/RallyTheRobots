using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RallyTheRobots
{
    public class Image
    {
        public readonly string ImageName;
        public ButtonAreaImageTypeEnum ImageType;
        public ButtonAreaImageStackDirectionEnum ImageStackDirection;
        public Image(string imageName, ButtonAreaImageTypeEnum imageType, ButtonAreaImageStackDirectionEnum imageStackDirection)
        {
            ImageName = imageName;
            ImageType = imageType;
            ImageStackDirection = imageStackDirection;
        }
    }
}
