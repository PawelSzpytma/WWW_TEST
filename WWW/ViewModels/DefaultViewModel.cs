using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DotVVM.Framework.ViewModel;

namespace WWW.ViewModels
{
    public class DefaultViewModel : MasterPageViewModel
    {
        public RequestSearch search { get; set; }

		public int Refresh { get; set; }
        public string Title { get; set;}

        public override Task Init()
        {
            search=new RequestSearch();
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
