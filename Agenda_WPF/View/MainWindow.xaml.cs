using Agenda_WPF.View;
using System.Windows;

namespace Agenda_WPF
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }
        public MainWindow(string UsrLogin)
        {
            InitializeComponent();
            lblUsrLogado.Content = $"Seja bem vindo(a) {UsrLogin}!";
        }

        private void Window_Closing(object sender, System.ComponentModel.CancelEventArgs e)
        {
            if (MessageBox.Show("Deseja fechar a janela:", "Agenda_WPF",
                MessageBoxButton.YesNo, MessageBoxImage.Question) ==
                MessageBoxResult.No)
            {
                e.Cancel = true;
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

        private void btn_ListarPaciente_Click(object sender, RoutedEventArgs e)
        {
            frmListarPaciente frm = new frmListarPaciente();
            frm.ShowDialog();
        }

        private void btn_EncerrarSistema_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void btn_ListarUsuario_Click(object sender, RoutedEventArgs e)
        {
            frmListarUsuario listarUsuario = new frmListarUsuario();
            listarUsuario.Show();
        }

        private void btn_ListarMedico_Click(object sender, RoutedEventArgs e)
        {
            //frmListarMedico listarMedico = new frmListarMedico();
            //listarMedico.Show();
        }
    }
}