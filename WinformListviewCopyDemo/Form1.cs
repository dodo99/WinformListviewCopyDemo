using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.ListViewItem;
//using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace WinformListviewCopyDemo
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void copyToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ListView.SelectedListViewItemCollection selectedItems = listView1.SelectedItems;

            String text = "";
            foreach (ListViewItem item in selectedItems)
            {
                foreach(ListViewSubItem subItem in item.SubItems)
                {
                    text += subItem.Text + ", ";
                }
                text += Environment.NewLine;
            }

            Clipboard.SetText(text);
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            string[,] array2d = new string[,]
            {
                {"Boston", "USA", "42.358056", "-71.063611" },
                {"New York", "USA", "40.712778", "-74.006111" },
                {"Paris", "France", "48.856613", "2.352222" },
                {"London", "UK", "51.507222", "-0.1275" },
                {"Syracuse", "USA", "43.046944", "-76.144444" }
            };

            for (int i = 0; i <= array2d.GetUpperBound(0); i++)
            {
                //listView1.Items.Add(new ListViewItem((new MyArray<string>()).GetRow(array2d, i)));
                listView1.Items.Add(new ListViewItem(array2d.GetRow(i)));
            }

        }
    }

    //public class MyArray<T>
    //{
    //    public T[] GetColumn(T[,] matrix, int columnNumber)
    //    {
    //        return Enumerable.Range(0, matrix.GetUpperBound(1))
    //                .Select(x => matrix[x, columnNumber])
    //                .ToArray();
    //    }

    //    public T[] GetRow(T[,] matrix, int rowNumber)
    //    {
    //        return Enumerable.Range(0, matrix.GetUpperBound(0))
    //                .Select(x => matrix[rowNumber, x])
    //                .ToArray();
    //    }
    //}

    public static class ArrayExt
    {
        public static T[] GetRow<T>(this T[,] matrix, int rowNumber)
        {
            return Enumerable.Range(0, matrix.GetUpperBound(0))
                    .Select(x => matrix[rowNumber, x])
                    .ToArray();
        }

        public static T[] GetColumn<T>(this T[,] matrix, int columnNumber)
        {
            return Enumerable.Range(0, matrix.GetUpperBound(1))
                    .Select(x => matrix[x, columnNumber])
                    .ToArray();
        }

    }
}
