using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Nombremagique.Views
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
public partial class WinPage : ContentPage
{
        public WinPage(): this(5)
        {
            
        }
    public WinPage(int nbreMagique)
    {
        InitializeComponent();

            mainLayout.Scale = 0.7;
            mainLayout.ScaleTo(1, 1500, Easing.BounceIn);
            magiqueNumberLabel.Text = "Le nombre magique était: " + nbreMagique;
            NavigateBackToWelcomePage();
           
    }

        private async Task NavigateBackToWelcomePage()
        {
            await Task.Delay(3000);
            await Navigation.PopToRootAsync();
        }
}
}