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
    /// Interaction logic for UcLogin.xaml
    /// </summary>
    public partial class UcLogin : UserControl
    {
        public UcLogin()
        {
            InitializeComponent();
            txtEmailLogin.Focus();
        }
        Usuario u = new Usuario();
        private void btnLogin_Click(object sender, RoutedEventArgs e)
        {
            u.Email = txtEmailLogin.Text;

            var usr = UsuarioDAO.ValidaLogin(u.Email);
            if (usr == null)
            {
                MessageBox.Show($"Informe um LOGIN válido!");
            }
            else if (usr.Email == txtEmailLogin.Text && usr.Senha == pwdSenhaLogin.Password)
            {
                if (usr.Administrador == true)
                {
                    //   MainWindow principal = new MainWindow(usr.Nome);
                    //principal.Show();
                    //this.Close();

                }
                else if (usr.Medico == true)
                {
            //        UcTelaPrincipalMedico viewMedico = new UcTelaPrincipalMedico(usr.Nome);
                //    viewMedico.Show();
                   // this.Close();
                }
                else
                {
             //       UcTelaPrincipalRecepcionista viewAtendente = new UcTelaPrincipalRecepcionista(usr.Nome);
              //      viewAtendente.Show();
              //      this.Close();
                }
            }
            else
            {
                MessageBox.Show($"Usuário e ou Senha Inválido(a)!!");
            }
            //frmTelaPrincipalRecepcionista atendente = new frmTelaPrincipalRecepcionista();
            //atendente.ShowDialog();
        }

        private void btnCancelar_Click(object sender, RoutedEventArgs e)
        {
           // this.Close();
        }

        private void txtEmailLogin_TextChanged(object sender, System.Windows.Controls.TextChangedEventArgs e)
        {
            string log = "admin1";
            if (txtEmailLogin.Text == log)
            {
                txtEmailLogin.Text = ($"{log}@agenda.com.br");
                pwdSenhaLogin.Focus();
            }
        }
    }
}