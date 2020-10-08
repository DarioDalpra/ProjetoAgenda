
using Agenda_WPF.DAL;
using Agenda_WPF.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows;

namespace Agenda_WPF.Views
{
    /// <summary>
    /// Interaction logic for frmListarPaciente.xaml
    /// </summary>
    public partial class frmListarPaciente : Window
    {
        private string operacao;
        private Paciente paciente;
        private List<dynamic> itens = new List<dynamic>();
        private double imc = 0;
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
            p.Altura = paciente.Altura;
            p.Peso = paciente.Peso;
            p.Celular = paciente.Celular;


            using Context ctx = new Context();
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

        private void PopularDataGrid(Paciente paciente)
        {
            itens.Add(new
            {
                Nome = paciente.Nome,
                Peso = Convert.ToDouble(paciente.Peso),
                Altura = Convert.ToDouble(paciente.Altura),
                Imc = (Convert.ToDouble(paciente.Peso)* Convert.ToDouble(paciente.Peso))/ Convert.ToDouble(paciente.Altura),
                Telefone = paciente.Telefone,
                Celular = paciente.Celular,
                Email = paciente.Email,
                NomePlano = paciente.NomePlano,





               
            });
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
            txtEmail.IsEnabled = true;
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

        private void Btn_CadastrarPaciente_Click(object sender, RoutedEventArgs e)
        {
            frmCadastrarPaciente cadastrarPaciente = new frmCadastrarPaciente();
            cadastrarPaciente.Show();
        }

        private void btn_ListarPaciente_Click(object sender, RoutedEventArgs e)
        {
            frmListarPaciente listarPaciente = new frmListarPaciente();
            listarPaciente.Show();
        }
        private void btn_Excluir_Click(object sender, RoutedEventArgs e)
        {
            if (paciente != null)
            {
                PacienteDAO.Remover(paciente);
                MessageBox.Show("O paciente foi removido com sucesso!!!", "Agenda Medica WPF", MessageBoxButton.OK, MessageBoxImage.Error);

            }
            else
            {
                MessageBox.Show("O paciente não foi removido!!!", "Agenda Medica WPF", MessageBoxButton.OK, MessageBoxImage.Error);

            }
            LimpaCampos();
        }
        private void btn_CadastrarPaciente_Click(object sender, RoutedEventArgs e)
        {
            frmCadastrarPaciente cadastrarPaciente = new frmCadastrarPaciente();
            cadastrarPaciente.Show();
        }

       
        private void btn_Localizar_Click(object sender, RoutedEventArgs e)
        {
             if (!string.IsNullOrWhiteSpace(txtNome.Text))
                {
                    paciente = PacienteDAO.BuscarPacientePorNome(txtNome.Text);
                    if (paciente != null)
                    {

                        btnCadastrar.IsEnabled = false;
                        btnAlterar.IsEnabled = true;
                        btnExcluir.IsEnabled = true;

                    txtIdPaciente.Text = paciente.IdPaciente.ToString();
                    txtNome.Text = paciente.Nome;
                    txtCpf.Text = paciente.Cpf;
                    txtTelefone.Text = paciente.Telefone;
                    txtEmail.Text = paciente.Email;



                    }
                    else
                    {
                        MessageBox.Show("Esse paciente não existe!!!", "Vendas WPF",
                            MessageBoxButton.OK, MessageBoxImage.Error);
                        LimpaCampos();
                    }
                }
                else
                {
                    MessageBox.Show("Preencha o campo nome!!!", "Vendas WPF",
                        MessageBoxButton.OK, MessageBoxImage.Error);
                }
            

        }

        private void btn_Alterar_Click(object sender, RoutedEventArgs e)
        {
            if (paciente != null)
            {
                paciente.Nome = txtNome.Text;
                paciente.Cpf = txtCpf.Text;
                paciente.Telefone = txtTelefone.Text;
              



                PacienteDAO.AlterarPaciente(paciente);
                MessageBox.Show("O médico foi alterado com sucesso!!!", "Agenda_Medica_WPF", MessageBoxButton.OK, MessageBoxImage.Error);

            }
            else
            {
                MessageBox.Show("O médico não foi alterado!!!", "Agenda_Medica_WPF", MessageBoxButton.OK, MessageBoxImage.Error);

            }
            LimpaCampos();

        }
    }
}