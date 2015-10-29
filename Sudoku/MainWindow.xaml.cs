using System;
using System.Collections.Generic;
using System.Diagnostics;
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

namespace Sudoku
{


    public partial class MainWindow : Window
    {
        DlxMatrix _dlxMatrix = null;

        public MainWindow()
        {
            InitializeComponent();

            _dlxMatrix = new DlxMatrix();
        }

        private void Load(object sender, RoutedEventArgs e)
        {
            _dlxMatrix.Reset();

            var ofd = new OpenFileDialog();
            ofd.InitialDirectory = "C:\\Sudoku\\";
            if (ofd.ShowDialog() == true)
            {
                using (var stream = ofd.OpenFile())
                {
                    using (var reader = new StreamReader(stream))
                    {
                        _dlxMatrix.Load(reader);
                    }
                }
                //using (FileStream Stream = File.Open(Path, FileMode.Open))
                {
 
                }
            }
        }

        private void Solve(object sender, RoutedEventArgs e)
        {
            var stopwatch = new Stopwatch();
            stopwatch.Start();
            var solution = new Solution();
            var depth = _dlxMatrix.Search(0, solution);
            stopwatch.Stop();

            for (var row = 0; row < Constants.Rows; row++)
            {
                Output.Items.Add(String.Format("{0} {1} {2} {3} {4} {5} {6} {7} {8}", 
                    solution.Matrix[row, 0], solution.Matrix[row, 1], solution.Matrix[row, 2],
                    solution.Matrix[row, 3], solution.Matrix[row, 4], solution.Matrix[row, 5],
                    solution.Matrix[row, 6], solution.Matrix[row, 7], solution.Matrix[row, 8]));
            }

            Output.Items.Add(String.Format("Search Depth: {0}", depth));
            Output.Items.Add(String.Format("Search Time: {0}", stopwatch.Elapsed));
        }
    }
}
