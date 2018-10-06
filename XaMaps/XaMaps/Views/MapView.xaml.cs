using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace XaMaps.Views
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class MapView : ContentPage
	{
		public MapView ()
		{
			InitializeComponent ();
		}
	}
}