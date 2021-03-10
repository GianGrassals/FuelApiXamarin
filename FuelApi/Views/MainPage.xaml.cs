using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;
using CombustiblesAPI.ViewModels;
using FuelApi.Models;
using Newtonsoft.Json;
using System.Collections.ObjectModel;
using WebServiceSample;


namespace FuelApi
{
    public partial class MainPage : ContentPage
    {

        
        
        public MainViewModel ViewModel { get; set; }
        public MainPage()
        {
            InitializeComponent();

        

        }


        protected override void OnAppearing()
        {
            base.OnAppearing();
            PriceView.TranslationY = 600;
            PriceView.TranslateTo(0, 0, 1500, Easing.SinInOut);
        }




        public void ImageButton_Clicked(System.Object sender, System.EventArgs e)
        {

            PickerSemana.Focus();


        }

        void PickerSemana_SelectedIndexChanged(System.Object sender, System.EventArgs e)
        {

            PriceView.TranslationY = 600;
            PriceView.TranslateTo(0, 0, 800, Easing.SinInOut);
        }



    }
}
