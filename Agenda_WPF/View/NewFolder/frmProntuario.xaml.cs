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
    /// Interaction logic for frmProntuario.xaml
    /// </summary>
    public partial class frmProntuario : Window
    {
        private Prontuario Prontuario;

        public int IdPaciente
        {
            get; set;
        }
        public string NomePaciente
        {
            set { txtPaciente.Text = value; }
        }
        public int IdMedico
        {
            get; set;
        }
        public string NomeMedico
        {
            set { txtMedico.Text = value; }
        }

        public frmProntuario()
        {
            InitializeComponent();
        }



        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            txtConsulta.Text = DateTime.Now.ToString("dd/MM/yyyy");
        }

        private void btnCadastrarProntuario_Click(object sender, RoutedEventArgs e)
        {
            Prontuario p = new Prontuario
            {
                Avaliacao = txtAvaliacao.Text,
                Sintomas = txtSintomas.Text,
                Medicamento = txtMedicamentos.Text
            };
            Paciente pac = PacienteDAO.BuscarPacientePorId(IdPaciente);
            Medico med = MedicoDAO.BuscarMedicoPorId(IdMedico);
            p.PlanoSaude = pac.NomePlano;
            p.NomePaciente = pac;
            p.NomeMedico = med;

            string msgCadastrou = ProntuarioDAO.Cadastrar(p);
            if (msgCadastrou == null)
            {
                // limpar
                MessageBox.Show("Prontuário cadastrado!");
            }
            else
            {
                MessageBox.Show(msgCadastrou);
            }

            //if (!string.IsNullOrWhiteSpace(txtPaciente.Text))
            //{
            //    Prontuario = new Prontuario
            //    {
            //        NomePaciente = txtPaciente.Text,
            //        Sintomas = txtSintomas.Text,
            //        Avaliacao = txtAvaliacao.Text,
            //        Medicamento = txtMedicamentos.Text
            //    };
            //    if (ProntuarioDAO.CadastrarProntuario(Prontuario))
            //    {
            //        MessageBox.Show("Produto cadastrado com sucesso!!!", "Vendas WPF",
            //            MessageBoxButton.OK, MessageBoxImage.Information);
            //        LimparFormulario();
            //    }
            //    else
            //    {
            //        MessageBox.Show("Esse produto já existe!!!", "Vendas WPF",
            //            MessageBoxButton.OK, MessageBoxImage.Error);
            //    }
            //}
            //else
            //{
            //    MessageBox.Show("Preencha o campo nome!!!", "Vendas WPF",
            //        MessageBoxButton.OK, MessageBoxImage.Error);
            //}
        }

        private void LimparFormulario()
        {
            txtPaciente.Clear();
            txtSintomas.Clear();
            txtAvaliacao.Clear();
            txtMedicamentos.Clear();
            txtIdProntuario.Clear();



        }

        private void btnFechar_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

    }
}