using Agenda_WPF.DAL;
using Agenda_WPF.Model;
using Agenda_WPF.Utils;
using RestSharp;
using RestSharp.Serialization.Json;
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
    /// Interaction logic for frmCadastrarUsuario.xaml
    /// </summary>
  
        public partial class frmCadastrarUsuario : Window
        {
            public frmCadastrarUsuario()
            {
                InitializeComponent();
                txtNomeUsuario.Focus();
                LimpaCampos();
            }

            private void LimpaCampos()
            {
                btnCadastrar.IsEnabled = true;
                btnAlterar.IsEnabled = false;
                btnLocalizar.IsEnabled = true;
                btnExcluir.IsEnabled = false;
                btnFechar.IsEnabled = true;

                txtNomeUsuario.Clear();
                txtCpfUsuario.Clear();
                txtEmailUsuario.Clear();
                pwdSenhaUsuario.Clear();
                chkAdministrador.IsChecked = false;
                chkMedico.IsChecked = false;
                chkAtendente.IsChecked = false;

            }

            private void btnCadastrar_Click(object sender, RoutedEventArgs e)
            {
                Context ctx = SingletonContext.GetInstance();
                Usuario usr = new Usuario();
                usr.Nome = txtNomeUsuario.Text;
                usr.Cpf = txtCpfUsuario.Text;
                usr.Email = txtEmailUsuario.Text;
                usr.Senha = pwdSenhaUsuario.Password;

                if (chkAdministrador.IsChecked == true)
                {
                    usr.Administrador = chkAdministrador.IsChecked.Value;
                }

                if (chkMedico.IsChecked == true)
                {
                    usr.Medico = chkMedico.IsChecked.Value;
                }

                if (chkAtendente.IsChecked == true)
                {
                    usr.Atendente = chkAtendente.IsChecked.Value;
                }

                if (Valida.ValidarCPF(usr.Cpf))
                {
                    if (UsuarioDAO.CadastrarUsuario(usr))
                    {
                        MessageBox.Show("Usuário cadastrado!");
                        LimpaCampos();
                        txtNomeUsuario.Focus();
                    }
                    else
                    {
                        MessageBox.Show("Usuário já existe.");
                        txtNomeUsuario.Focus();
                    }
                }
                else
                {
                    MessageBox.Show("CPF inválido.");
                }
            }

            private void btnBuscarUsuario_Click(object sender, RoutedEventArgs e)
            {
                frmListarUsuario listarUsuarios = new frmListarUsuario();
                listarUsuarios.Show();
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

            private void btnCancelar_Click(object sender, RoutedEventArgs e)
            {

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
        }
    }