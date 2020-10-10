using Agenda_WPF.DAL;
using Agenda_WPF.Model;
using Agenda_WPF.Utils;
using RestSharp;
using RestSharp.Serialization.Json;
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
    /// Interaction logic for UcCadastrarPaciente.xaml
    /// </summary>
    public partial class UcCadastrarPaciente : UserControl
    {
        public UcCadastrarPaciente()
        {
            InitializeComponent();
        }
        Context ctx = SingletonContext.GetInstance();
        //Paciente pac = new Paciente();
        private Paciente pac;
        private double imc = 0;
        

        // ================  INICIO MÉTODOS   =================
        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            LimpaCampos();
            LoadCboPlano();
            mskCpf.Focus();
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
        private void LoadCboPlano()
        {
            cboPlano.ItemsSource = PlanoSaudeDAO.ListarPlanoSaude();
            cboPlano.SelectedValuePath = "Id";
            cboPlano.DisplayMemberPath = "Plano";
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
            txtPeso.Clear();
            txtAltura.Clear();
            mskdtaNascimento.Clear();
            mskTelefone.Clear();
            mskCelular.Clear();
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
            var p = new Paciente();
            p.Cpf = mskCpf.Text;

            if (mskCpf.Text.Length == 11 || mskCpf.Text.Length == 14)
            {
                if (Valida.ValidarCPF(p.Cpf))
                {
                    pac = PacienteDAO.BuscarPacientePorCpf(p);
                    if (pac == null)
                    {
                        //MessageBox.Show($"Informe um CPF Válido!");
                        MessageBox.Show($"CPF [ {p.Cpf} ] não encontrado!");
                    }
                    else
                    {
                        txtId.Text = pac.IdPaciente.ToString();
                        cboPlano.Text = pac.NomePlano;
                        txtNPlano.Text = pac.NumPlano;
                        txtNome.Text = pac.Nome;
                        txtRg.Text = pac.Rg;
                        txtPeso.Text = pac.Peso.ToString();
                        txtAltura.Text = pac.Altura.ToString();
                        imc = ((Double.Parse(pac.Peso.ToString()) * Double.Parse(pac.Peso.ToString()) / Double.Parse(pac.Altura.ToString())));

                        lblImc.Content = $"IMC: {imc}";

                        mskTelefone.Text = pac.Telefone;
                        mskCelular.Text = pac.Celular;
                        txtEmail.Text = pac.Email;
                        mskCep_Leave.Text = pac.Cep;
                        txtRua.Text = pac.Rua;
                        txtNumero.Text = pac.Numero;
                        txtBairro.Text = pac.Bairro;
                        txtCidade.Text = pac.Cidade;
                        txtEstado.Text = pac.Estado;

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
        public string dtaConsulta
        {
            set { txtdtaConsult.Text = value; }
        }
        private void AgendarConsulta()
        {
            UcAgenda agendarConsulta = new UcAgenda();
            agendarConsulta.dtaAgendamento = txtdtaConsult.Text;
            agendarConsulta.IdPaciente = txtId.Text;
            agendarConsulta.nomePaciente = txtNome.Text;
            agendarConsulta.cpfPaciente = mskCpf.Text;
            agendarConsulta.IdplanoPaciente = cboPlano.Text;
            agendarConsulta.planoPaciente = cboPlano.Text;
            //agendarConsulta.ShowDialog();
            //this.Close();
        }
        private void CadastrarPaciente()
        {
            pac = new Paciente();
            pac.NomePlano = cboPlano.Text;
            pac.NumPlano = txtNPlano.Text;
            pac.Nome = txtNome.Text;
            pac.Cpf = mskCpf.Text;
            pac.Rg = txtRg.Text;
            pac.Peso = Convert.ToDouble(txtPeso.Text);
            pac.Altura = Convert.ToDouble(txtAltura.Text);
            pac.Altura = (Convert.ToDouble(txtPeso.Text) * Convert.ToDouble(txtPeso.Text)) / Convert.ToDouble(txtAltura.Text);
            pac.Nascimento = mskdtaNascimento.Text;
            pac.Telefone = mskTelefone.Text;
            pac.Celular = mskCelular.Text;
            pac.Email = txtEmail.Text;
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
                    MessageBox.Show("Paciente cadastrado!", "AGENDA MÉDICO - Cadastro Paciente",
                        MessageBoxButton.OK, MessageBoxImage.Information);
                    LimpaCampos();
                    mskCpf.Focus();
                }
                //MessageBox.Show("Agende a consulta do paciente!");
                //if (MessageBox.Show("Paciente cadastrado, deseja limpar os campos?", "Cadastro",
                //                    MessageBoxButton.YesNo, MessageBoxImage.Information)
                //                    == MessageBoxResult.Yes)
                //{
                //    LimpaCampos();
                //    mskCpf.Focus();
                //}
                //MessageBox.Show("Agende a consulta do paciente!");
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
        private void AlterarPaciente()
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
                pa.Peso = Convert.ToDouble(txtPeso.Text);
                pa.Altura = Convert.ToDouble(txtAltura.Text);
                pa.Altura = (Convert.ToDouble(txtPeso.Text) * Convert.ToDouble(txtPeso.Text)) / Convert.ToDouble(txtAltura.Text);
                pa.Nascimento = mskdtaNascimento.Text;
                pa.Telefone = mskTelefone.Text;
                pa.Celular = mskCelular.Text;
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
        private void RemoverPaciente()
        {
            if (pac != null)
            {
                PacienteDAO.Remover(pac);
                MessageBox.Show("O Paciente foi removido!", "AGENDA MÉDICA_WPF",
                    MessageBoxButton.OK, MessageBoxImage.Error);
            }
            else
            {
                MessageBox.Show("O Paciente não foi removido!", "AGENDA MÉDICA_WPF",
                    MessageBoxButton.OK, MessageBoxImage.Error);
            }
            LimpaCampos();
        }



        // ================ FIM MÉTODOS   =================

        private void btnBuscaCep_Click(object sender, RoutedEventArgs e)
        {
            LocalizarCEP();
        }
        private void btnCadastrar_Click(object sender, RoutedEventArgs e)
        {
            CadastrarPaciente();
        }
        private void btnAlterar_Click(object sender, RoutedEventArgs e)
        {
            AlterarPaciente();
        }
        private void btnListarPaciente_Click(object sender, RoutedEventArgs e)
        {
            UcListarPaciente listarPaciente = new UcListarPaciente();
        //    listarPaciente.ShowDialog();
        }
        private void btnCancelar_Click(object sender, RoutedEventArgs e)
        {
            //this.AlteraBotoes(1);
            this.LimpaCampos();
        }
        private void btnFechar_Click(object sender, RoutedEventArgs e)
        {
          //  UcTelaPrincipalRecepcionista atendente = new UcTelaPrincipalRecepcionista();
            //atendente.ShowDialog();
          //  this.Close();
        }
        private void btnAgendarConsulta_Click(object sender, RoutedEventArgs e)
        {
            AgendarConsulta();
            //UcTelaPrincipalRecepcionista atendente = new UcTelaPrincipalRecepcionista();
            //atendente.ShowDialog();
            //this.Close();

        }
        private void btnListarConsulta_Click(object sender, RoutedEventArgs e)
        {
            //frmListarConsulta listarConsulta = new frmListarConsulta();
            //listarConsulta.showDialog();
        }
        private void btnExcluir_Click(object sender, RoutedEventArgs e)
        {
            RemoverPaciente();
        }

        private void txtImc_TextChanged(object sender, System.Windows.Controls.TextChangedEventArgs e)
        {

        }
    }
}
 
