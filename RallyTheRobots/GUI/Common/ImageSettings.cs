using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RallyTheRobots
{
    public class ImageSettings
    {
        public readonly string ImageName;
        public ButtonAreaImagePositioningEnum ImagePositioning;
        public ButtonAreaImageStackDirectionEnum ImageStackDirection;
        public ButtonAreaImageNameTypeEnum ImageNameType;
        public ImageSettings(string imageName, ButtonAreaImageNameTypeEnum imageNameType, ButtonAreaImagePositioningEnum imagePositioning, ButtonAreaImageStackDirectionEnum imageStackDirection)
        {
            ImageName = imageName;
            ImageNameType = imageNameType;
            ImagePositioning = imagePositioning;
            ImageStackDirection = imageStackDirection;
        }
    }
}
