using System;
namespace FuelApi.Models
{
    public class Fuels
    {

        public int ID { get; set; }

        public double CODIGO_DATE { get; set; }

        public string COMBUSTIBLE { get; set; }

        public double PRECIO { get; set; }

        public DateTime FECHA_SEMANA { get; set; }

        public string SEMANA_LABEL { get; set; }

        public DateTime FECHA_REGISTRO { get; set; }

        public string CODIGO_GUID { get; set; }


    }
}
