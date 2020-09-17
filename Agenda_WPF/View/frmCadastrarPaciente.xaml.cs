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
using System.Windows.Shapes;

namespace Agenda_WPF.View
{
    /// <summary>
    /// Interaction logic for frmCadastrarPaciente.xaml
    /// </summary>
    public partial class frmCadastrarPaciente : Window
    {
        private string operacao;
        public frmCadastrarPaciente()
        {
            InitializeComponent();
            LimpaCampos();
            LoadCboPlano();
            txtNome.Focus();
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
            btnFechar.IsEnabled = true;

            txtNome.Clear();
            txtCpf.Clear();
            txtRg.Clear();
            txtDtaNascimento.Clear();
            txtTelefone.Clear();
            txtEmail.Clear();
            cboPlano.SelectedIndex = -1;
            txtNPlano.Clear();
            txtRua.Clear();
            txtNumero.Clear();
            txtBairro.Clear();
            txtCidade.Clear();
            txtEstado.Clear();
            txtCep_Leave.Clear();
        }

        private void btnCadastrar_Click(object sender, RoutedEventArgs e)
        {
            //this.operacao = "inserir";
            //this.AlteraBotoes(2);
            Context ctx = SingletonContext.GetInstance();
            Paciente pac = new Paciente();
            pac.Nome = txtNome.Text;
            pac.Cpf = txtCpf.Text;
            pac.Rg = txtRg.Text;
            pac.Nascimento = txtDtaNascimento.Text;
            pac.Telefone = txtTelefone.Text;
            pac.Email = txtEmail.Text;
            pac.NomePlano = cboPlano.Text;
            pac.NumPlano = txtNPlano.Text;
            pac.Rua = txtRua.Text;
            pac.Numero = txtNumero.Text;
            pac.Bairro = txtBairro.Text;
            pac.Cidade = txtCidade.Text;
            pac.Estado = txtEstado.Text;
            pac.Cep = txtCep_Leave.Text;

            //if (operacao == "inserir")
            //{
            //    Context context = new Context();
            //    {
            //        context.Pacientes.Add(p);
            //        context.SaveChanges();
            //    }

            //}
            //if (operacao == "alterar")
            //{
            //    {
            //        ctx.Pacientes.Add(p);
            //        ctx.SaveChanges();
            //    }
            //}

            ////this.ListarDados();
            //this.AlteraBotoes(1);
            //this.LimpaCampos();

            if (Valida.ValidarCPF(pac.Cpf))
            {
                if (PacienteDAO.CadastrarPaciente(pac))
                {
                    MessageBox.Show("Paciente cadastrado!");
                    LimpaCampos();
                    txtNome.Focus();
                }
                else
                {
                    MessageBox.Show("Paciente já existe.");
                    txtNome.Focus();
                }
            }
            else
            {
                MessageBox.Show("CPF inválido.");
            }

        }



        //private void ListarDados(int op)
        //{
        //    this.ListarDados();
        //}
        //private void ListarDados()
        //{
        //    Context ctx = new Context();
        //    {
        //        var consulta = ctx.Pacientes;
        //        dgDados.ItemsSource = consulta.ToList();
        //    }
        //}

        //private void AlteraBotoes(int op)
        //{
        //    btnAlterar.IsEnabled = false;
        //    btnCadastrar.IsEnabled = false;
        //    btnExcluir.IsEnabled = false;
        //    btnCancelar.IsEnabled = false;
        //    btnLocalizar.IsEnabled = false;
        //    btnSalvar.IsEnabled = false;

        //    if (op == 1)
        //    {
        //        //ativar as opções iniciais
        //        btnCadastrar.IsEnabled = true;
        //        btnLocalizar.IsEnabled = true;
        //    }
        //    if (op == 2)
        //    {
        //        //inserir um valor
        //        btnCancelar.IsEnabled = true;
        //        btnSalvar.IsEnabled = true;
        //    }
        //    if (op == 3)
        //    {
        //        btnAlterar.IsEnabled = true;
        //        btnExcluir.IsEnabled = true;
        //    }
        //}

        //private void textCep_Leave(object sender, EventArgs e)
        //{
        //    LocalizarCEP();
        //}
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
            cadastrarPaciente.Show();
        }

        private void btnListarPaciente_Click(object sender, RoutedEventArgs e)
        {
            frmListarPaciente listarPaciente = new frmListarPaciente();
            listarPaciente.Show();
        }
    }

}