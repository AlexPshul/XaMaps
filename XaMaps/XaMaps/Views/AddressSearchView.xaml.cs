using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using XaMaps.Models;
using XaMaps.Services;

namespace XaMaps.Views
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class AddressSearchView : ContentView
	{
	    public AddressSearchView()
		{
			InitializeComponent();
		}
	}
}