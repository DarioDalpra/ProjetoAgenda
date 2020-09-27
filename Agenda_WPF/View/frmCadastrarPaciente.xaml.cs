using Agenda_WPF.DAL;
using Agenda_WPF.Model;
using Agenda_WPF.Utils;
using RestSharp;
using RestSharp.Serialization.Json;
using System;
using System.Windows;

namespace Agenda_WPF.View
{
    /// <summary>
    /// Interaction logic for frmCadastrarPaciente.xaml
    /// </summary>
    public partial class frmCadastrarPaciente : Window
    {
        private string operacao;
        Context ctx = SingletonContext.GetInstance();
        Paciente pac = new Paciente();

        public frmCadastrarPaciente()
        {
            InitializeComponent();
            LimpaCampos();
            LoadCboPlano();
            mskCpf.Focus();
        }
        private void LoadCboPlano()
        {
            cboPlano.Items.Add("AMIL");
            cboPlano.Items.Add("BRADESCO SAÚDE");
            cboPlano.Items.Add("BRADESCO SEGUROS");
            cboPlano.Items.Add("SINAN");
            cboPlano.Items.Add("UNIMED");
        }

        private void LimpaCampos()
        {
            btnCadastrar.IsEnabled = true;
            btnAlterar.IsEnabled = false;
            btnLocalizar.IsEnabled = true;
            btnExcluir.IsEnabled = false;
            btnCancelar.IsEnabled = false;

            txtId.Clear();
            txtNome.Clear();
            mskCpf.Clear();
            txtRg.Clear();
            mskdtaNascimento.Clear();
            mskTelefone.Clear();
            txtEmail.Clear();
            cboPlano.SelectedIndex = -1;
            txtNPlano.Clear();
            txtRua.Clear();
            txtNumero.Clear();
            txtBairro.Clear();
            txtCidade.Clear();
            txtEstado.Clear();
            mskCep_Leave.Clear();
        }

        private void btnBuscarCpf_Click(object sender, RoutedEventArgs e)
        {
            Paciente pac = new Paciente();
            pac.Cpf = mskCpf.Text;

            if (mskCpf.Text.Length == 11 || mskCpf.Text.Length == 14)
            {
                if (Valida.ValidarCPF(pac.Cpf))
                {
                    var p = PacienteDAO.BuscarPacientePorCpf(pac);
                    if (p == null)
                    {
                        //MessageBox.Show($"Informe um CPF Válido!");
                        MessageBox.Show($"CPF [ {pac.Cpf} ] não encontrado!");
                    }
                    else
                    {
                        txtId.Text = p.IdPaciente.ToString();
                        cboPlano.Text = p.NomePlano;
                        txtNPlano.Text = p.NumPlano;
                        txtNome.Text = p.Nome;
                        txtRg.Text = p.Rg;
                        mskdtaNascimento.Text = p.Nascimento;
                        mskTelefone.Text = p.Telefone;
                        txtEmail.Text = p.Email;
                        mskCep_Leave.Text = p.Cep;
                        txtRua.Text = p.Rua;
                        txtNumero.Text = p.Numero;
                        txtBairro.Text = p.Bairro;
                        txtCidade.Text = p.Cidade;
                        txtEstado.Text = p.Estado;

                        btnCadastrar.IsEnabled = false;
                        btnAlterar.IsEnabled = true;
                        btnExcluir.IsEnabled = true;
                        btnLocalizar.IsEnabled = true;
                        btnCancelar.IsEnabled = true;
                    }
                }
                else
                {
                    MessageBox.Show("CPF inválido.");
                }
            }

        }

        private void btnCadastrar_Click(object sender, RoutedEventArgs e)
        {
            //this.operacao = "inserir";
            //this.AlteraBotoes(2);
            pac.Nome = txtNome.Text;
            pac.Cpf = mskCpf.Text;
            pac.Rg = txtRg.Text;
            pac.Nascimento = mskdtaNascimento.Text;
            pac.Telefone = mskTelefone.Text;
            pac.Email = txtEmail.Text;
            pac.NomePlano = cboPlano.Text;
            pac.NumPlano = txtNPlano.Text;
            pac.Rua = txtRua.Text;
            pac.Numero = txtNumero.Text;
            pac.Bairro = txtBairro.Text;
            pac.Cidade = txtCidade.Text;
            pac.Estado = txtEstado.Text;
            pac.Cep = mskCep_Leave.Text;

            if (Valida.ValidarCPF(pac.Cpf))
            {
                if (PacienteDAO.CadastrarPaciente(pac))
                {
                    MessageBox.Show("Paciente cadastrado!");
                    LimpaCampos();
                    mskCpf.Focus();
                }
                else
                {
                    MessageBox.Show("Paciente já existe.");
                    LimpaCampos();
                    mskCpf.Focus();
                }
            }
            else
            {
                MessageBox.Show("CPF inválido.");
                LimpaCampos();
                mskCpf.Focus();
            }

        }

        private void AlteraBotoes(int op)
        {
            btnCadastrar.IsEnabled = false;
            btnAlterar.IsEnabled = false;
            btnLocalizar.IsEnabled = false;
            btnExcluir.IsEnabled = false;
            btnCancelar.IsEnabled = false;

            if (op == 1)
            {
                //ativar as opções iniciais
                btnCadastrar.IsEnabled = true;
                btnLocalizar.IsEnabled = true;
            }
            if (op == 2)
            {
                //inserir um valor
                btnCancelar.IsEnabled = true;
            }
            if (op == 3)
            {
                btnAlterar.IsEnabled = true;
                btnExcluir.IsEnabled = true;
            }
        }

        private void btnBuscaCep_Click(object sender, RoutedEventArgs e)
        {
            LocalizarCEP();
        }

        private void LocalizarCEP()
        {
            RestClient restClient = new RestClient(string.Format("https://viacep.com.br/ws/{0}/json/", mskCep_Leave.Text));
            RestRequest restRequest = new RestRequest(Method.GET);
            IRestResponse restResponse = restClient.Execute(restRequest);

            BuscaCep cepRetorno = new JsonDeserializer().Deserialize<BuscaCep>(restResponse);

            if (cepRetorno.cep is null)
            {
                MessageBox.Show("CEP não encontrado! ", "Atenção!", MessageBoxButton.OK, MessageBoxImage.Exclamation);
                mskCep_Leave.Clear();
                mskCep_Leave.Focus();
                return;
            }
            txtRua.Text = cepRetorno.logradouro;
            txtBairro.Text = cepRetorno.bairro;
            txtCidade.Text = cepRetorno.localidade;
            txtEstado.Text = cepRetorno.uf;
        }


        private void btnCancelar_Click(object sender, RoutedEventArgs e)
        {
            //this.AlteraBotoes(1);
            this.LimpaCampos();
        }


        private void btnFechar_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void btnCadastrarPaciente_Click(object sender, RoutedEventArgs e)
        {
            frmCadastrarPaciente cadastrarPaciente = new frmCadastrarPaciente();
            cadastrarPaciente.ShowDialog();
        }

        private void btnListarPaciente_Click(object sender, RoutedEventArgs e)
        {
            frmListarPaciente listarPaciente = new frmListarPaciente();
            listarPaciente.ShowDialog();
        }

        private void btnAlterar_Click(object sender, RoutedEventArgs e)
        {
            Paciente p = new Paciente();
            p.Cpf = mskCpf.Text;
            var pa = PacienteDAO.BuscarPacientePorCpf(p);
            if (pa != null)
            {
                pa.IdPaciente = Convert.ToInt32(txtId.Text);
                pa.Cpf = mskCpf.Text;
                pa.NomePlano = cboPlano.Text;
                pa.NumPlano = txtNPlano.Text;
                pa.Nome = txtNome.Text;
                pa.Rg = txtRg.Text;
                pa.Nascimento = mskdtaNascimento.Text;
                pa.Telefone = mskTelefone.Text;
                pa.Email = txtEmail.Text;
                pa.Cep = mskCep_Leave.Text;
                pa.Rua = txtRua.Text;
                pa.Numero = txtNumero.Text;
                pa.Bairro = txtBairro.Text;
                pa.Cidade = txtCidade.Text;
                pa.Estado = txtEstado.Text;


                PacienteDAO.AlterarPaciente(pa);

                MessageBox.Show("Cadastro do Paciente Atualizado!!", "Atualiza Paciente", MessageBoxButton.OK,
                                                                           MessageBoxImage.Information);
                LimpaCampos();
            }
        }
        private void btnExcluir_Click(object sender, RoutedEventArgs e)
        {
            ctx.Pacientes.Remove(pac);
            ctx.SaveChanges();
        }

        public string dtaConsulta
        {
            set { txtdtaConsult.Text = value; }
        }

        private void btnAgendarConsulta_Click(object sender, RoutedEventArgs e)
        {
            frmAgenda agendarConsulta = new frmAgenda();
            agendarConsulta.dtaAgendamento = txtdtaConsult.Text;
            agendarConsulta.nomePaciente = txtNome.Text;
            agendarConsulta.cpfPaciente = mskCpf.Text;
            agendarConsulta.planoPaciente = cboPlano.Text;
            agendarConsulta.ShowDialog();
            this.Close();
        }
    }
}