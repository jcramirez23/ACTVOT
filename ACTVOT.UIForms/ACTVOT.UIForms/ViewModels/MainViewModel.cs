﻿
using ACTVOT.common.Models;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;

namespace ACTVOT.UIForms.ViewModels
{
   public class MainViewModel
    {

        private static MainViewModel instance;

        public ObservableCollection<MenuItemViewModel> Menus { get; set; }

        public LoginViewModel Login { get; set; }

        public ActvotsViewModel Actvots { get; set; }

        public MainViewModel()
        {
            instance = this;
            this.LoadMenus();
        }
        private void LoadMenus()
        {
            var menus = new List<Menu>
    {
        new Menu
        {
            Icon = "ic_info",
            PageName = "AboutPage",
            Title = "About"
        },

        new Menu
        {
            Icon = "ic_phonelink_setup",
            PageName = "SetupPage",
            Title = "Setup"
        },

        new Menu
        {
            Icon = "ic_exit_to_app",
            PageName = "LoginPage",
            Title = "Close session"
        }
    };

            this.Menus = new ObservableCollection<MenuItemViewModel>(
                menus.Select(m => new MenuItemViewModel
            {
                Icon = m.Icon,
                PageName = m.PageName,
                Title = m.Title
            }).ToList());
        }


        public static MainViewModel GetInstance()
        {
            if (instance == null)
            {
                return new MainViewModel();
            }
            return instance;
        }
    }
}
