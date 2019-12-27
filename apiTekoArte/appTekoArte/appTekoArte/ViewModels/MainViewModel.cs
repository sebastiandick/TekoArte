
namespace appTekoArte.ViewModels
{
    using appTekoArte.Models;
    using System.Collections.Generic;

    public class MainViewModel
    {
        #region Properties
        public List<TekoArte> ListTekoArte { get; set; }
        #endregion


        #region ViewModels
        public TekoArteViewModel tekoArteViewModel { get; set; }
        #endregion

        #region Constructor
        public MainViewModel()
        {
            instance = this;
            tekoArteViewModel = new TekoArteViewModel();
        }
        #endregion

        #region Singleton
        private static MainViewModel instance;
        public static MainViewModel GetInstance()
        {
            if (instance == null)
            {
                instance = new MainViewModel();
            }
            return (instance);
        }
        #endregion

    }
}
