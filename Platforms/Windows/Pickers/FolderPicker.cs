using Artext.Structures.FileExtension.Pickers;
using Windows.Storage.Pickers;
using WindowsFolderPicker = Windows.Storage.Pickers.FolderPicker;

namespace Artext.Platforms.Windows.Pickers
{
    public class FolderPicker : IFolderPicker
    {
        public async Task<string?> PickFolder()
        {
            WindowsFolderPicker FolderPicker = new();
            // Might be needed to make it work on Windows 10
            FolderPicker.FileTypeFilter.Add("*");

            // Get the current window's HWND by passing in the Window object
            IntPtr? Hwnd = (Application.Current?.Windows[0].Handler?.PlatformView as MauiWinUIWindow)?.WindowHandle;

            // Associate the HWND with the file picker
            if(Hwnd.HasValue)
            {
                WinRT.Interop.InitializeWithWindow.Initialize(FolderPicker, Hwnd.Value);

                global::Windows.Storage.StorageFolder Result = await FolderPicker.PickSingleFolderAsync();

                return Result?.Path;
            }
            return null;
        }
    }
}