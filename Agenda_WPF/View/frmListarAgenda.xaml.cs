using Agenda_WPF.Model;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
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
    /// Interaction logic for frmListarAgenda.xaml
    /// </summary>
    public partial class frmListarAgenda : Window
    {
        private Agenda agenda = new Agenda();
        private List<dynamic> agendamento = new List<dynamic>();
        public frmListarAgenda()
        {
            InitializeComponent();

        }

        private void btnFechar_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
        private void PopularDataGrid(Agenda agenda)
        {
            agendamento.Add(new
            {
                Nome = agenda.Nome,
                Plano = agenda.Plano,
                Medico = agenda.NomeMedico,
                DataAgendada = agenda.DataAgendada,

            });
        }

        private void btnProntuario_Click(object sender, RoutedEventArgs e)
        {
            frmListarProntuario cadastrarPaciente = new frmListarProntuario();
            cadastrarPaciente.Show();
        }
    }
}