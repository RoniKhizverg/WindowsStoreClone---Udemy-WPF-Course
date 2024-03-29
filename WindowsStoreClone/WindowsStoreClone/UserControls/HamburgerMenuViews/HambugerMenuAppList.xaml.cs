﻿using System.Collections.Generic;
using System.Linq;
using System.Windows.Controls;

namespace WindowsStoreClone.UserControls.HamburgerMenuViews
{

    public partial class HambugerMenuAppList : UserControl
    {
        public List<HamguerMenuApp> AllApps;
        public List<HamguerMenuApp> AppsOnFilter;
        public HambugerMenuAppList()
        {
            AllApps = new List<HamguerMenuApp>();
            AppsOnFilter = new List<HamguerMenuApp>();
            InitializeComponent();
            for (int i = 0; i < 15; i++)
            {
                AddNewHamApp();
            }
        }
        private void AddNewHamApp()
        {
            HamguerMenuApp anApp = new HamguerMenuApp();
            MainStackPanel.Children.Add(anApp);
            AllApps.Add(anApp);
        }
        public void FilterByType(string inFilter)
        {
            AppsOnFilter = AllApps.Where(p => p.Type == inFilter).ToList<HamguerMenuApp>();
            AddToMainStackPanel(AppsOnFilter);
        }
        public void AddAll()
        {
            AppsOnFilter = new List<HamguerMenuApp>();
            AddToMainStackPanel(AllApps);
        }
        public void SortByName()
        {
            List<HamguerMenuApp> AllAppsSorted = new List<HamguerMenuApp>();
            if (AppsOnFilter.Count < 1)
            {
                AllAppsSorted = AllApps.OrderBy(p => p.AppName).ToList<HamguerMenuApp>();
            }
            else
            {
                AllAppsSorted = AppsOnFilter.OrderBy(p => p.AppName).ToList<HamguerMenuApp>();
            }
            AddToMainStackPanel(AllAppsSorted);
        }
       
        public void SortByDate()
        {
            List<HamguerMenuApp> AllAppsSorted = new List<HamguerMenuApp>();
            if (AppsOnFilter.Count < 1)
            {
                AllAppsSorted = AllApps.OrderByDescending(p => p.Purchased).ToList<HamguerMenuApp>();
            }
            else
            {
                AllAppsSorted = AppsOnFilter.OrderByDescending(p => p.Purchased).ToList<HamguerMenuApp>();
            }
            AddToMainStackPanel(AllAppsSorted);
        }
      
        private void AddToMainStackPanel(List<HamguerMenuApp> inList)
        {
            MainStackPanel.Children.Clear();
            foreach (HamguerMenuApp item in inList)
            {
                MainStackPanel.Children.Add(item);
            }
        }
    }

}
