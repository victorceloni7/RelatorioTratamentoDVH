using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
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
using Microsoft.Win32;


namespace RelatorioDVH.Views
{
    /// <summary>
    /// Interaction logic for MainView.xaml
    /// </summary>
    /// 

    public partial class MainView : UserControl
    {
        public MainView()
        {
            InitializeComponent();
        }

        private void VerificaDVH_Click(object sender, RoutedEventArgs e)
        {

        }

        private void UserControl_Loaded(object sender, RoutedEventArgs e)
        {
            OpenFileDialog ofd = new OpenFileDialog();
            ofd.ShowDialog();
            ofd.FileName = @"C:\Users\Aluno\Downloads\Tratamento.csv";

            ArquivoCSV ArquivoTratamento = new ArquivoCSV();
            string[] TratamentoArray;
            DataTable dt = new DataTable();
            dt.Columns.Add("Estrutura", typeof(string));
            dt.Columns.Add("Constraints", typeof(string));
            dt.Columns.Add("Aceitavel", typeof(string));
            dt.Columns.Add("Limite de dose", typeof(string));

            using (StreamReader streamReader = new StreamReader(ofd.FileName))
            {
                while (!streamReader.EndOfStream)
                {
                    TratamentoArray = streamReader.ReadLine().Split(',');

                    ArquivoTratamento.Estrutura = TratamentoArray[0];
                    ArquivoTratamento.Constraints = TratamentoArray[1];
                    ArquivoTratamento.Aceitavel = TratamentoArray[2];
                    ArquivoTratamento.LimiteDose = TratamentoArray[3];

                    dt.Rows.Add(TratamentoArray);

                }
                DataView dv = new DataView(dt);
                dtGridView.ItemsSource = dv;
            }
        }
        
        private void print_Click(object sender, RoutedEventArgs e)
        {
            
            try
            {
                this.IsEnabled = false;
                print.Visibility = Visibility.Collapsed;
                PrintDialog printDialog = new PrintDialog();
                if (printDialog.ShowDialog().GetValueOrDefault(false))
                {
                    printDialog.PrintVisual(_Report, "Report");
                }

            }
            finally
            {
                this.IsEnabled = true;
                print.Visibility = Visibility.Visible;
            }
        }
    }
}
