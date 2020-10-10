using Agenda_WPF.DAL;
using Agenda_WPF.Model;
using System.Linq;
using System.Windows;


namespace Agenda_WPF.Views
{
    /// <summary>
    /// Interaction logic for frmListarUsuario.xaml
    /// </summary>
    public partial class frmListarUsuario : Window
    {
        Context ctx = new Context();
        public frmListarUsuario()
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
            this.Close();
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
            frmCadastrarUsuario CadUsuario = new frmCadastrarUsuario();
            CadUsuario.Show();
        }

        private void btn_CadastrarMedico_Click(object sender, RoutedEventArgs e)
        {
            frmCadastrarMedico CadMedico = new frmCadastrarMedico();
            CadMedico.Show();
        }

        private void btn_CadastrarPaciente_Click(object sender, RoutedEventArgs e)
        {
            frmCadastrarPaciente frm = new frmCadastrarPaciente();
            frm.ShowDialog();
        }

        private void btn_Fechar_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void btn_ListarPaciente_Click(object sender, RoutedEventArgs e)
        {
            frmListarPaciente frm = new frmListarPaciente();
            frm.ShowDialog();
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
            this.Close();
        }

        private void btnCadastrar_Click(object sender, RoutedEventArgs e)
        {

        }

        private void btnCancelar_Click(object sender, RoutedEventArgs e)
        {

        }
    }
}