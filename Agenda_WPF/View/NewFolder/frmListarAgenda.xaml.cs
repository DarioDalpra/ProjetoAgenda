using System.Windows;


namespace Agenda_WPF.Views
{
    /// <summary>
    /// Interaction logic for frmListarAgenda.xaml
    /// </summary>
    public partial class frmListarAgenda : Window
    {
        public frmListarAgenda()
        {
            InitializeComponent();
        }

        private void btnFechar_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
    }
}