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
using Autodesk.Revit.DB;
using System.IO;


namespace MyNewProject
{
    /// <summary>
    /// Логика взаимодействия для UserWindWall.xaml
    /// </summary>
    public partial class UserWindWall : Window
    {
        List<string> ListOfWallsForView;
        List<string> ListOfWallsForDoc;

        public UserWindWall(List<string> elements1, List<string> elements2)
        {
            InitializeComponent();
            ListOfWallsForView = elements1;
            ListOfWallsForDoc = elements2;
            if (ListOfWallsForView.Count == 0)
                AllWallsView.Items.Add("В модели отсутсвуют экземпляры категории 'Стены'");
            else
                foreach (string Line in ListOfWallsForView)
            {
                AllWallsView.Items.Add(Line);
            }
           
        }
        private void ListOfWalls(object sender, EventArgs e)
        {
            if (ListOfWallsForDoc.Count == 0)
                MessageBox.Show("В модели отсутсвуют экземпляры категории 'Стены'.\nФайл не выгружен.");
            else
            {
                string a = "\\Список стен.txt";
                string mydocu = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments).ToString() + a;
                StreamWriter MyDoc = new StreamWriter(mydocu, false, System.Text.Encoding.Default);
                foreach (string Line in ListOfWallsForDoc)
                {
                    MyDoc.WriteLine(Line);
                }
                MyDoc.Close();
                MessageBox.Show("Готово!\n" + mydocu);
            }
        }

    }
}
