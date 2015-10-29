namespace Sudoku
{
    public class Constants
    {
        public static uint Size = 9;

        public static uint Values = Size;
        public static uint Rows = Size;
        public static uint Columns = Size;
        public static uint Boxes = Size;

        public static uint MatrixColumns = (Rows * Columns) + (Rows * Values) + (Columns * Values) + (Boxes * Values);
        public static uint MatrixRows = Rows * Columns * Values;
    }
}