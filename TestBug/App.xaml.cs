using TestZone.Test.Views;

namespace TestBug
{
    public partial class App : Application
    {
        public App()
        {
            InitializeComponent();

            //            MainPage = new TestPage();
//            MainPage = new ScrollTestView();
            MainPage = new ScrollTestViewWithoutCarousel();
        }
    }
}
