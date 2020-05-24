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
public partial class GamePage : ContentPage
{
        const int NB_MAGIQUE_MIN = 1;
        const int NB_MAGIQUE_MAX = 10;
        int nombreMagique = 0;

        public GamePage()
    {
        InitializeComponent();
            nombreMagique =new Random().Next(NB_MAGIQUE_MIN, NB_MAGIQUE_MAX);
            minMaxLabel.Text = "entre " + NB_MAGIQUE_MIN + "et " + NB_MAGIQUE_MAX;
            NavigationPage.SetHasNavigationBar(this, false);
        }

        void ButtonCliked(object sender, System.EventArgs e)
        {
            if (String.IsNullOrWhiteSpace(numberEntry.Text))
            {
                DisplayAlert("Attention !", "Vous devez entrer un nombre", "OK");
                return;
            }

            int nombreUtilisateur = 0;
            try
            {
                nombreUtilisateur = Int32.Parse(numberEntry.Text);
            }
            catch (Exception){
                DisplayAlert("Attention !", "Vous devez entrer uniqument des chiffres", "OK");
                return;
            }

            if ((nombreUtilisateur < NB_MAGIQUE_MIN) || (nombreUtilisateur > NB_MAGIQUE_MAX)) {
                DisplayAlert("Attention !", "Vous devez entrer un nombre entre " + NB_MAGIQUE_MIN + " et " + NB_MAGIQUE_MAX, "OK");
                return;
            }

            if (nombreMagique > nombreUtilisateur)
                {
                    DisplayAlert("Oups !", "Le nombre magique est supérieur à " + nombreUtilisateur, "Ok");
                    return;
            }

            if (nombreMagique < nombreUtilisateur)
                {
                    DisplayAlert("Oups !", "Le nombre magique est inférieur à " + nombreUtilisateur, "OK");
                    return;
            }

            if (nombreMagique == nombreUtilisateur)
            {
                WinAction();
                return;

             }
            
        }
        private void WinAction()
        {
            Navigation.PushAsync(new WinPage(nombreMagique));
        }
}
}