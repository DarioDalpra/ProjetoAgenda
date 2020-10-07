using Agenda_WPF.View;
using Agenda_WPF.ViewModel;
using MaterialDesignThemes.Wpf;
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

namespace Agenda_WPF.Views
{
    /// <summary>
    /// Interaction logic for frmTelaPrincipalMedico.xaml
    /// </summary>
    public partial class frmTelaPrincipalAdm : Window
    {
        public frmTelaPrincipalAdm()
        {
            InitializeComponent();

            var menuAgenda = new List<SubItem>();
            menuAgenda.Add(new SubItem("Cadastar "));
            menuAgenda.Add(new SubItem("Listar"));
            var item0 = new ItemMenu("Agenda", menuAgenda, PackIconKind.Calendar);

            var menuPaciente = new List<SubItem>();
            menuPaciente.Add(new SubItem("Cadastar "));
            menuPaciente.Add(new SubItem("Listar"));
            var item1 = new ItemMenu("Paciente", menuPaciente, PackIconKind.People);

            var menuMedico = new List<SubItem>();
            menuMedico.Add(new SubItem("Cadastar "));
            menuMedico.Add(new SubItem("Listar"));
            var item2 = new ItemMenu("Médico", menuMedico, PackIconKind.MedicalBag);

            var menuUsuario = new List<SubItem>();
            menuUsuario.Add(new SubItem("Cadastar "));
            menuUsuario.Add(new SubItem("Listar"));
            var item3 = new ItemMenu("Usupario", menuUsuario, PackIconKind.User);


            Menu.Children.Add(new UserControlMenuItem(item0));
            Menu.Children.Add(new UserControlMenuItem(item1));
            Menu.Children.Add(new UserControlMenuItem(item2));
            Menu.Children.Add(new UserControlMenuItem(item3));

        }


    }
}