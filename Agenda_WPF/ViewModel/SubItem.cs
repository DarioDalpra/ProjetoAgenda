﻿using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Controls;

namespace Agenda_WPF.ViewModel
{
    class SubItem
    {
        public SubItem(string name, UserControl screen = null)
        {
            Name = name;
            screen = screen;
        }

        public string Name { get; private set; }
        public UserControl Screen { get; private set; }
    }
}
