using Agenda_WPF.DAL;
using Agenda_WPF.Model;
using System.Linq;
using System.Windows;


namespace Agenda_WPF.Views
{
    /// <summary>
    /// Interaction logic for frmListarMedico.xaml
    /// </summary>
    public partial class frmListarProntuario : Window
    {
        private string operacao;

        private Prontuario prontuario;
        public frmListarProntuario()
        {
            InitializeComponent();

            cboMedico.ItemsSource = MedicoDAO.ListarMedicos();
            cboMedico.DisplayMemberPath = "Nome"; // nome = é o mesmo atributo desejado da tabela DAO
            cboMedico.SelectedValuePath = "";
        }
        private void btnSalvar_Click(object sender, RoutedEventArgs e)
        {
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            this.ListarDados();
        }

        private void ListarDados()
        {
            Context ctx = SingletonContext.GetInstance();
            {
                var consulta = ctx.Medicos;
                dtaProntuario.ItemsSource = consulta.ToList();

            }
        }

        private void btn_CadastrarProntuario_Click(object sender, RoutedEventArgs e)
        {
            //if (!string.IsNullOrWhiteSpace(txtNomePaciente.Text))
            //{
            //    prontuario = new Prontuario()
            //    {
            //        NomePaciente = txtNomePaciente.Text,
            //        NomeMedico = cboMedico.SelectedValuePath(),

            //    };
            //    if (ProntuarioDAO.CadastrarProntuario(prontuario))
            //    {
            //        MessageBox.Show("Prontuário cadastrado com sucesso!!!", "Agenda WPF",
            //            MessageBoxButton.OK, MessageBoxImage.Information);
            //        LimparFormulario();
            //    }
            //    else
            //    {
            //        MessageBox.Show("Esse prontuário já existe!!!", "Agenda WPF",
            //            MessageBoxButton.OK, MessageBoxImage.Error);
            //    }
            //}
            //else
            //{
            //    MessageBox.Show("Preencha o campo nome!!!", "Agenda WPF",
            //        MessageBoxButton.OK, MessageBoxImage.Error);
            //}
        }

        private void btn_CadastrarPaciente_Click(object sender, RoutedEventArgs e)
        {

        }

        private void btn_Fechar_Click(object sender, RoutedEventArgs e)
        {
            this.Close();

        }
    }

}