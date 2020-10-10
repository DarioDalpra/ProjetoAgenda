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
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace Agenda_WPF.View
{
    /// <summary>
    /// Interaction logic for UcCadastrarProcedimento.xaml
    /// </summary>
    public partial class UcCadastrarProcedimento : UserControl
    {
        private Procedimento procedimento;
        public UcCadastrarProcedimento()
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
          //  this.Close();
        }
    }
}
