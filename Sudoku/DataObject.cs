namespace Sudoku
{
    public class DataObject
    {
        public DataObject()
        {
            Up = this;
            Down = this;
            Right = this;
            Left = this;
            Header = null;

            Row = uint.MinValue;
            Column = uint.MinValue;
            Value = uint.MinValue;
        }

        public DataObject Up { get; set; }
        public DataObject Down { get; set; }
        public DataObject Left { get; set; }
        public DataObject Right { get; set; }
        public ColumnObject Header { get; set; }

        public uint Row { get; set; }
        public uint Column { get; set; }
        public uint Value { get; set; }

        public void InsertHorizontalNode(DataObject left, DataObject right)
        {
            Left = left;
            Right = right;

            right.Left = this;
            left.Right = this;
        }

        public void InsertVerticalNode(DataObject up, DataObject down)
        {
            Up = up;
            Down = down;

            down.Up = this;
            up.Down = this;
        }
    }
}