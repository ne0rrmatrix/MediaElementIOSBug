using CommunityToolkit.Maui.Core.Primitives;
using System;

namespace MediaElementIOSBug.Views;

public partial class SeekPage : ContentPage
{
	public SeekPage(SeekViewModel viewModel)
	{
		InitializeComponent();
		BindingContext = viewModel;
        mediaElement.MediaOpened += DoesNotWorkInIOS; // This works in windows and android. Does not work for IOS.
       // mediaElement.StateChanged += IOS; // Work around for ios.
    
	}
    public void DoesNotWorkInIOS(object sender, EventArgs e)
    {
        Debug.WriteLine("Media Opened");
        mediaElement?.SeekTo(TimeSpan.FromSeconds(200)); //Never seeks in iOS when you use media opened. 
        Debug.WriteLine("Seeking 200 seconds");
        mediaElement.MediaOpened -= DoesNotWorkInIOS; 
    }
    public void IOS(object sender, EventArgs e)
    {
#if IOS
        Debug.WriteLine("Media opening IOS");
        if (mediaElement.Position < TimeSpan.FromSeconds(200)) // seek does not fire without this line.
        {
            mediaElement?.SeekTo(TimeSpan.FromSeconds(200));
        }
#endif
    }
    private void ContentPage_Unloaded(object sender, EventArgs e)
    {
        System.Diagnostics.Debug.WriteLine("Unloading media element");
        // Stop and cleanup MediaElement when we navigate away

        mediaElement.StateChanged -= IOS;
        mediaElement.Handler?.DisconnectHandler();
    }
}
