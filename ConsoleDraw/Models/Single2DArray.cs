namespace ConsoleDraw.Models
{
    public class Single2DArray<T>
    {
        private readonly T[] _array;
        private readonly int _columnSize;

        public Single2DArray(int rows, int columns)
        {
            this._array = new T[rows * columns];
            this._columnSize = columns;
        }

        private int GetIndex(int row, int column) => row * _columnSize + column;

        public T Get(int row, int column) => _array[this.GetIndex(row, column)];

        public void Set(int row, int column, T value) => _array[this.GetIndex(row, column)] = value;
    }
}
