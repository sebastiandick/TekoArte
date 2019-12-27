

namespace appTekoArte.ViewModels
{
    using appTekoArte.Models;
    using appTekoArte.Services;
    using System;
    using System.Collections.Generic;
    using System.Collections.ObjectModel;
    using Xamarin.Forms;

    public class TekoArteViewModel : BaseViewModel
    {
        #region Attributes
        private ApiService apiService;
        private ObservableCollection<TekoArte> tekoArtes;
        #endregion

        #region Properties
        public ObservableCollection<TekoArte> TekoArtes
        {
            get { return this.tekoArtes; }
            set { SetValue(ref this.tekoArtes, value); }
        }
        #endregion
        #region Constructor 
        public TekoArteViewModel()
        {
            this.apiService = new ApiService();
            this.LoadTekoArtes();


        }
        #endregion

        #region Methods 
        private async void LoadTekoArtes()
        {
            var connection = await apiService.CheckConnection();
            if (!connection.IsSuccess)
            {
                await Application.Current.MainPage.DisplayAlert(
                "Internet Error Connection",
                connection.Message,
                "Accept"
                );
                return;
            }
            var response = await apiService.GetList<TekoArte>(
                "http://localhost:50399/", //base
                "api/TekoArtes", //prefijo
                "TekoArtes" //controlador
            );

            if (!response.IsSuccess)
            {
                await Application.Current.MainPage.DisplayAlert(
                    "Phone Service Error",
                    response.Message,
                    "Accept"
                    );
                return;
            }
            MainViewModel main = MainViewModel.GetInstance();
            main.ListTekoArte = (List<TekoArte>)response.Result;

            this.TekoArtes = new ObservableCollection<TekoArte>(ToTekoArteCollect());

        }

        private IEnumerable<TekoArte> ToTekoArteCollect()
        {
            ObservableCollection<TekoArte> collection = new ObservableCollection<TekoArte>();
            MainViewModel main = MainViewModel.GetInstance();
            foreach(var lista in main.ListTekoArte)
                {
                TekoArte tekoArte = new TekoArte();
                tekoArte.Painting = lista.Painting;
                tekoArte.Vase = lista.Vase;
                tekoArte.Plate = lista.Plate;
                tekoArte.Others = lista.Others;
                collection.Add(tekoArte);
            }
            return (collection);
        }
        
        #endregion
    }
}


   
