namespace RallyTheRobots.GUI.Common
{
    public class ImageSettings
    {
        public readonly string ImageName;
        public ButtonAreaImagePositioningEnum ImagePositioning;
        public ButtonAreaImageStackDirectionEnum ImageStackDirection;
        public ButtonAreaImageNameTypeEnum ImageNameType;
        public string ImageNamePrefix;
        public ImageSettings(string imageName, ButtonAreaImageNameTypeEnum imageNameType, ButtonAreaImagePositioningEnum imagePositioning, ButtonAreaImageStackDirectionEnum imageStackDirection, string imageNamePrefix)
        {
            ImageName = imageName;
            ImageNameType = imageNameType;
            ImagePositioning = imagePositioning;
            ImageStackDirection = imageStackDirection;
            ImageNamePrefix = imageNamePrefix;
        }
    }
}
