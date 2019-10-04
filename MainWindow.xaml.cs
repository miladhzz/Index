using Index.Models;
using System;
using System.Collections.Generic;
using System.Data.OleDb;
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

namespace Index
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void HelloWorldButton_Click(object sender, RoutedEventArgs e)
        {
            using(var db = new IndexDbContext())
            {
                var word1 = new Word()
                {
                    Text = "t1",
                    Role = "N",
                    Root = "Rooot",
                };
                var word = new Word()
                {
                    Text = "t1",
                    Role = "N",
                    Root = "Rooot",
                    SubWords = new List<Word>()
                    {
                        word1
                    }
                };
                
                var sentence = new Sentence()
                {
                    Dataset_version = "1",
                    Generator = "ge",
                    News_uniqe_id = "n1",
                    Sentence_order = 1,
                    Sentence_id = "111",
                    Date_time = "Date",
                    Text ="Testst", 
                    Words =new List<Word>()
                    {
                        word,
                        word1
                    }
                };
               
                var dataset = new Dataset()
                {
                    Name="Test",
                    Sentences = new List<Sentence>()
                    {
                        sentence
                    }
                   
                };
                db.Datsets.Add(dataset);
                db.SaveChanges();
            }
            MessageBox.Show("OK");
        }
    }
}
