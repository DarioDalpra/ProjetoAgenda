using Agenda_WPF.View;
using Agenda_WPF.View.ViewModel;
using MaterialDesignThemes.Wpf;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace Agenda_WPF
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            
            

            var menuAgenda = new List<SubItem>();
            menuAgenda.Add(new SubItem("Cadastrar Agenda", new UcAgenda()));
            menuAgenda.Add(new SubItem("Listar Agenda", new UcListarAgenda()));
            
            var item0 = new ItemMenu("Agenda", menuAgenda, PackIconKind.Calendar);

            var menuPaciente = new List<SubItem>();
            menuPaciente.Add(new SubItem("Cadastrar Paciente", new UcCadastrarPaciente()));
            menuPaciente.Add(new SubItem("Listar Paciente", new UcListarPaciente()));
            var item1 = new ItemMenu("Paciente", menuPaciente, PackIconKind.People);

            var menuMedico = new List<SubItem>();
            menuMedico.Add(new SubItem("Cadastrar Médico", new UcCadastrarMedico()));
            menuMedico.Add(new SubItem("Listar Médico", new UcListarMedico()));
            menuMedico.Add(new SubItem("Listar Agenda", new UcListarAgenda()));
            menuMedico.Add(new SubItem("Listar Prontuario", new UcListarProntuario()));
            var item2 = new ItemMenu("Médico", menuMedico, PackIconKind.Medicine);

            var menuPlano= new List<SubItem>();
            menuPlano.Add(new SubItem("Cadastrar Plano", new UcCadastrarPlanoSaude()));
            menuPlano.Add(new SubItem("Listar Plano", new UcListarPlano()));
            var item3 = new ItemMenu("Plano", menuPlano, PackIconKind.LocalHospital);

            var menuUsuario = new List<SubItem>();
            menuUsuario.Add(new SubItem("Cadastrar Usuário", new UcCadastrarUsuario()));
            menuUsuario.Add(new SubItem("Listar Usuário", new UcListarUsuario()));
            var item4 = new ItemMenu("Usuário", menuUsuario, PackIconKind.User);

            
            Menu.Children.Add(new UserControlMenuItem(item0, this));
            Menu.Children.Add(new UserControlMenuItem(item1, this));
            Menu.Children.Add(new UserControlMenuItem(item2, this));
            Menu.Children.Add(new UserControlMenuItem(item3, this));
            Menu.Children.Add(new UserControlMenuItem(item4, this));



        }

        internal void SwitchScreen(object sender)
        {
            var screen = ((UserControl)sender);

            if(screen!=null)
            {
                StackPanelMain.Children.Clear();
                StackPanelMain.Children.Add(screen);
            }
        }
    }
}
