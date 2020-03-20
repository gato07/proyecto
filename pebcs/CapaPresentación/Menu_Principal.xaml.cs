﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
using TestStack.White.ScreenObjects;

namespace CapaPresentación
{
    /// <summary>
    /// Lógica de interacción para Menu_Principal.xaml
    /// </summary>
    public partial class Menu_Principal : Window
    {
        public Menu_Principal()
        {
            InitializeComponent();
        }

        private void ButtonOpenMenu_Click(object sender, RoutedEventArgs e)
        {
            ButtonOpenMenu.Visibility = Visibility.Collapsed;
            ButtonCloseMenu.Visibility = Visibility.Visible;
        }

        private void ButtonCloseMenu_Click(object sender, RoutedEventArgs e)
        {
            ButtonOpenMenu.Visibility = Visibility.Visible;
            ButtonCloseMenu.Visibility = Visibility.Collapsed;
        }

        private void ButtonClose_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private  void listViewItem_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            AbrirFormHijo(new PantallaUsuario());
        }
        private void AbrirFormHijo(object formhijo)
        {
            if (this.PanelPrincipal.Children.Count > 0)
                this.PanelPrincipal.Children.RemoveAt(0);
            UserControl userControl = formhijo as UserControl;
            PanelPrincipal.Children.Add(userControl);
        }
    }
}
