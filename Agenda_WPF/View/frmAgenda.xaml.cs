using Agenda_WPF.DAL;
using Agenda_WPF.Model;
using System;
using System.Windows;
using Xceed.Wpf.Toolkit.PropertyGrid.Attributes;

namespace Agenda_WPF.View
{
    /// <summary>
    /// Interaction logic for frmListarAgenda.xaml
    /// </summary>
    public partial class frmAgenda : Window
    {
         private string operacao;
        //List<Paciente> pacientes = new List<Paciente>();

        public string dtaAgendamento
        {
            set { dtpDtaAgendamento.Text = value; }
        }
        public string nomePaciente
        {
            set { txtNomePaciente.Text = value; }
        }
        public string cpfPaciente
        {
            set { txtCpfPaciente.Text = value; }
        }
        public string planoPaciente
        {
            set { txtPlanoPaciente.Text = value; }
        }

        public frmAgenda()
        {
            InitializeComponent();
            LoadCombos();
        }

        private void AlteraBotoes(int op)
        {
            btnAgendar.IsEnabled = false;
            btnAlterar.IsEnabled = false;
            btnLocalizar.IsEnabled = false;
            btnExcluir.IsEnabled = false;
            btnCancelar.IsEnabled = false;

            if (op == 1)
            {
                //ativar as opções iniciais
                btnLocalizar.IsEnabled = true;
            }
            if (op == 2)
            {
                //inserir um valor
                btnCancelar.IsEnabled = true;
                btnAgendar.IsEnabled = true;
            }
            if (op == 3)
            {
                btnAlterar.IsEnabled = true;
                btnExcluir.IsEnabled = true;
            }
        }

        private void listaMedico()
        {
            cboMedico.ItemsSource = MedicoDAO.ListarMedicos();
            cboMedico.SelectedValuePath = "IdMedico";
            cboMedico.DisplayMemberPath = "Nome";
        }
        //private void listaMedico()
        //{
        //    cboMedico.ItemsSource = MedicoDAO.ListarMedicos();
        //    cboMedico.SelectedValuePath = "IdMedico";
        //    cboMedico.DisplayMemberPath = "Nome";
        //}

        private void cboMedico_SelectionChanged(object sender, System.Windows.Controls.SelectionChangedEventArgs e)
        {
            string especialidade;
            especialidade = cboMedico.SelectedValue.ToString();
            //if(Convert.ToInt32(especialidade) == cboMedico.SelectedIndex)
            //{
            txtEspecialidadeMedico.Text = especialidade;  //cboMedico.DisplayMemberPath = "Especialidade";
                                                          //}



        }

        private void LoadCombos()
        {
            listaMedico();

            cboHorario.Items.Add("09:00");
            cboHorario.Items.Add("09:15");
            cboHorario.Items.Add("09:30");
            cboHorario.Items.Add("09:45");
            cboHorario.Items.Add("10:00");
            cboHorario.Items.Add("10:15");
            cboHorario.Items.Add("10:30");
            cboHorario.Items.Add("10:45");
            cboHorario.Items.Add("11:00");
            cboHorario.Items.Add("11:15");
            cboHorario.Items.Add("11:30");
            cboHorario.Items.Add("11:45");
            cboHorario.Items.Add("14:00");
        }
        //private void LimpaCampos()
        //{

        //    txtNome.IsEnabled = true;
        //    txtCpf.IsEnabled = true;
        //    txtRg.IsEnabled = true;
        //    dtNascimento.IsEnabled = true;
        //    txtTelefone.IsEnabled = true;
        //    txtEmail.IsEnabled = true;
        //    cboPlano.IsEnabled = true;
        //    txtNumplano.IsEnabled = true;
        //    txtRua.IsEnabled = true;
        //    txtNumero.IsEnabled = true;
        //    txtBairro.IsEnabled = true;
        //    txtCidade.IsEnabled = true;
        //    txtEstado.IsEnabled = true;
        //    txtCep_Leave.IsEnabled = true;

        //    txtNome.Clear();
        //    txtCpf.Clear();
        //    txtRg.Clear();
        //    dtNascimento.Clear();
        //    txtTelefone.Clear();
        //    txtEmail.Clear();

        //    txtNumplano.Clear();
        //    txtRua.Clear();
        //    txtNumero.Clear();
        //    txtBairro.Clear();
        //    txtCidade.Clear();
        //    txtEstado.Clear();
        //    txtCep_Leave.Clear();
        //}

        private void btnCancelar_Click(object sender, RoutedEventArgs e)
        {
            this.AlteraBotoes(1);
            //  this.LimpaCampos();
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

        private void btnListarConsulta_Click(object sender, RoutedEventArgs e)
        {
            frmListarAgenda listarAgenda = new frmListarAgenda();
            listarAgenda.Show();
        }

        private void btnFechar_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }



    }

}