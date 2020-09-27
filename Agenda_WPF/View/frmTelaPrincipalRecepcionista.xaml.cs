using System;
using System.Collections.Generic;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace Agenda_WPF.View
{
    /// <summary>
    /// Interaction logic for frmTelaPrincipalRecepcionista.xaml
    /// </summary>
    public partial class frmTelaPrincipalRecepcionista : Window
    {
        public frmTelaPrincipalRecepcionista()
        {
            InitializeComponent();
        }

        public frmTelaPrincipalRecepcionista(string AteLogin)
        {
            InitializeComponent();
            lblAteLogado.Content = $"Seja bem vindo(a) {AteLogin}!";
        }

        private void btnSair_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void btn_ImpressaoDeclaracao_Click(object sender, RoutedEventArgs e)
        {

        }

        private void btnFechar_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void btnListarPaciente_Click(object sender, RoutedEventArgs e)
        {
            frmListarPaciente listarPaciente = new frmListarPaciente();
            listarPaciente.ShowDialog();
        }

        private void txtDta_TextChanged(object sender, System.Windows.Controls.TextChangedEventArgs e)
        {
            if (txtDta.Text != null)
            {
                //frmAgenda Agenda = new frmAgenda();
                //Agenda.dtaAgendamento = txtDta.Text;
                //Agenda.ShowDialog();
                frmCadastrarPaciente cadastrarPaciente = new frmCadastrarPaciente();
                cadastrarPaciente.dtaConsulta = txtDta.Text;
                cadastrarPaciente.ShowDialog();

            }
        }

        private void btnCadastrarPaciente_Click(object sender, RoutedEventArgs e)
        {
            frmCadastrarPaciente cadastrarPaciente = new frmCadastrarPaciente();
            cadastrarPaciente.ShowDialog();
        }
    }
}