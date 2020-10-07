using Agenda_WPF.DAL;
using Agenda_WPF.Model;
using System.Windows;
namespace NewAgenda_WPF.Views
{
    /// <summary>
    /// Interaction logic for frmCadastrarPlanoSaude.xaml
    /// </summary>

    /// <summary>
    /// Interaction logic for frmCadastrarPlanoSaude.xaml
    /// </summary>
    public partial class frmCadastrarPlanoSaude : Window
    {
        public frmCadastrarPlanoSaude()
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