using Agenda_WPF.DAL;
using Agenda_WPF.Model;
using System;
using System.Windows;

namespace NewAgenda_WPF.Views
{
    /// <summary>
    /// Interaction logic for frmCadastrarProcedimento.xaml
    /// </summary>
    public partial class frmCadastrarProcedimento : Window
    {
        private Procedimento procedimento;
        public frmCadastrarProcedimento()
        {
            InitializeComponent();
            txtProcedimento.Focus();
        }

        private void btnGravar_Click(object sender, RoutedEventArgs e)
        {
            if (!string.IsNullOrWhiteSpace(txtProcedimento.Text))
            {
                procedimento = new Procedimento
                {
                    NomeProcedimento = txtProcedimento.Text,
                    Valor = Convert.ToDouble(txtValor.Text)
                };
                if (ProcedimentoDAO.Cadastrar(procedimento))
                {
                    MessageBox.Show("Procedimento cadastrado!", "Vendas WPF",
                        MessageBoxButton.OK, MessageBoxImage.Information);
                    LimparFormulario();
                }
                else
                {
                    MessageBox.Show("Esse Procedimento já existe!", "Vendas WPF",
                        MessageBoxButton.OK, MessageBoxImage.Error);
                }
            }
            else
            {
                MessageBox.Show("Preencha o campo Procedimento!!!", "Vendas WPF",
                    MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        private void LimparFormulario()
        {
            txtProcedimento.Clear();
            txtValor.Clear();

            txtProcedimento.Focus();
        }

        private void btnSair_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
    }
}