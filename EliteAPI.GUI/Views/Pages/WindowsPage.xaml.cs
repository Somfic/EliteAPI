// This Source Code Form is subject to the terms of the MIT License.
// If a copy of the MIT was not distributed with this file, You can obtain one at https://opensource.org/licenses/MIT.
// Copyright (C) Leszek Pomianowski and WPF UI Contributors.
// All Rights Reserved.

using System.Windows.Controls;
using WPFUI.Controls;

namespace EliteAPI.GUI.Views.Pages
{
    /// <summary>
    /// Interaction logic for WindowsPage.xaml
    /// </summary>
    public partial class WindowsPage : Page, INavigable
    {
        public WindowsPage()
        {
            InitializeComponent();
        }
        
        public void OnNavigationRequest(INavigation sender, object current)
        {
            System.Diagnostics.Debug.WriteLine("Page with window selectors loaded.");
        }
    }
}
