using Agenda_WPF.DAL;
using Agenda_WPF.Model;
using System.Linq;
using System.Windows;

namespace Agenda_WPF.View
{
    /// <summary>
    /// Interaction logic for frmListarPaciente.xaml
    /// </summary>
    public partial class frmListarPaciente : Window
    {
        private string operacao;
        public frmListarPaciente()
        {
            InitializeComponent();
        }

        private void btnSalvar_Click(object sender, RoutedEventArgs e)
        {
            Paciente p = new Paciente();
            p.Nome = txtNome.Text;
            p.Cpf = txtCpf.Text;
            p.Telefone = txtTelefone.Text;
            p.Email = txtEmail.Text;
            using (Context ctx = new Context())
            {
                if (operacao == "inserir")
                {
                    {
                        ctx.Pacientes.Add(p);
                        ctx.SaveChanges();
                    }
                }
                if (operacao == "alterar")
                {
                    {
                        ctx.Pacientes.Add(p);
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
                var consulta = ctx.Pacientes;
                dtgPacientes.ItemsSource = consulta.ToList();

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
            txtIdPaciente.IsEnabled = true;
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
            this.Close();
        }

        private void btn_CadastrarPaciente_Click(object sender, RoutedEventArgs e)
        {
            frmCadastrarPaciente cadastrarPaciente = new frmCadastrarPaciente();
            cadastrarPaciente.Show();
        }

        private void btn_ListarPaciente_Click(object sender, RoutedEventArgs e)
        {
            frmListarPaciente listarPaciente = new frmListarPaciente();
            listarPaciente.Show();
        }



    }
}