using Agenda_WPF.DAL;
using Agenda_WPF.Model;
using System.Linq;
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
    /// Interaction logic for UcListarMedico.xaml
    /// </summary>
    public partial class UcListarMedico : UserControl
    {
        private string operacao;
        Medico m = new Medico();
        private Medico medico;
        public UcListarMedico()
        {
            InitializeComponent();
        }
        private void btnSalvar_Click(object sender, RoutedEventArgs e)
        {
            //Medico m = new Medico();
            m.Nome = txtNome.Text;
            m.Cpf = txtCpf.Text;
            m.Telefone = txtTelefone.Text;
            m.Email = txtEmail.Text;
            using (Context ctx = new Context())
            {
                if (operacao == "inserir")
                {
                    {
                        ctx.Medicos.Add(m);
                        ctx.SaveChanges();
                    }
                }
                if (operacao == "alterar")
                {
                    {
                        ctx.Medicos.Add(m);
                        ctx.SaveChanges();
                    }
                }
                this.ListarDados();
                this.AlteraBotoes(1);
                this.LimpaCampos();
            }
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
                dtgMedicos.ItemsSource = consulta.ToList();

                //dtgPacientes.Columns[0].Header = "id";
                //dtgPacientes.Columns[1].Header = "Nome";

            }
        }
        private void AlteraBotoes(int op)
        {
            btnAlterar.IsEnabled = false;
            btnCadastrar.IsEnabled = false;
            btnExcluir.IsEnabled = false;
            btnCancelar.IsEnabled = false;
            btnLocalizar.IsEnabled = false;

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
        private void LimpaCampos()
        {
            txtIdMedico.IsEnabled = true;
            txtNome.IsEnabled = true;
            txtCpf.IsEnabled = true;
            txtTelefone.IsEnabled = true;
            txtEmail.IsEnabled = true;

            txtNome.Clear();
            txtCpf.Clear();
            txtTelefone.Clear();
            txtEmail.Clear();


        }

        private void btnCancelar_Click(object sender, RoutedEventArgs e)
        {
            this.AlteraBotoes(1);
            this.LimpaCampos();
        }

        private void btnInserir_Click(object sender, RoutedEventArgs e)
        {
            this.operacao = "inserir";
            this.AlteraBotoes(2);
        }

        private void btn_Fechar_Click(object sender, RoutedEventArgs e)
        {
           // this.Close();
        }


        private void btn_CadastrarPaciente_Click(object sender, RoutedEventArgs e)
        {
            UcCadastrarPaciente cadastrarPaciente = new UcCadastrarPaciente();
          //  cadastrarPaciente.Show();
        }

        private void btnAlterar_Click(object sender, RoutedEventArgs e)
        {
            if (medico != null)
            {
                medico.Nome = txtNome.Text;
                medico.Cpf = txtCpf.Text;
                medico.Telefone = txtTelefone.Text;



                MedicoDAO.AlterarMedico(medico);
                MessageBox.Show("O médico foi alterado com sucesso!!!", "Agenda_Medica_WPF", MessageBoxButton.OK, MessageBoxImage.Error);

            }
            else
            {
                MessageBox.Show("O médico não foi alterado!!!", "Agenda_Medica_WPF", MessageBoxButton.OK, MessageBoxImage.Error);

            }
            LimpaCampos();
        }
        private void btn_ListarPaciente_Click(object sender, RoutedEventArgs e)
        {
            UcListarPaciente listarPaciente = new UcListarPaciente();
            //listarPaciente.Show();
        }

        private void btnExcluir_Click(object sender, RoutedEventArgs e)
        {
            if (medico != null)
            {
                MedicoDAO.Remover(medico);
                MessageBox.Show("O médico foi removido com sucesso!!!", "Agenda Medica WPF", MessageBoxButton.OK, MessageBoxImage.Error);

            }
            else
            {
                MessageBox.Show("O médico não foi removido!!!", "Agenda Medica WPF", MessageBoxButton.OK, MessageBoxImage.Error);

            }
            LimpaCampos();
        }
    }
}
