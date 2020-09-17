using Agenda_WPF.DAL;
using Agenda_WPF.Model;
using Agenda_WPF.Utils;
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
    /// Interaction logic for frmCadastrarMedico.xaml
    /// </summary>
    public partial class frmCadastrarMedico : Window
    {
        private string operacao;
        public frmCadastrarMedico()
        {
            InitializeComponent();
            LimpaCampos();
            txtNome.Focus();
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
            txtCrm.Clear();
            txtTelefone.Clear();
            txtEmail.Clear();
            txtEspecialidade.Clear();

        }
        private void btnSalvar_Click(object sender, RoutedEventArgs e)
        {
            using (Context ctx = new Context())
            {
                Medico m = new Medico();
                m.NomeMedico = txtNome.Text;
                m.Cpf = txtCpf.Text;
                m.Crm = txtCrm.Text;
                m.Telefone = txtTelefone.Text;
                m.Email = txtEmail.Text;
                m.Especialidade = txtEspecialidade.Text;

                if (operacao == "inserir")
                {
                    Context context = new Context();
                    {
                        context.Medicos.Add(m);
                        context.SaveChanges();
                    }

                }
                if (operacao == "alterar")
                {
                    {
                        ctx.Medicos.Add(m);
                        ctx.SaveChanges();
                    }
                }

                //this.ListarDados();
                this.AlteraBotoes(1);
                this.LimpaCampos();
            }


        }
        private void btnInserir_Click(object sender, RoutedEventArgs e)
        {
            //this.operacao = "inserir";
            //this.AlteraBotoes(2);
            Context ctx = new Context();
            Medico med = new Medico();

            med.NomeMedico = txtNome.Text;
            med.Cpf = txtCpf.Text;
            med.Crm = txtCrm.Text;
            med.Especialidade = txtEspecialidade.Text;
            med.Telefone = txtTelefone.Text;
            med.Email = txtEmail.Text;

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
    }

}