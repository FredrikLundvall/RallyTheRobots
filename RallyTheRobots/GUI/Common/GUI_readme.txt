The GUI is centered around screens that contains multiple ButtonAreas. ButtonAreas run ButtonActions when triggered. The screens 
are placed in the ScreenManager class. 
The ScreenManager class ist the class used to display the gui in the game. It is initialized with the ContentManager object, the 
ResolutionFactory object and the InputChecker object. In the LoadContent calls to ContentManagers LoadContent should be added and 
the ScreenManagers EnterStartScreen should be called. In the Update calls to ScreenManagers Update should be added and a check 
for gameStatus.RunningStatus should be checked to see if the game should shutdown. In the Draw a call to ScreenManagers Draw 
should be added.  
ContentManager holds the list of imagenames and maps them to the actual bitmap data.
ImageSettings specifies how the image is used (if it´s a slider, if it´s horizontal or vertical, if the name maps to a image or 
the characters are separate images or the rollingstates are separate images or the rollingstates characters are separate images 
or the rollingstate2s are separate images or the rollingstate2s characters are separate images).
InputChecker handles the inputs by different means (keyboard, mouse, gamepads) and is mainly used in ButtonAreas and Screens.
RollingState is a list of strings that can be used to keep a state of o ButtonArea. It can be mapped to an image to change the 
image presented by the ButtonArea.
ResolutionFactory is a factory class that creates the virtual resolution (from ResolutionBuddy) that is used in the game.

Screen
The Screen class is ment to be the inherited from to create your own specialised class of screen for every gui-screen you need.
The screen can contain a Background-image that is defined by a name (a filename without the .png) and multiple ButtonAreas.
If more ButtonAreas are needed in a screen than can fit in the display the screen can setup to be scrollable. The ButtonAreas 
are then scrolled as a list in the Screen.
The Screen is placed in the ScreenManager class 
The screen class has some events:
ScreenChangeOnAnyKey - Set screen to change to when any keys is pressed 
ScreenChangeOnTimeout - Set screen to change to when the timeout occurs
EnterScreen - Method is called when the screen is presented (should call the base method)
LeaveScreen - Method is called when the screen is exited (should call the base method)
Update - Method is called in the update stage (should call the base method)
Draw - Method is called in the draw stage (should call the base method)

ButtonArea
ButtonArea is a image placed in the Screen. A ButtonAreaStateImageEnum can be translated from the buttonArea and the ButtonAreaList 
that specifies what image will be used for the ButtonArea. It can be the following different values: Hidden, Disabled, Idle, Focused 
and Selected. The states translates to the following suffixes of the image name: _disabled, _idle, _focused, _selected (Hidden just 
isn't displayed and has no image name suffix). The ButtonArea actually only really owns the properties Hidden or Disabled. The 
property ButtonStatusEnum (Idle, Focused, Selected) are controlled by the ButtonAreaList. The Focused and Selected only has any 
meaning in perspective of the ButtonAreaList. The ButtonAreaList is where the Screen saves all the ButtonAreas for the screen.
The ButtonArea has two RollingStates that can be used to keep track of the state of the button. It is a rolling list of strings that 
can be switched forward and backwards with NextRollingStateButtonAction and PreviousRollingStateButtonAction. The RollingState can be 
used as the name of the image of the ButtonArea. ButtonAreas can be sliders that is used to represent a value of for example a volume.
ButtonAreas can have a stack of images that builds the graphics of the button. A slider will probably have at least three images. A 
text for the sliders function a slider-bar for the representation of the value and a box where the slider will slide inside. The 
sliders don´t need any ButtonAction it is automaticly triggered. 
The ButtonArea has different events:
ButtonSelectAction
ButtonAlternateSelectAction
It also has Shortcuts, which means the buttons will trigger the SelectAction:
HasShortcutWithGoBackButton
HasShortcutWithMouseWheelUp
HasShortcutWithMouseWheelDown




