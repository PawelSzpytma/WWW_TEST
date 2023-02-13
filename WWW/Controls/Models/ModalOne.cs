using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using WWW.Api;

namespace WWW.Controls.Models
{
    public class ModalOne
    {
        public RequestSearch search { get; set; }

     public ChildModel childModel { get;  set; }

        public ModalOne()
        {
            search = new RequestSearch();
            list = new List<WeatherForecast>();
            childModel=new ChildModel();
            childModel.date = DateTime.Now;
        }

        public bool Visible { get; set; }
        public int Refresh { get; set; }
        public System.Collections.Generic.ICollection<WeatherForecast> list { get; set; }

        public void Save()
        {

        }
    }
}
