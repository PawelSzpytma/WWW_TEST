using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using WWW.Api;

namespace WWW.Controls.Models
{
    public class ModalOne
    {
        public RequestSearch search { get; set; }



        public List<string> SelectedCountries { get; set; } = new List<string>();

        public ChildModel childModel { get;  set; }

        public ModalOne()
        {
            search = new RequestSearch();
            childModel=new ChildModel();
            childModel.date = DateTime.Now;
            SelectedCountries.Add("Czech Republic");
        }

        public bool Visible { get; set; }
        public int Refresh { get; set; }
       
    }
}
