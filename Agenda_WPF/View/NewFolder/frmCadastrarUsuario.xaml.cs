using Agenda_WPF.DAL;
using Agenda_WPF.Model;
using Agenda_WPF.Utils;
using RestSharp;
using RestSharp.Serialization.Json;
using System.Windows;


namespace Agenda_WPF.Views
{
    /// <summary>
    /// Interaction logic for frmCadastrarUsuario.xaml
    /// </summary>
    public partial class frmCadastrarUsuario : Window
    {
        public frmCadastrarUsuario()
        {
            InitializeComponent();
            txtNomeUsuario.Focus();
            LimpaCampos();
        }

        private void LimpaCampos()
        {
            btnCadastrar.IsEnabled = true;
            btnAlterar.IsEnabled = false;
            btnLocalizar.IsEnabled = true;
            btnExcluir.IsEnabled = false;
            btnFechar.IsEnabled = true;

            txtNomeUsuario.Clear();
            txtCpfUsuario.Clear();
            txtEmailUsuario.Clear();
            txtTelefone.Clear();
            txtCep_Leave.Clear();
            txtRua.Clear();
            txtNumero.Clear();
            txtBairro.Clear();
            txtCidade.Clear();
            txtEstado.Clear();
            pwdSenhaUsuario.Clear();
            chkAdministrador.IsChecked = false;
            chkMedico.IsChecked = false;
            chkAtendente.IsChecked = false;
        }

        private void btnCadastrar_Click(object sender, RoutedEventArgs e)
        {
            Usuario usr = new Usuario();
            usr.Nome = txtNomeUsuario.Text;
            usr.Cpf = txtCpfUsuario.Text;
            usr.Email = txtEmailUsuario.Text;
            usr.Telefone = txtTelefone.Text;
            usr.Cep = txtCep_Leave.Text;
            usr.Rua = txtRua.Text;
            usr.Numero = txtNumero.Text;
            usr.Bairro = txtBairro.Text;
            usr.Cidade = txtCidade.Text;
            usr.Estado = txtEstado.Text;
            usr.Senha = pwdSenhaUsuario.Password;

            if (chkAdministrador.IsChecked == true)
            {
                usr.Administrador = chkAdministrador.IsChecked.Value;
            }

            if (chkMedico.IsChecked == true)
            {
                usr.Medico = chkMedico.IsChecked.Value;
            }

            if (chkAtendente.IsChecked == true)
            {
                usr.Atendente = chkAtendente.IsChecked.Value;
            }

            if (Valida.ValidarCPF(usr.Cpf))
            {
                if (UsuarioDAO.CadastrarUsuario(usr))
                {
                    MessageBox.Show("Usuário cadastrado!");
                    LimpaCampos();
                    txtNomeUsuario.Focus();
                }
                else
                {
                    MessageBox.Show("Usuário já existe.");
                    txtNomeUsuario.Focus();
                }
            }
            else
            {
                MessageBox.Show("CPF inválido.");
            }
        }

        private void btnBuscarUsuario_Click(object sender, RoutedEventArgs e)
        {
            frmListarUsuario listarUsuarios = new frmListarUsuario();
            listarUsuarios.Show();
        }

        private void btnFechar_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void btnCadastrarPaciente_Click(object sender, RoutedEventArgs e)
        {
            frmCadastrarPaciente cadastrarPaciente = new frmCadastrarPaciente();
            cadastrarPaciente.Show();
        }

        private void btnListarPaciente_Click(object sender, RoutedEventArgs e)
        {
            frmListarPaciente listarPaciente = new frmListarPaciente();
            listarPaciente.Show();
        }

        private void btnCancelar_Click(object sender, RoutedEventArgs e)
        {

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

        private void btnBuscaCep_Click(object sender, RoutedEventArgs e)
        {
            LocalizarCEP();
        }

        private void LocalizarCEP()
        {
            RestClient restClient = new RestClient(string.Format("https://viacep.com.br/ws/{0}/json/", txtCep_Leave.Text));
            RestRequest restRequest = new RestRequest(Method.GET);
            IRestResponse restResponse = restClient.Execute(restRequest);

            BuscaCep cepRetorno = new JsonDeserializer().Deserialize<BuscaCep>(restResponse);

            if (cepRetorno.cep is null)
            {
                MessageBox.Show("CEP não encontrado! ", "Atenção!", MessageBoxButton.OK, MessageBoxImage.Exclamation);
                txtCep_Leave.Clear();
                txtCep_Leave.Focus();
                return;
            }
            txtRua.Text = cepRetorno.logradouro;
            txtBairro.Text = cepRetorno.bairro;
            txtCidade.Text = cepRetorno.localidade;
            txtEstado.Text = cepRetorno.uf;
        }
    }
}