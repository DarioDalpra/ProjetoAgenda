using Agenda_WPF.Model;
using Agenda_WPF.View;
using MaterialDesignThemes.Wpf;
using System.Collections.Generic;
using System.Windows;
using System.Windows.Controls;

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

            var menuPaciente = new List<SubItem>();
            menuPaciente.Add(new SubItem("Cadastrar Paciente", new UserControlPaciente()));
            menuPaciente.Add(new SubItem("Listar Paciente", new UserControlPaciente()));
            menuPaciente.Add(new SubItem("Ataulizar Cadastro"));
            var item1 = new ItemMenu("Paciente", menuPaciente, PackIconKind.Register);

            var menuMedico = new List<SubItem>();
            menuMedico.Add(new SubItem("Cadastrar Médico", new UserControlMedico()));
            menuMedico.Add(new SubItem("Listar Médicos"));
            menuMedico.Add(new SubItem("Ataulizar Cadastro"));
            var item2 = new ItemMenu("Médico", menuMedico, PackIconKind.FileReport);

            var menuAgenda = new List<SubItem>();
            menuAgenda.Add(new SubItem("Registrar Agenda", new UserControlAgenda()));
            menuAgenda.Add(new SubItem("Listar Agenda"));
            menuAgenda.Add(new SubItem("Alterar Agenda"));
            var item3 = new ItemMenu("Agenda", menuAgenda, PackIconKind.Schedule);

            var menuPlano = new List<SubItem>();
            menuPlano.Add(new SubItem("Registrar Plano", new UserControlPlano()));
            menuPlano.Add(new SubItem("Listar Plano"));
            menuPlano.Add(new SubItem("Atualizar Plano"));
            var item4 = new ItemMenu("Plano", menuPlano, PackIconKind.Schedule);



            Menu.Children.Add(new UserControlMenuItem(item1, this));
            Menu.Children.Add(new UserControlMenuItem(item2, this));
            Menu.Children.Add(new UserControlMenuItem(item3, this));
            Menu.Children.Add(new UserControlMenuItem(item4, this));
            

        }

        internal void SwitchScreen(object sender)
        {
            var screen = ((UserControl)sender);

            if (screen != null)
            {
                StackPanelMain.Children.Clear();
                StackPanelMain.Children.Add(screen);
            }
        }
    }
}
