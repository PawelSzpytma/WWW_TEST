﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DotVVM.Framework.ViewModel;
using WWW.Api;
using WWW.Controls.Models;

namespace WWW.ViewModels
{
    public class DefaultViewModel : MasterPageViewModel
    {
        public RequestSearch search { get; set; }

        public ModalOne modalOne { get; set; }

        public ModalTwo modalTwo { get; set; }

        public int Refresh { get; set; }
        public string Title { get; set; }

        public List<int> list_two { get; set; }

        public System.Collections.Generic.ICollection<WeatherForecast> list {get;set;}

        public override Task Init()
        {
            modalOne=new ModalOne();
            modalTwo=new ModalTwo();
            search =new RequestSearch();
            list = new List<WeatherForecast>();
            list_two=new List<int>();
            list_two.Add(1);
            list_two.Add(2);
            list_two.Add(3);
            return base.Init();

        }

        public DefaultViewModel()
		{
			Title = "Hello from DotVVM!";
		}

		public void Check(string name)
		{

		}
    }
}
