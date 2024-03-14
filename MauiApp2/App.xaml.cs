namespace MauiApp2
{
    public partial class App : Application
    {
        public App()
        {
            InitializeComponent();

            MainPage = new MainPage();
        }

        protected override Window CreateWindow(IActivationState activationState)
        {
            var window = base.CreateWindow(activationState);

            const int newWidth = 1200;
            const int newHeight = 800;

            window.Width = newWidth;
            window.Height = newHeight;

            return window;
        }
    }
}
