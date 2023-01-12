using System.Collections.Generic;
using WWW.Api;

namespace WWW.Controls.Models
{
    public class ModalTwo
    {
        public RequestSearch search { get; set; }
        public ModalTwo() {

            search = new RequestSearch();
            list = new List<WeatherForecast>();
        }

        public bool Visible { get; set; }
        public int Refresh { get; set; }
        public System.Collections.Generic.ICollection<WeatherForecast> list { get; set; }


    }

    
}
