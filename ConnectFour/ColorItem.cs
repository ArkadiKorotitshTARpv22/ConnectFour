// ColorItem.cs
using SQLite;

namespace ConnectFour
{
    public class ColorItem
    {
        [PrimaryKey, AutoIncrement]
        public int Id { get; set; }
        public string ColorName { get; set; }
        public string ColorHex { get; set; }
    }
}

