using Agenda_WPF.DAL;
using Agenda_WPF.Model;
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
    /// Interaction logic for UcAgenda.xaml
    /// </summary>
    public partial class UcAgenda : UserControl
    {
        public UcAgenda()
        {
            InitializeComponent();
            LoadCombos();
        }
        Agenda ag = new Agenda();

        //======== INÍCIO DOS CONSTRUTORES =============
        public string dtaAgendamento
        {
            set { dtpDtaAgendamento.Text = value; }
        }
        public string IdPaciente
        {
            set { txtNPac.Text = value; }
        }
        public string nomePaciente
        {
            set { txtNomePaciente.Text = value; }
        }
        public string IdcpfPaciente
        {
            set { txtCpfPac.Text = value; }
        }
        public string cpfPaciente
        {
            set { txtCpfPaciente.Text = value; }
        }
        public string IdplanoPaciente
        {
            set { txtPlanoPac.Text = value; }
        }
        public string planoPaciente
        {
            set { txtPlanoPaciente.Text = value; }
        }

        //======== FIM DOS CONSTRUTORES =============
        

        //======== INÍCIO DOS METODOS =============
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
        private void ListaMedico()
        {
            //Carregar os dados dos Médicos
            cboMedico.ItemsSource = MedicoDAO.ListarMedicos();
            cboMedico.SelectedValuePath = "IdMedico";
            cboMedico.DisplayMemberPath = "Nome";
        }
        private void LoadCombos()
        {
            ListaMedico();

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
        private void cboMedico_SelectionChanged(object sender, System.Windows.Controls.SelectionChangedEventArgs e)
        {
            if ((cboMedico.SelectedValuePath = "IdMedico") != null)
            {
                string valueNMed = "";
                string valueEspecialidade = "";
                if (cboMedico.SelectedValue != null)
                    valueNMed = cboMedico.SelectedValue.ToString();
                if (cboMedico.SelectedItem != null)
                    valueEspecialidade = cboMedico.SelectedItem.ToString();
                txtNMed.Text = valueNMed;
                txtEspecMed.Text = valueEspecialidade;
                txtEspecialidadeMedico.Text = valueEspecialidade;
            }
        }
        private void LimpaCampos()
        {
            txtIdConsulta.Clear();
            dtpDtaAgendamento.Text = "";
            cboHorario.Text = "";
            txtNomePaciente.Clear();
            txtCpfPaciente.Clear();
            txtPlanoPaciente.Clear();
            cboMedico.Text = "";
            txtEspecialidadeMedico.Clear();
        }
        private void AgendarConsulta()
        {
            DateTime data = dtpDtaAgendamento.DisplayDate;
            string hora = cboHorario.Text;
            string plano = txtPlanoPaciente.Text;
            int idMed = (int)cboMedico.SelectedValue;
            int idPac = Convert.ToInt32(txtNPac.Text);
            ag.DataAgendada = data;
            ag.HoraAgendada = hora;
            ag.Paciente = PacienteDAO.BuscarPacientePorId(idPac);
            ag.Cpf = PacienteDAO.BuscarPacientePorId(idPac);
            ag.Plano = plano;
            ag.Medico = MedicoDAO.BuscarMedicoPorId(idMed);
            ag.Especialidade = MedicoDAO.BuscarMedicoPorId(idMed);

            string msgCadastrou = AgendaDAO.CadastrarAgenda(ag);
            if (msgCadastrou == null)
            {
                ag = new Agenda();
                MessageBox.Show("Consulta agendada!");
              //  this.Close();
            }
            else
            {
                MessageBox.Show(msgCadastrou);
            }
        }

        //======== FIM DOS METODOS =============

        private void btnFechar_Click(object sender, RoutedEventArgs e)
        {
           // this.Close();
        }
        private void btnAgendar_Click(object sender, RoutedEventArgs e)
        {
            AgendarConsulta();
            //LimpaCampos();
        }
        private void btnListarConsulta_Click(object sender, RoutedEventArgs e)
        {
            UcListarAgenda listarAgenda = new UcListarAgenda();
           // listarAgenda.Show();
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
        private void btnCancelar_Click(object sender, RoutedEventArgs e)
        {
            //this.AlteraBotoes(1);
            LimpaCampos();
            //this.Close();
        }
    }
}