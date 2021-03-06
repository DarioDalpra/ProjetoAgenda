﻿using Agenda_WPF.DAL;
using Agenda_WPF.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace Agenda_WPF.View
{
    
    /// <summary>
    /// Interaction logic for UcListarUsuario.xaml
    /// </summary>
    public partial class UcListarUsuario : UserControl
    {
        Context ctx = new Context();
        public UcListarUsuario()
        {
            InitializeComponent();
            FormLoad();
        }
        private void FormLoad()
        {
            var consulta = ctx.Usuarios;
            dtgListaUsuarios.ItemsSource = consulta.ToList();

            rdoCpf.IsChecked = false;
            rdoEmail.IsChecked = false;
            rdoNome.IsChecked = false;

        }

        private void btnSairListar_Click(object sender, RoutedEventArgs e)
        {
        //    this.Close();
        }

        private void btnFiltrar_Click(object sender, RoutedEventArgs e)
        {
            if (rdoCpf.IsChecked == true)
            {
                var FiltroCpf = ctx.Usuarios.Where(x => x.Cpf.Contains(txtFiltro.Text));
                dtgListaUsuarios.ItemsSource = FiltroCpf.ToList();
            }
            else if (rdoEmail.IsChecked == true)
            {
                var FiltroEmail = ctx.Usuarios.Where(x => x.Email.Contains(txtFiltro.Text));
                dtgListaUsuarios.ItemsSource = FiltroEmail.ToList();
            }
            else if (rdoNome.IsChecked == true)
            {
                var FiltroNome = ctx.Usuarios.Where(x => x.Nome.Contains(txtFiltro.Text));
                dtgListaUsuarios.ItemsSource = FiltroNome.ToList();
            }
            else
            {
                MessageBox.Show("Por favor selecione um tipo de filtro!!");
            }
        }

        private void btn_CadastrarUsuario_Click(object sender, RoutedEventArgs e)
        {
            UcCadastrarUsuario CadUsuario = new UcCadastrarUsuario();
          //  CadUsuario.Show();
        }

        private void btn_CadastrarMedico_Click(object sender, RoutedEventArgs e)
        {
            UcCadastrarMedico CadMedico = new UcCadastrarMedico();
         //   CadMedico.Show();
        }

        private void btn_CadastrarPaciente_Click(object sender, RoutedEventArgs e)
        {
            UcCadastrarPaciente frm = new UcCadastrarPaciente();
         //   frm.ShowDialog();
        }

        private void btn_Fechar_Click(object sender, RoutedEventArgs e)
        {
          //  this.Close();
        }

        private void btn_ListarPaciente_Click(object sender, RoutedEventArgs e)
        {
            UcListarPaciente frm = new UcListarPaciente();
            //frm.ShowDialog();
        }

        private void btnAlterar_Click(object sender, RoutedEventArgs e)
        {

        }

        private void btnLocalizar_Click(object sender, RoutedEventArgs e)
        {

        }

        private void btnExcluir_Click(object sender, RoutedEventArgs e)
        {

        }

        private void btnFechar_Click(object sender, RoutedEventArgs e)
        {
           // this.Close();
        }

        private void btnCadastrar_Click(object sender, RoutedEventArgs e)
        {

        }

        private void btnCancelar_Click(object sender, RoutedEventArgs e)
        {

        }
    }
}