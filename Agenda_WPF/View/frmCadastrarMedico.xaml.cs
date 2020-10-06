using Agenda_WPF.DAL;
using Agenda_WPF.Model;
using Agenda_WPF.Utils;
using Agenda_WPF.View;
using RestSharp;
using RestSharp.Serialization.Json;
using System;
using System.Windows;

namespace Agenda_WPF.Views
{
    /// <summary>
    /// Interaction logic for frmCadastrarMedico.xaml
    /// </summary>
    public partial class frmCadastrarMedico : Window
    {
        Context ctx = SingletonContext.GetInstance();

        private string operacao;

        public frmCadastrarMedico()
        {
            InitializeComponent();
            LimpaCampos();
            mskCpf.Focus();
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
            txtCrm.Clear();
            txtEspecialidade.Clear();
            txtRua.Clear();
            txtNumero.Clear();
            txtBairro.Clear();
            txtCidade.Clear();
            txtEstado.Clear();
            mskCep_Leave.Clear();

        }

        private void btnBuscarCpf_Click(object sender, RoutedEventArgs e)
        {
            Medico med = new Medico();
            med.Cpf = mskCpf.Text;

            if (mskCpf.Text.Length == 11 || mskCpf.Text.Length == 14)
            {
                if (Valida.ValidarCPF(med.Cpf))
                {
                    var m = MedicoDAO.BuscarMedicoPorCpf(med);
                    if (m == null)
                    {
                        //MessageBox.Show($"Informe um CPF Válido!");
                        MessageBox.Show($"CPF [ {med.Cpf} ] não encontrado!");
                    }
                    else
                    {
                        txtId.Text = m.IdMedico.ToString();
                        txtCrm.Text = m.Crm;
                        txtEspecialidade.Text = m.Especialidade;
                        txtNome.Text = m.Nome;
                        txtRg.Text = m.Rg;
                        mskdtaNascimento.Text = m.Nascimento;
                        mskTelefone.Text = m.Telefone;
                        txtEmail.Text = m.Email;
                        mskCep_Leave.Text = m.Cep;
                        txtRua.Text = m.Rua;
                        txtNumero.Text = m.Numero;
                        txtBairro.Text = m.Bairro;
                        txtCidade.Text = m.Cidade;
                        txtEstado.Text = m.Estado;

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
            Medico med = new Medico();
            med.Nome = txtNome.Text;
            med.Cpf = mskCpf.Text;
            med.Rg = txtRg.Text;
            med.Nascimento = mskdtaNascimento.Text;
            med.Telefone = mskTelefone.Text;
            med.Email = txtEmail.Text;
            med.Crm = txtCrm.Text;
            med.Especialidade = txtEspecialidade.Text;
            med.Rua = txtRua.Text;
            med.Numero = txtNumero.Text;
            med.Bairro = txtBairro.Text;
            med.Cidade = txtCidade.Text;
            med.Estado = txtEstado.Text;
            med.Cep = mskCep_Leave.Text;

            if (Valida.ValidarCPF(med.Cpf))
            {
                if (MedicoDAO.CadastrarMedico(med))
                {
                    MessageBox.Show("Médico cadastrado!");
                    LimpaCampos();
                    txtNome.Focus();
                }
                else
                {
                    MessageBox.Show("Médico já existe.");
                    txtNome.Focus();
                }
            }
            else
            {
                MessageBox.Show("CPF inválido.");
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

        private void btnBuscarCep_Click(object sender, RoutedEventArgs e)
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
            this.AlteraBotoes(1);
            this.LimpaCampos();
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

        private void btnAlterar_Click(object sender, RoutedEventArgs e)
        {
            Medico m = new Medico();
            m.Cpf = mskCpf.Text;
            var me = MedicoDAO.BuscarMedicoPorCpf(m);
            if (me != null)
            {
                me.IdMedico = Convert.ToInt32(txtId.Text);
                me.Nome = txtNome.Text;
                me.Cpf = mskCpf.Text;
                me.Rg = txtRg.Text;
                me.Nascimento = mskdtaNascimento.Text;
                me.Telefone = mskTelefone.Text;
                me.Email = txtEmail.Text;
                me.Crm = txtCrm.Text;
                me.Especialidade = txtEspecialidade.Text;
                me.Rua = txtRua.Text;
                me.Numero = txtNumero.Text;
                me.Bairro = txtBairro.Text;
                me.Cidade = txtCidade.Text;
                me.Estado = txtEstado.Text;
                me.Cep = mskCep_Leave.Text;

                MedicoDAO.AlterarMedico(me);

                MessageBox.Show("Cadastro do Médico Atualizado!!", "Atualiza Médico", MessageBoxButton.OK,
                                                                           MessageBoxImage.Information);
                LimpaCampos();
            }


        }

        private void btnExcluir_Click(object sender, RoutedEventArgs e)
        {
            Medico med = new Medico();
            ctx.Medicos.Remove(med);
            ctx.SaveChanges();
        }
    }

}