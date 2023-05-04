using Study_Navigation.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Study_Navigation.MVVM.ViewModel
{
    class TeacherViewModel : ObservableObject
    {
        /// <summary>
        /// Отображения
        /// </summary>
        public HomeViewModel homeView { get; set; }

        private object _currentView; //То, что выводится изначально в основном окне

        /// <summary>
        /// Отображаем в окно
        /// </summary>
        public object CurrentView
        {
            get { return _currentView; }
            set
            {
                _currentView = value;
                OnPropertyChanged();
            }
        }

        /// <summary>
        /// Смена окон при нажатии на кнопки
        /// Изначально выовдятся кнопки основного интерфейса пользователя
        /// </summary>
        public TeacherViewModel()
        {
            homeView = new HomeViewModel();

            CurrentView = homeView;
        }
    }
}
