# MediaElementIOSBug

## Media Element weird behavior

Examples:
- Media Element on IOS does not fire unless you check to see if the time you want to seek to is more than mediaElement.Position. Also will not fire unless
you use mediaElement.StateChanged. 
- If you try to use mediaElement.MediaOpened it will not fire under any condtions in IOS.

##Program has notes in it explaining what lines do what and why they are there.
