using Agenda_WPF.DAL;
using Agenda_WPF.Model;
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

namespace Agenda_WPF.Views
{
    /// <summary>
    /// Interaction logic for frmTelaPrincipalMedico.xaml
    /// </summary>
    public partial class frmTelaPrincipalMedico : Window
    {

        private List<dynamic> agendas = new List<dynamic>();
        private string nomeMedico { get; set; }

        public frmTelaPrincipalMedico()
        {
            InitializeComponent();
        }

        public frmTelaPrincipalMedico(string MedLogin)
        {
            InitializeComponent();
            lblMedLogado.Content = $"Seja bem vindo(a) {MedLogin}!";
            nomeMedico = MedLogin;
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            int test = 0;
            preencherListagem();
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

        private void preencherListagem()
        {
            int idMedico = 1; // Id do medico da tela

            List<Agenda> listaAgendaBanco = AgendaDAO.BuscarListagemPorMedico(idMedico);

            int test = 0;
            foreach (Agenda a in listaAgendaBanco)
            {
                agendas.Add(new
                {
                    Paciente = a.Paciente.Nome,
                    DataAgendada = a.DataAgendada,
                    HoraAgendada = a.HoraAgendada,
                    Plano = a.Plano,
                    idPaciente = a.Paciente.IdPaciente,
                    idMedico = a.Medico.IdMedico
                });
            }
            test = 1;
            dtgAgendaMedico.ItemsSource = agendas;
            dtgAgendaMedico.Items.Refresh();
            test = 2;
            //itens.Add(new
            //{
            //    Nome = produto.Nome,
            //    Preco = produto.Preco.ToString("C2"),
            //    Quantidade = Convert.ToInt32(txtQuantidade.Text),
            //    Subtotal =
            //        (Convert.ToInt32(txtQuantidade.Text) * produto.Preco).ToString("C2")
            //});
        }

        private void DataGrid_Row_Click(object sender, MouseButtonEventArgs e)
        {

            if (dtgAgendaMedico.SelectedItem == null) return;

            var valores = dtgAgendaMedico.SelectedItem as dynamic;
            var idPaciente = valores.idPaciente;
            var idMedico = valores.idMedico;
            var nomePaciente = valores.Paciente;
            CarregaProntuario(Convert.ToInt32(idPaciente), Convert.ToInt32(idMedico), nomePaciente);
            // Carregar outra tela (pronturario)
        }
        private void CarregaProntuario(int idPac, int idMed, string nomePaciente)
        {
            frmProntuario prontuario = new frmProntuario();
            prontuario.IdPaciente = idPac;
            prontuario.NomePaciente = nomePaciente;
            prontuario.IdMedico = idMed;
            prontuario.NomeMedico = nomeMedico;
            prontuario.ShowDialog();
        }
    }
}