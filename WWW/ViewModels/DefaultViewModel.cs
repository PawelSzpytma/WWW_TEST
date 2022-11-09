﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DotVVM.Framework.ViewModel;

namespace WWW.ViewModels
{
    public class DefaultViewModel : MasterPageViewModel
    {
		public string sellectcombo { get; set; } = "Mild";

        public List<string> list { get; set; } = new List<string>() { "Freezing", "Bracing", "Chilly", "Cool", "Mild", "Warm", "Balmy", "Hot", "Sweltering", "Scorching" };
        public string Title { get; set;}

		public DefaultViewModel()
		{
			Title = "Hello from DotVVM!";
		}

		public void Check()
		{

		}
    }
}