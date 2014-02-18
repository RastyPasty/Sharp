using Microsoft.Win32;
using System;
using System.Collections.Generic;
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

namespace MDBComparer
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

        #region events
        /// <summary>
        /// Closes main window
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void CloseButton_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        /// <summary>
        /// Access Database file open dialog
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void FilePath1_MouseDown(object sender, MouseButtonEventArgs e)
        {
            FileSelectingAndProcessing(sender);
        }

        /// <summary>
        /// Access Database file open dialog
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void FilePath2_PreviewMouseDown(object sender, MouseButtonEventArgs e)
        {
            FileSelectingAndProcessing(sender);
        }
        #endregion

        /// <summary>
        /// Validate selected files and compare Access files
        /// </summary>
        /// <param name="sender">Element with Text property</param>
        private void FileSelectingAndProcessing(object sender)
        {
            SelectFile(sender);
            if (FilesSelected())
            {
                MDB leftMDB = new MDB(FilePath_L.Text, "Left");
                MDB rightMDB = new MDB(FilePath_R.Text, "Right");

                if (leftMDB.DataLoaded && rightMDB.DataLoaded)
                {
                    Compare(leftMDB, rightMDB);
                }
            }
        }

        /// <summary>
        /// Open file select dialog and fill Textbox
        /// </summary>
        /// <param name="sender">Element with Text property</param>
        private void SelectFile(object sender)
        {
            OpenFileDialog openFileDialog1 = new OpenFileDialog();

            openFileDialog1.InitialDirectory = "c:\\";
            openFileDialog1.Filter = "All files|*.*|Microsoft Access (*.mdb, *.accdb)|*.mdb;*.ACCDB";
            openFileDialog1.Multiselect = false;
            openFileDialog1.FilterIndex = 2;
            openFileDialog1.RestoreDirectory = true;

            if (openFileDialog1.ShowDialog() == true)
            {
                ((TextBox)sender).Text = openFileDialog1.FileName;
            }
        }

        /// <summary>
        /// Checks if files exist
        /// </summary>
        /// <returns></returns>
        private bool FilesSelected()
        {
            return File.Exists(FilePath_L.Text) && File.Exists(FilePath_R.Text);            
        }

        /// <summary>
        /// Compare databases and view relult
        /// </summary>
        /// <param name="left">MDB instance</param>
        /// <param name="right">MDB instance</param>
        private void Compare(MDB left, MDB right)
        {
            TextBlockOut.Text = String.Empty;
            //fully joined left and right MDB collections
            var allTablesList = left.Tables.FullOuterJoin(right.Tables, l => l.Name, r => r.Name, (l, r, Name) => new { l, r });

            foreach (var tablePair in allTablesList.ToList())
            {
                string tableHeaderText;
                tableHeaderText = tablePair.l != null ? tablePair.l.Name + " " + tablePair.l.Description : tablePair.r.Name + " " + tablePair.l.Description;
                TextBlockOut.Text += tableHeaderText + "\r\n";

                List<MDBTableColumn> lefttable = tablePair.l.Rows;
                List<MDBTableColumn> righttable = tablePair.r.Rows;
                
                //fully joined table collections
                var allTableColumnsList = lefttable.FullOuterJoin(righttable, l => l.Name, r => r.Name, (l, r, Name) => new { l, r });
                
                foreach (var columnsPair in allTableColumnsList)
                {
                    MDBTableColumn l_col = columnsPair.l??new MDBTableColumn();
                    MDBTableColumn r_col = columnsPair.r ?? new MDBTableColumn();
                    if (l_col == r_col) TextBlockOut.Text += "   " + l_col.ToString() + r_col.ToString() + "\r\n";
                    else TextBlockOut.Text += " ► " + l_col.ToString() + r_col.ToString() + "\r\n";
                }
            }         
        }
    }
}
