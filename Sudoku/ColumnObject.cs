namespace Sudoku
{
    public class ColumnObject : DataObject
    {
        public ColumnObject()
        {
            Size = default(uint);
            Header = this;
        }

        public ColumnObject(uint size)
        {
            Size = size;
        }

        public uint Size { get; set; }
    }
}