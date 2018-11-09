using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using XF.MVVMBasic.Model;
using XF.MVVMBasic.ViewModel;

[assembly: XamlCompilation (XamlCompilationOptions.Compile)]
namespace XF.MVVMBasic
{
	public partial class App : Application
	{
        public static AlunoViewModel AlunoVM { get; set; }
        public App ()
		{
			InitializeComponent();
            InitializeVMs();

            MainPage = new NavigationPage(new View.AlunoView() { BindingContext = App.AlunoVM });
        }

        private void InitializeVMs()
        {
            if (AlunoVM == null) AlunoVM = new AlunoViewModel();
        }

        protected override void OnStart ()
		{
			// Handle when your app starts
		}

		protected override void OnSleep ()
		{
			// Handle when your app sleeps
		}

		protected override void OnResume ()
		{
			// Handle when your app resumes
		}
	}
}
