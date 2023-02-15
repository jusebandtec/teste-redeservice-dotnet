using System;

namespace AvalicaoProgramadorDotNet
{
    public class TableConsoleApplication
    {
        public int TableWidth { get; set; }

        // public static void Main(string[] args)
        // {
        //     Console.Clear();
        //     PrintLine();
        //     PrintRow("Column 1", "Column 2", "Column 3", "Column 4");
        //     PrintLine();
        //     PrintRow("", "", "", "");
        //     PrintRow("", "", "", "");
        //     PrintLine();
        //     Console.ReadLine();
        // }

        public TableConsoleApplication(int tableWidth)
        {
            this.TableWidth = tableWidth;
        }

        public void PrintLine()
        {
            Console.WriteLine(new string('-', TableWidth));
        }

        public void PrintRow(params string[] columns)
        {
            int width = (TableWidth - columns.Length) / columns.Length;
            string row = "|";

            foreach (string column in columns)
            {
                row += AlignCentre(column, width) + "|";
            }

            Console.WriteLine(row);
        }

        public string AlignCentre(string text, int width)
        {
            text = text.Length > width ? text.Substring(0, width - 3) + "..." : text;

            if (string.IsNullOrEmpty(text))
            {
                return new string(' ', width);
            }
            else
            {
                return text.PadRight(width - (width - text.Length) / 2).PadLeft(width);
            }
        }
    }
}