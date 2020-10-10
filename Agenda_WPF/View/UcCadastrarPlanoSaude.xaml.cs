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
    /// Interaction logic for UcCadastrarPlanoSaude.xaml
    /// </summary>
    public partial class UcCadastrarPlanoSaude : UserControl
    {
        public UcCadastrarPlanoSaude()
        {
            InitializeComponent();
            LimpaCampos();
        }
        private void LimpaCampos()
        {
            txtNomePlano.Clear();
            txtNomePlano.Focus();
        }
        private void btnCadastratPlano_Click(object sender, RoutedEventArgs e)
        {
            PlanoSaude ps = new PlanoSaude();
            ps.Plano = txtNomePlano.Text.ToUpper();

            if (PlanoSaudeDAO.CadastrarPlanoSaude(ps))
            {
                MessageBox.Show("Plano de Saúde cadastrado!", "Cadastro",
                                 MessageBoxButton.OK, MessageBoxImage.Information);
                LimpaCampos();

            }

        }
    }
}
    
    