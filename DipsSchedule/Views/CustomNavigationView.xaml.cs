using System;
using System.Collections.Generic;

using Xamarin.Forms;

namespace DipsSchedule.Views
{
    public partial class CustomNavigationView : NavigationPage
    {
        public CustomNavigationView() : base()
        {
            InitializeComponent();
        }

        public CustomNavigationView(Page root) : base(root)
        {
            InitializeComponent();

            this.BarTextColor = Color.White;
            this.BarBackgroundColor = Color.FromHex("147e88");
        }
    }
}
