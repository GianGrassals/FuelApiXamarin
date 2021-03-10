
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using FuelApi.Models;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using WebServiceSample;
using Xamarin.Forms;


namespace CombustiblesAPI.ViewModels
{
    public class MainViewModel : INotifyPropertyChanged
    {
        
        public event PropertyChangedEventHandler PropertyChanged;

        private List<Fuels> Combustibles;

        public List<Fuels> combustibles
        {
            get { return Combustibles; }
            set
            {

                if (Combustibles != value)
                {
                    Combustibles = value;

                    PropertyChanged?.Invoke(this, new PropertyChangedEventArgs("combustibles"));
                }
                
            }

        }


        private ObservableCollection<Fuels> SemanaSeleccionada;

        public ObservableCollection<Fuels> semana_seleccionada
        {
            get { return SemanaSeleccionada; }
            set
            {
                if (SemanaSeleccionada != value)
                {
                    SemanaSeleccionada = value;

                   

                    PropertyChanged?.Invoke(this, new PropertyChangedEventArgs("semana_seleccionada"));
                }


            }

        }

        public ObservableCollection<string> SemanaList { get; set; }

        public ObservableCollection<string> semanalist
        {
            get { return SemanaList; }
            set
            {
                SemanaList = value;

                
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs("semanalist"));
                
            }

        }



        public string FechaSeleccionada { get; set; }

        public string fechaseleccionada
        {
            get { return FechaSeleccionada; }
            set
            {
                FechaSeleccionada = value;
                GetSemanaFiltrada(fechaseleccionada);
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs("fechaseleccionada"));

            }
        }

        public string  LabelSemana {get; set;}

        public string labelsemana
        {
            get { return LabelSemana; }
            set
            {
                LabelSemana = value;
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs("labelsemana"));

            }
        }


        public MainViewModel()
        {

            combustibles = new List<Fuels>();
            semanalist = new ObservableCollection<string>();
            SemanaSeleccionada = new ObservableCollection<Fuels>();
            

            GetCombustibles();
          

        }


        public async void GetCombustibles()
        {
            // Get del API
            
            WSClient client = new WSClient();
            var result = await client.Get<Fuels>("http://www.apidashboard.somee.com/api/fuels");
            combustibles = result;
            combustibles.Reverse();

            GetListSemanas(); // Llamada de la funcion para crear lista de fechas de reportes (sin duplicados)
            GetUltSemana();
            //GetSemanaFiltrada("2/20/2021 12:00:00 AM");
        }


        public void GetListSemanas()
        {
            for (int i = 0; i < combustibles.Count; i++)
            {

                if (i == 0)
                {
                    semanalist.Add(combustibles[i].FECHA_SEMANA.ToString("dd/MM/yyyy"));



                }
                else
                {
                    if (combustibles[i].FECHA_SEMANA != combustibles[i - 1].FECHA_SEMANA)
                    {
                        semanalist.Add(combustibles[i].FECHA_SEMANA.ToString("dd/MM/yyyy"));
                    }
                }
            }


            

            

        }



        public void GetUltSemana()
        {
            var ultSemana = combustibles[0].FECHA_SEMANA;

            labelsemana = combustibles[0].SEMANA_LABEL;

            for (int i = 0; i < combustibles.Count; i++)
            {
                if (combustibles[i].FECHA_SEMANA == ultSemana)
                {
                    semana_seleccionada.Add(combustibles[i]);
                }

            }
           

        }


        public void GetSemanaFiltrada(string args)
        {

            semana_seleccionada.Clear();
            
            for (int i = 0; i < combustibles.Count; i++)
            {
                var stringFecha = combustibles[i].FECHA_SEMANA.ToString("dd/MM/yyyy");

                if ( stringFecha == args )
                {

                    labelsemana = combustibles[i].SEMANA_LABEL;
                    semana_seleccionada.Add(combustibles[i]);
                }

            }


        }





    }
}