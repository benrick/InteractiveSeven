﻿using InteractiveSeven.Core.Memory;
using InteractiveSeven.Core.Models;
using InteractiveSeven.UI.ViewModels;
using ReactiveUI;
using ReactiveUI.Winforms;
using System;

namespace InteractiveSeven.UI.UserControls
{
    public partial class MenuColorControlTab : ReactiveUserControl<MenuControlViewModel>
    {
        private readonly MenuColorAccessor _menuColorAccessor;

        public MenuColorControlTab()
        {
            InitializeComponent();

            _menuColorAccessor = new MenuColorAccessor(new MemoryAccessor());

            ViewModel = new MenuControlViewModel();

            this.Bind(ViewModel, x => x.TopLeftColor, x => x.topLeftColorPicker.Color);
            this.Bind(ViewModel, x => x.BottomLeftColor, x => x.botLeftColorPicker.Color);
            this.Bind(ViewModel, x => x.TopRightColor, x => x.topRightColorPicker.Color);
            this.Bind(ViewModel, x => x.BottomRightColor, x => x.botRightColorPicker.Color);

            this.OneWayBind(ViewModel, x => x.TopLeftColor, x => x.topLeftColorSwatch.BackColor);
            this.OneWayBind(ViewModel, x => x.BottomLeftColor, x => x.botLeftColorSwatch.BackColor);
            this.OneWayBind(ViewModel, x => x.TopRightColor, x => x.topRightColorSwatch.BackColor);
            this.OneWayBind(ViewModel, x => x.BottomRightColor, x => x.botRightColorSwatch.BackColor);
        }

        internal void RefreshColors()
        {
            string processName = "ff7_en";
            if (string.IsNullOrWhiteSpace(processName))
            {
                return;
            }

            MenuColors currentColors = _menuColorAccessor.GetMenuColors(processName);

            ViewModel.SetColors(currentColors);
        }

        private void RefreshColorsButton_Click(object sender, EventArgs e)
        {
            RefreshColors();
        }

        private void SetColorsButton_Click(object sender, EventArgs e)
        {
            string processName = "ff7_en";
            if (string.IsNullOrWhiteSpace(processName))
            {
                return;
            }

            var menuColors = new MenuColors
            {
                TopLeft = topLeftColorPicker.Color,
                TopRight = topRightColorPicker.Color,
                BotLeft = botLeftColorPicker.Color,
                BotRight = botRightColorPicker.Color
            };

            _menuColorAccessor.SetMenuColors(processName, menuColors);
        }
    }
}