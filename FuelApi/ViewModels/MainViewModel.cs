using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using FuelApi.Models;
using Refit;



namespace CombustiblesAPI.ViewModels
{
    public class MainViewModel : INotifyPropertyChanged
    {
        
        public event PropertyChangedEventHandler PropertyChanged;

        private List<Fuels> Combustibles;

        public ObservableCollection<Fuels> SemanaSeleccionada { get; set; }

        public ObservableCollection<string> SemanaList { get; set; }

        public string FechaSeleccionada { get; set; }

        public string  LabelSemana {get; set;}

        public MainViewModel()
        {

            Combustibles = new List<Fuels>();
            SemanaList = new ObservableCollection<string>();
            SemanaSeleccionada = new ObservableCollection<Fuels>();
            

            GetCombustibles();
          

        }


        public async void GetCombustibles()
        {
            // Get del API con REFIT

            var apiResponse = RestService.For<IFuelsApi>("http://www.apidashboard.somee.com");
            var fuels = await apiResponse.GetFuels();

            Combustibles = fuels;
            Combustibles.Reverse();

            GetListSemanas(); // Llamada de la funcion para crear lista de fechas de reportes (sin duplicados)
            GetUltSemana();

        }




        public void GetListSemanas()
        {
            for (int i = 0; i < Combustibles.Count; i++)
            {
                if (i == 0)
                {
                    SemanaList.Add(Combustibles[i].FECHA_SEMANA.ToString("dd/MM/yyyy"));
                }
                else
                {
                    if (Combustibles[i].FECHA_SEMANA != Combustibles[i - 1].FECHA_SEMANA)
                    {
                        SemanaList.Add(Combustibles[i].FECHA_SEMANA.ToString("dd/MM/yyyy"));
                    }
                }
            }

        }




        public void GetUltSemana()
        {
            var ultSemana = Combustibles[0].FECHA_SEMANA;

            LabelSemana = Combustibles[0].SEMANA_LABEL;

            for (int i = 0; i < Combustibles.Count; i++)
            {
                if (Combustibles[i].FECHA_SEMANA == ultSemana)
                {
                    SemanaSeleccionada.Add(Combustibles[i]);
                }
            }
        }


        public void GetSemanaFiltrada(string args)
        {

            SemanaSeleccionada.Clear();
            
            for (int i = 0; i < Combustibles.Count; i++)
            {
                var stringFecha = Combustibles[i].FECHA_SEMANA.ToString("dd/MM/yyyy");

                if ( stringFecha == args )
                {

                    LabelSemana = Combustibles[i].SEMANA_LABEL;
                    SemanaSeleccionada.Add(Combustibles[i]);
                }

            }


        }



        private void OnFechaSeleccionadaChanged()
        {
            GetSemanaFiltrada(FechaSeleccionada);
        }





    }
}