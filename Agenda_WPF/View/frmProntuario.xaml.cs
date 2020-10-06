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
        public frmProntuario()
        {
            InitializeComponent();
        }



        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            cboMedico.ItemsSource = MedicoDAO.ListarMedicos();
            cboMedico.DisplayMemberPath = "Nome"; // nome = é o mesmo atributo desejado da tabela DAO
            cboMedico.SelectedValuePath = "idMedico";


        }

        private void btnCadastrarProntuario_Click(object sender, RoutedEventArgs e)
        {
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