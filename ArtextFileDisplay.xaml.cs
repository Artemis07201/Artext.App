namespace Artext
{
    public partial class ArtextFileDisplay : ContentPage
    {
        public ArtextFileDisplay()
        {
            InitializeComponent();
        }

        private void ContentPage_SizeChanged(object Sender, EventArgs E)
        {
            double TX = MainGrid.Width;
            double TY = MainGrid.Height;

            EDIT.WidthRequest = TX;
            EDIT.HeightRequest = TY;
        }

        private void ContentPage_Appearing(object Sender, EventArgs E)
        {
            this.ContentPage_SizeChanged(Sender, E);
        }
    }
}