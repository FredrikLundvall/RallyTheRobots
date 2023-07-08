using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RallyTheRobots.GUI.Common
{
    public class ImageSettings
    {
        public readonly string ImageName;
        public ButtonAreaImagePositioningEnum ImagePositioning;
        public ButtonAreaImageStackDirectionEnum ImageStackDirection;
        public ButtonAreaImageNameTypeEnum ImageNameType;
        public string ImageCharacterNameSuffix;
        public ImageSettings(string imageName, ButtonAreaImageNameTypeEnum imageNameType, ButtonAreaImagePositioningEnum imagePositioning, ButtonAreaImageStackDirectionEnum imageStackDirection, string imageCharacterNameSuffix)
        {
            ImageName = imageName;
            ImageNameType = imageNameType;
            ImagePositioning = imagePositioning;
            ImageStackDirection = imageStackDirection;
            ImageCharacterNameSuffix = imageCharacterNameSuffix;
        }
    }
}
