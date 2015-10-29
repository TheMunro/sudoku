using System;
using System.Collections.Generic;
using System.IO;

namespace Sudoku
{
    class DlxMatrix
    {
        public RootObject Root;
        private ColumnObject[] _columnHeaders;
        private DataObject[,] _constraintMatrix;

        private List<DataObject> _solutionSet;

        public DlxMatrix()
        {
            Initialise();
        }

        //all of this initialisation and resetting is shit, revise!
        public void Reset()
        {
            Initialise();
        }

        private void Initialise()
        {
            Root = new RootObject();
            _columnHeaders = new ColumnObject[Constants.MatrixColumns];
            _constraintMatrix = new DataObject[Constants.MatrixRows, Constants.MatrixColumns];

            _solutionSet = new List<DataObject>();

            Populate();
        }

        private void Populate()
        {
            for (uint column = 0; column < Constants.MatrixColumns; column++)
            {
                CreateColumnHeaders(column);
            }

            for (uint row = 0; row < Constants.Rows; row++)
            {
                for (uint column = 0; column < Constants.Columns; column++)
                {
                    for (uint value = 0; value < Constants.Values; value++)
                    {
                        CreateConstraints(row, column, value);
                    }
                }
            }
        }

        private void CreateColumnHeaders(uint column)
        {
            _columnHeaders[column] = new ColumnObject(column) { Column = column };
            _columnHeaders[column].InsertHorizontalNode(Root.Left, Root);
        }

        private void CreateConstraints(uint row, uint column, uint value)
        {
            CreateConstraints(row * Constants.Columns * Constants.Values + column * Constants.Values + value, new [] 
            {
                (Constants.Rows * row + column),
                (Constants.Rows * Constants.Columns) + (Constants.Rows * row + value),
                (Constants.Rows * Constants.Columns) + (Constants.Rows * Constants.Values) + (Constants.Columns * column + value),
                (Constants.Rows * Constants.Columns) + (Constants.Rows * Constants.Values) + (Constants.Columns * Constants.Values) + ((3 * (row / 3) + (column / 3)) * 9 + value)
            }, row, column, value);
        }

        private void CreateConstraints(uint matrixRow, uint[] matrixColumns, uint row, uint column, uint value)
        {
            DataObject left = null;
            foreach (var matrixColumn in matrixColumns)
            {
                var node = new DataObject
                {
                    Row = row,
                    Column = column,
                    Value = ++value
                };

                if (left == null)
                {
                    left = node;
                }

                var up = _columnHeaders[matrixColumn];
                _constraintMatrix[matrixRow, matrixColumn] = node;

                InsertDoublyLinkedNode(left, up, node);
            }
        }

        private void InsertDoublyLinkedNode(DataObject left, ColumnObject up, DataObject node)
        {
            node.InsertHorizontalNode(left.Left, left);
            node.InsertVerticalNode(up.Up, up);

            node.Header = up;
            node.Header.Size++;
        }

        private IEnumerable<DataObject> EnumerateNodes(DataObject start, Func<DataObject, DataObject> function)
        {
            var node = start;
            while ((node = function(node)) != start)
            {
                yield return node;
            }
        }

        public uint Search(uint depth, Solution solution)
        {
            if (Root.Right == Root)
            {
                //PrintSolution();
                Populate(solution);
                return depth;
            }

            var heuristicColumn = GetHeuristicColumn();
            Cover(heuristicColumn);

            foreach (var row in EnumerateNodes(heuristicColumn, o => o.Down))
            {
                _solutionSet.Add(row);
                foreach (var column in EnumerateNodes(row, o => o.Right))
                {
                    Cover(column.Header);
                }

                var finalDepth = Search(depth + 1, solution);
                if (Root.Right == Root)
                {
                    return finalDepth;
                }

                _solutionSet.Remove(row);
                heuristicColumn = row.Header;
                foreach (var column in EnumerateNodes(row, o => o.Left))
                {
                    Uncover(column.Header);
                }
            }
            Uncover(heuristicColumn);
            return depth;
        }

        private ColumnObject GetHeuristicColumn()
        {
            var maxSize = uint.MaxValue;
            ColumnObject Object = null;

            foreach (ColumnObject column in EnumerateNodes(Root, o => o.Right))
            {
                if (column.Size < maxSize)
                {
                    maxSize = column.Size;
                    Object = column;
                }
            }

            return Object;
        }

        private void Cover(DataObject headerColumn)
        {
            headerColumn.Right.Left = headerColumn.Left;
            headerColumn.Left.Right = headerColumn.Right;

            foreach (var row in EnumerateNodes(headerColumn, o => o.Down))
            {
                foreach (var column in EnumerateNodes(row, o => o.Right))
                {
                    column.Down.Up = column.Up;
                    column.Up.Down = column.Down;
                    column.Header.Size--;
                }
            }
        }

        private void Uncover(DataObject headerColumn)
        {
            foreach (var row in EnumerateNodes(headerColumn, o => o.Up))
            {
                foreach (var column in EnumerateNodes(row, o => o.Left))
                {
                    column.Down.Up = column;
                    column.Up.Down = column;
                    column.Header.Size++;
                }
            }

            headerColumn.Right.Left = headerColumn;
            headerColumn.Left.Right = headerColumn;
        }

        //this does not belong here, pass in partial matrix and return full solved matrix
        public void Load(StreamReader reader)
        {
            while (reader.EndOfStream == false)
            {
                var problem = new uint[Constants.Rows, Constants.Columns];
                for (uint row = 0; row < Constants.Rows; row++)
                {
                    var line = reader.ReadLine().ToCharArray();
                    for (uint column = 0; column < Constants.Columns; column++)
                    {
                        var value = UInt32.Parse(line[column].ToString());
                        problem[row, column] = value;
                    }
                }

                for (uint row = 0; row < Constants.Rows; row++)
                {
                    for (uint column = 0; column < Constants.Columns; column++)
                    {
                        var value = problem[row, column];
                        if (value > 0)
                        {
                            var columnIndices = new uint[] {
                                (Constants.Rows * row + column),
                                (Constants.Rows * Constants.Columns) + (Constants.Rows * row + value - 1),
                                (Constants.Rows * Constants.Columns) + (Constants.Rows * Constants.Values) + (Constants.Columns * column + value - 1),
                                (Constants.Rows * Constants.Columns) + (Constants.Rows * Constants.Values) + (Constants.Columns * Constants.Values) + ((3 * (row / 3) + (column / 3)) * 9 + value - 1)
                            };

                            _solutionSet.Add(_constraintMatrix[(row * Constants.Columns * Constants.Values + column * Constants.Values + value - 1), Constants.Rows * row + column]);
                            foreach (var columnIndex in columnIndices)
                            {
                                Cover(_columnHeaders[columnIndex]);
                            }
                        }
                    }
                }
            }
        }

        private void Populate(Solution solution)
        {
            foreach (var Object in _solutionSet)
            {
                solution.Matrix[Object.Row, Object.Column] = Object.Value;
            }
        }
    }
}