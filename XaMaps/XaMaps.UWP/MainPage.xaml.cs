using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation;

namespace XaMaps.UWP
{
    public sealed partial class MainPage
    {
        public MainPage()
        {
            this.InitializeComponent();
            Xamarin.FormsMaps.Init("8eUzdEdyBhZyxr6LsQ23~50tcPNvx25H-QXBoIs54qw~AtEnMUILiGzFWgIShd9oDBnx9QgEuNM-aWhLYk6scQ2rbIh3jympAdmbVQswPzsV");
            LoadApplication(new XaMaps.App());
        }
    }
}
