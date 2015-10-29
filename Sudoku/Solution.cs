using System.Linq;
using System.Text;

namespace Sudoku
{
    //need to make this more useful, quick placeholder object
    public class Solution
    {
        public uint[,] Matrix { get; set; } = new uint[Constants.Rows, Constants.Columns];
    }
}


//public void Print()
//{
//    using (FileStream Stream = File.Open("C://Sudoku//Output.txt", FileMode.Create, FileAccess.Write))
//    {
//        using (StreamWriter Writer = new StreamWriter(Stream))
//        {
//            for (uint Row = 0; Row < Constants.MatrixRows; Row++)
//            {
//                for (uint Column = 0; Column < Constants.MatrixColumns; Column++)
//                {
//                    if (Column % (Constants.Rows * Constants.Columns) == 0)
//                    {
//                        Writer.Write("||| ");
//                    }
//                    DataObject Object = ConstraintMatrix[Row, Column];
//                    if (Object != null)
//                    {
//                        Writer.Write("({0},{1})\t", Object.Row, Object.Column);
//                    }
//                    else
//                    {
//                        Writer.Write("(0,0)\t");
//                    }
//                }
//                Writer.Write("\n");
//            }
//        }
//    }
//}

//public void PrintDownRight()
//{
//    using (FileStream Stream = File.Open("C://Sudoku//OutputDownRight.txt", FileMode.Create, FileAccess.Write))
//    {
//        using (StreamWriter Writer = new StreamWriter(Stream))
//        {
//            foreach (DataObject Row in EnumerateNodes(ColumnHeaders[0], (o) => o.Down))
//            {
//                foreach (DataObject Column in EnumerateNodes(Row, (o) => o.Right))
//                {
//                    Writer.Write("({0},{1}) ", Column.Row, Column.Column);
//                }
//                Writer.WriteLine();
//            }
//        }
//    }
//}

//public void PrintUpLeft()
//{
//    using (FileStream Stream = File.Open("C://Sudoku//OutputUpLeft.txt", FileMode.Create, FileAccess.Write))
//    {
//        using (StreamWriter Writer = new StreamWriter(Stream))
//        {
//            foreach (DataObject Row in EnumerateNodes(ColumnHeaders[0], (o) => o.Up))
//            {
//                foreach (DataObject Column in EnumerateNodes(Row, (o) => o.Left))
//                {
//                    Writer.Write("({0},{1}) ", Column.Row, Column.Column);
//                }
//                Writer.WriteLine();
//            }
//        }
//    }
//}

//public void LoadProblem(string Path)
//{
//    using (FileStream Stream = File.Open(Path, FileMode.Open))
//    {
//        using (StreamReader Reader = new StreamReader(Stream))
//        {
//            Load(Reader);
//        }
//    }
//}

//public Tuple<uint, uint, uint> SolutionItem
//{
//    get
//    {
//        uint Solution = Id;
//        uint Row = Solution / (Constants.Columns * Constants.Values);
//        Solution -= Row * Constants.Columns * Constants.Values;
//        uint Column = Solution / Constants.Values;
//        Solution -= Column * Constants.Values;
//        uint Value = Solution % Constants.Values;

//        return new Tuple<uint, uint, uint>(Row, Column, ++Value);
//    }
//}

//uint Value = Id % Constants.Values;
//uint ColumnRows = Id / Constants.Values;
//uint Column = ColumnRows % Constants.Values;
//uint Row = (Id - (Column * Constants.Values * Constants.Values) - Value * Constants.Values) / Constants.Values;

//class DLX   
//{
//    public DLXMatrix Matrix { get; set; }

//    public DLX()
//    {
//        Matrix = new DLXMatrix();
//    }

//    public void Populate()
//    {
//        Matrix.Populate();
//        Matrix.LoadProblem("C:\\Smalldoku.txt");
//        uint Depth = Matrix.Search(0);
//        Console.WriteLine("Solution (Depth {0})", Depth);
//        Matrix.PrintSolution();

//        //Matrix.Print();
//        //Matrix.PrintDownRight();
//    }
//}

//class SolutionObject : DataObject
//{
//    public SolutionObject():
//        this(default(int), default(int), default(int))
//    {
//    }

//    public SolutionObject(uint Row, uint Column, uint Value)
//    {
//        this.Row = Row;
//        this.Column = Column;
//        this.Value = Value;
//    }

//    public uint Row { get; set; }
//    public uint Column { get; set; }
//    public uint Value { get; set; }
//    public List<DataObject> Constraints { get; set; }

//    public Tuple<uint, uint, uint> GetSolutionObject()
//    {
//        return new Tuple<uint, uint, uint>(Row, Column, Value);
//    }
//}

//private void CreateSolutionSet(uint Solutions)
//{
//    uint Value = Solutions % 9;
//    uint ColumnRows = Solutions / 9;
//    uint Row = ColumnRows % 9;
//    uint Column = (Solutions - (Row * 9) - Value) / 9;
//    SolutionSet[Solutions] = new SolutionObject(Row, Column, Value);
//    //SolutionSet[Row].InsertVerticalLinkedNode(Root, SolutionSet[Row]);
//}

//private void CreateSolutionSet(uint Row, uint Column, uint Value)
//{
//    SolutionSet[Row] = new SolutionObject(Row, Column, Value);
//    //SolutionSet[Row].InsertVerticalNode(SolutionSet[0], SolutionSet[Row]);
//}

//private void AddLinkedNode(uint RowIndex, uint ColumnIndex)//, DataObject Row, ColumnObject Column)
//{
//    DataObject Object = new DataObject();
//    ColumnObject Column = Headers[ColumnIndex];

//    Data[RowIndex, ColumnIndex] = Object;
//    Object.InsertHorizontalLinkedNode(Row, Column);
//    Object.InsertVerticalLinkedNode(Column, Column);
//    Object.Header.Size++;
//}

//private DataObject AddLinkedNode(DataObject Row, ColumnObject Header)
//{
//    DataObject Object = new DataObject();
//    Object.InsertHorizontalLinkedNode(Row, Header);
//    Object.InsertVerticalLinkedNode(Header, Header);
//    Object.Header.Size++;

//    return Object;
//}

//    R1C1 R1C2 R1C3 R2C1 R2C2 R2C3 R3C1 R3C2 R3C3  R1N1 R1N2 R1N3 R2N1 R2N2 R2N3 R3N1 R3N2 R3N3  C1N1 C1N2 C1N3 C2N1 C2N2 C2N3 C3N1 C3N2 C3N3  B1N1 B1N2 B1N3 B2N1 B2N2 B2N3 B3N1 B3N2 B3N3   
//111    1    0    0    0    0    0    0    0    0  |  1    0    0    0    0    0    0    0    0  |  1    0    0    0    0    0    0    0    0  |  0    0    0    0    0    0    0    0    0            
//112    1    0    0    0    0    0    0    0    0  |  0    1    0    0    0    0    0    0    0  |  0    1    0    0    0    0    0    0    0  |  0    0    0    0    0    0    0    0    0                   
//113    1    0    0    0    0    0    0    0    0  |  0    0    1    0    0    0    0    0    0  |  0    0    1    0    0    0    0    0    0  |  0    0    0    0    0    0    0    0    0                   
//121    0    1    0    0    0    0    0    0    0  |  1    0    0    0    0    0    0    0    0  |  0    0    0    1    0    0    0    0    0  |  0    0    0    0    0    0    0    0    0
//122    0    1    0    0    0    0    0    0    0  |  0    1    0    0    0    0    0    0    0  |  0    0    0    0    1    0    0    0    0  |  0    0    0    0    0    0    0    0    0
//123    0    1    0    0    0    0    0    0    0  |  0    0    1    0    0    0    0    0    0  |  0    0    0    0    0    1    0    0    0  |  0    0    0    0    0    0    0    0    0
//131    0    0    1    0    0    0    0    0    0  |  1    0    0    0    0    0    0    0    0  |  0    0    0    0    0    0    1    0    0  |  0    0    0    0    0    0    0    0    0
//132    0    0    1    0    0    0    0    0    0  |  0    1    0    0    0    0    0    0    0  |  0    0    0    0    0    0    0    1    0  |  0    0    0    0    0    0    0    0    0
//133    0    0    1    0    0    0    0    0    0  |  0    0    1    0    0    0    0    0    0  |  0    0    0    0    0    0    0    0    1  |  0    0    0    0    0    0    0    0    0
//211    0    0    0    1    0    0    0    0    0  |  0    0    0    1    0    0    0    0    0  |  1    0    0    0    0    0    0    0    0  |  0    0    0    0    0    0    0    0    0
//212    0    0    0    1    0    0    0    0    0  |  0    0    0    0    1    0    0    0    0  |  0    1    0    0    0    0    0    0    0  |  0    0    0    0    0    0    0    0    0
//213    0    0    0    1    0    0    0    0    0  |  0    0    0    0    0    1    0    0    0  |  0    0    1    0    0    0    0    0    0  |  0    0    0    0    0    0    0    0    0
//221    0    0    0    0    1    0    0    0    0  |  0    0    0    1    0    0    0    0    0  |  0    0    0    1    0    0    0    0    0  |  0    0    0    0    0    0    0    0    0
//222    0    0    0    0    1    0    0    0    0  |  0    0    0    0    1    0    0    0    0  |  0    0    0    0    1    0    0    0    0  |  0    0    0    0    0    0    0    0    0
//223    0    0    0    0    1    0    0    0    0  |  0    0    0    0    0    1    0    0    0  |  0    0    0    0    0    1    0    0    0  |  0    0    0    0    0    0    0    0    0
//231    0    0    0    0    0    1    0    0    0  |  0    0    0    1    0    0    0    0    0  |  0    0    0    0    0    0    1    0    0  |  0    0    0    0    0    0    0    0    0
//232    0    0    0    0    0    1    0    0    0  |  0    0    0    0    1    0    0    0    0  |  0    0    0    0    0    0    0    1    0  |  0    0    0    0    0    0    0    0    0
//233    0    0    0    0    0    1    0    0    0  |  0    0    0    0    0    1    0    0    0  |  0    0    0    0    0    0    0    0    1  |  0    0    0    0    0    0    0    0    0
//311    0    0    0    0    0    0    1    0    0  |  0    0    0    0    0    0    1    0    0  |  1    0    0    0    0    0    0    0    0  |  0    0    0    0    0    0    0    0    0
//312    0    0    0    0    0    0    1    0    0  |  0    0    0    0    0    0    0    1    0  |  0    1    0    0    0    0    0    0    0  |  0    0    0    0    0    0    0    0    0
//313    0    0    0    0    0    0    1    0    0  |  0    0    0    0    0    0    0    0    1  |  0    0    1    0    0    0    0    0    0  |  0    0    0    0    0    0    0    0    0
//321    0    0    0    0    0    0    0    1    0  |  0    0    0    0    0    0    1    0    0  |  0    0    0    1    0    0    0    0    0  |  0    0    0    0    0    0    0    0    0
//322    0    0    0    0    0    0    0    1    0  |  0    0    0    0    0    0    0    1    0  |  0    0    0    0    1    0    0    0    0  |  0    0    0    0    0    0    0    0    0
//323    0    0    0    0    0    0    0    1    0  |  0    0    0    0    0    0    0    0    1  |  0    0    0    0    0    1    0    0    0  |  0    0    0    0    0    0    0    0    0
//331    0    0    0    0    0    0    0    0    1  |  0    0    0    0    0    0    1    0    0  |  0    0    0    0    0    0    1    0    0  |  0    0    0    0    0    0    0    0    0
//332    0    0    0    0    0    0    0    0    1  |  0    0    0    0    0    0    0    1    0  |  0    0    0    0    0    0    0    1    0  |  0    0    0    0    0    0    0    0    0
//333    0    0    0    0    0    0    0    0    1  |  0    0    0    0    0    0    0    0    1  |  0    0    0    0    0    0    0    0    1  |  0    0    0    0    0    0    0    0    0


//    B1N1 B1N2 B1N3 B1N4 B2N1 B2N2 B2N3 B2N4 B3N1 B3N2 B3N3 B3N4 B4N1 B4N2 B4N3 B4N4
//111    1    0    0    0    0    0    0    0    0    0    0    0    0    0    0    0
//112    0    1    0    0    0    0    0    0    0    0    0    0    0    0    0    0
//113    0    0    1    0    0    0    0    0    0    0    0    0    0    0    0    0
//114    0    0    0    1    0    0    0    0    0    0    0    0    0    0    0    0
//121    1    0    0    0    0    0    0    0    0    0    0    0    0    0    0    0
//122    0    1    0    0    0    0    0    0    0    0    0    0    0    0    0    0
//123    0    0    1    0    0    0    0    0    0    0    0    0    0    0    0    0
//124    0    0    0    1    0    0    0    0    0    0    0    0    0    0    0    0
//131    0    0    0    0    1    0    0    0    0    0    0    0    0    0    0    0
//132    0    0    0    0    0    1    0    0    0    0    0    0    0    0    0    0
//133    0    0    0    0    0    0    1    0    0    0    0    0    0    0    0    0
//134    0    0    0    0    0    0    0    1    0    0    0    0    0    0    0    0
//141    0    0    0    0    1    0    0    0    0    0    0    0    0    0    0    0
//142    0    0    0    0    0    1    0    0    0    0    0    0    0    0    0    0
//143    0    0    0    0    0    0    1    0    0    0    0    0    0    0    0    0
//144    0    0    0    0    0    0    0    1    0    0    0    0    0    0    0    0
//211    1    0    0    0    0    0    0    0    0    0    0    0    0    0    0    0
//212    0    1    0    0    0    0    0    0    0    0    0    0    0    0    0    0
//213    0    0    1    0    0    0    0    0    0    0    0    0    0    0    0    0
//214    0    0    0    1    0    0    0    0    0    0    0    0    0    0    0    0
//221    1    0    0    0    0    0    0    0    0    0    0    0    0    0    0    0
//222    0    1    0    0    0    0    0    0    0    0    0    0    0    0    0    0
//223    0    0    1    0    0    0    0    0    0    0    0    0    0    0    0    0
//224    0    0    0    1    0    0    0    0    0    0    0    0    0    0    0    0
//231    0    0    0    0    1    0    0    0    0    0    0    0    0    0    0    0
//232    0    0    0    0    0    1    0    0    0    0    0    0    0    0    0    0
//233    0    0    0    0    0    0    1    0    0    0    0    0    0    0    0    0
//234    0    0    0    0    0    0    0    1    0    0    0    0    0    0    0    0
//241    0    0    0    0    1    0    0    0    0    0    0    0    0    0    0    0
//242    0    0    0    0    0    1    0    0    0    0    0    0    0    0    0    0
//243    0    0    0    0    0    0    1    0    0    0    0    0    0    0    0    0
//244    0    0    0    0    0    0    0    1    0    0    0    0    0    0    0    0
//311    0    0    0    0    0    0    0    0    1    0    0    0    0    0    0    0
//312    0    0    0    0    0    0    0    0    0    1    0    0    0    0    0    0
//313    0    0    0    0    0    0    0    0    0    0    1    0    0    0    0    0
//314    0    0    0    0    0    0    0    0    0    0    0    1    0    0    0    0
//321    0    0    0    0    0    0    0    0    1    0    0    0    0    0    0    0
//322    0    0    0    0    0    0    0    0    0    1    0    0    0    0    0    0
//323    0    0    0    0    0    0    0    0    0    0    1    0    0    0    0    0
//324    0    0    0    0    0    0    0    0    0    0    0    1    0    0    0    0
//331    0    0    0    0    0    0    0    0    0    0    0    0    1    0    0    0
//332    0    0    0    0    0    0    0    0    0    0    0    0    0    1    0    0
//333    0    0    0    0    0    0    0    0    0    0    0    0    0    0    1    0
//334    0    0    0    0    0    0    0    0    0    0    0    0    0    0    0    1
//341    0    0    0    0    0    0    0    0    0    0    0    0    1    0    0    0
//342    0    0    0    0    0    0    0    0    0    0    0    0    0    1    0    0
//343    0    0    0    0    0    0    0    0    0    0    0    0    0    0    1    0
//344    0    0    0    0    0    0    0    0    0    0    0    0    0    0    0    1
//.
//.
//.


//    B1N1 B2N1 B3N1 B4N1 
//111    1    0    0    0 
//112    1    0    0    0 
//113    1    0    0    0 
//114    1    0    0    0 
//121    1    0    0    0 
//122    1    0    0    0 
//123    1    0    0    0 
//124    1    0    0    0 
//131    0    1    0    0 
//132    0    1    0    0 
//133    0    1    0    0 
//134    0    1    0    0 
//141    0    1    0    0 
//142    0    1    0    0 
//143    0    1    0    0 
//144    0    1    0    0 
//211    1    0    0    0 
//212    1    0    0    0 
//213    1    0    0    0 
//214    1    0    0    0 
//221    1    0    0    0 
//222    1    0    0    0 
//223    1    0    0    0 
//224    1    0    0    0 
//231    0    1    0    0 
//232    0    1    0    0 
//233    0    1    0    0 
//234    0    1    0    0 
//241    0    1    0    0 
//242    0    1    0    0 
//243    0    1    0    0 
//244    0    1    0    0 
//311    0    0    1    0 
//312    0    0    1    0 
//313    0    0    1    0 
//314    0    0    1    0 
//321    0    0    1    0 
//322    0    0    1    0 
//323    0    0    1    0 
//324    0    0    1    0 
//331    0    0    0    1 
//332    0    0    0    1 
//333    0    0    0    1 
//334    0    0    0    1 
//341    0    0    0    1 
//342    0    0    0    1 
//343    0    0    0    1 
//344    0    0    0    1
//.
//.
//.