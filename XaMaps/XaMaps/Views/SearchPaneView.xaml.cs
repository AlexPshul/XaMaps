using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using XaMaps.Services;

namespace XaMaps.Views
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class SearchPaneView : ContentPage
	{
		public SearchPaneView ()
		{
			InitializeComponent ();
		}

	    private void OriginSearch(object sender, EventArgs e)
	    {
	        
        }
	}
}