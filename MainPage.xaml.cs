using Artext.Structures.FileExtension;
#if WINDOWS
using Artext.Platforms.Windows.Pickers;
#endif

namespace Artext
{
    public partial class MainPage : ContentPage
    {
        public MainPage()
        {
            InitializeComponent();
        }

        public static uint AnimationTimeMS => 250;

        private async void OnCreateClickedAsync(object Sender, EventArgs Events)
        {
            string? FolderPath = null;
#if WINDOWS
            FolderPicker P = new();
            FolderPath = await P.PickFolder();
#endif
            if(FolderPath != null && Directory.Exists(FolderPath))
            {
                ArtextFile NewFile = new(Path.Combine(FolderPath, "untitled.artext"));
                NewFile.WriteString("abcdefg");
                await this.DisplayFile(NewFile);
            }
        }

        private async Task DisplayFile(ArtextFile FileToDisplay)
        {
            ArtextFileDisplay Display = new();
            await Navigation.PushAsync(Display);
        }
    }
}