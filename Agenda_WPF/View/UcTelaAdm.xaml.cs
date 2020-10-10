using Agenda_WPF.Views;
using MaterialDesignThemes.Wpf;
using System.Windows;
using System.Windows.Controls;

namespace Agenda_WPF.View
{
    /// <summary>
    /// Interaction logic for UcTelaAdm.xaml
    /// </summary>
    public partial class UcTelaAdm : UserControl
    {
        public UcTelaAdm(string UsrLogin)
        {
            InitializeComponent();
            lblUsrLogado.Content = $"Seja bem vindo(a) {UsrLogin}!";
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {

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

        private void btnCadastrarUsuario_Click(object sender, RoutedEventArgs e)
        {
            UcCadastrarUsuario CadUsuario = new UcCadastrarUsuario();
           // CadUsuario.ShowDialog();
        }

        private void btnCadastrarMedico_Click(object sender, RoutedEventArgs e)
        {
            UcCadastrarMedico CadMedico = new UcCadastrarMedico();
           // CadMedico.ShowDialog();
        }

        private void btnCadastrarPaciente_Click(object sender, RoutedEventArgs e)
        {
            UcCadastrarPaciente frm = new UcCadastrarPaciente();
        //    frm.ShowDialog();
        }

        private void btnListarPaciente_Click(object sender, RoutedEventArgs e)
        {
            UcListarPaciente frm = new UcListarPaciente();
            //frm.ShowDialog();
        }

        private void btnEncerrarSistema_Click(object sender, RoutedEventArgs e)
        {
           // this.Close();
        }

        private void btnListarUsuario_Click(object sender, RoutedEventArgs e)
        {
            UcListarUsuario listarUsuario = new UcListarUsuario();
            //listarUsuario.ShowDialog();
        }

        private void btnListarMedico_Click(object sender, RoutedEventArgs e)
        {
            UcListarMedico listarMedico = new UcListarMedico();
         //   listarMedico.ShowDialog();
        }

        private void btnAgendarConsulta_Click(object sender, RoutedEventArgs e)
        {
            //frmAgenda agenda = new frmAgenda();
            //agenda.ShowDialog();
         //   UcTelaPrincipalRecepcionista agendarConsulta = new UcTelaPrincipalRecepcionista();
        //    agendarConsulta.ShowDialog();
        }

        private void btnProntuario_Click(object sender, RoutedEventArgs e)
        {
            UcProntuario prontuario = new UcProntuario();
            //prontuario.ShowDialog();
        }

        private void btnListarProntuario_Click(object sender, RoutedEventArgs e)
        {
            UcListarProntuario listarProntuario = new UcListarProntuario();
            //listarProntuario.ShowDialog();
        }

        private void btnCadastrarPlanoSaude_Click(object sender, RoutedEventArgs e)
        {
            UcCadastrarPlanoSaude cadastrarPlanoSaude = new UcCadastrarPlanoSaude();
            //cadastrarPlanoSaude.ShowDialog();
        }

        private void btnCadastrarProcedimento_Click(object sender, RoutedEventArgs e)
        {
            UcCadastrarProcedimento cadastrarProcedimento = new UcCadastrarProcedimento();
            //cadastrarProcedimento.ShowDialog();
        }
    }
}
