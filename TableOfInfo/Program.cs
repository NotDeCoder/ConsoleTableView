using System;

namespace TableOfInfo
{
    internal class Program
    {
        static void Main(string[] args)
        {
            TableOfData tableOfStudents = new TableOfData("Name", "Age", "Height", "Weight");

            tableOfStudents.AddRow("Kim Min Yang", "101", "180", "80");
            tableOfStudents.AddRow("Dorkiva Albel Rovo De Gusto Bret IV", "9", "95", "40");
            tableOfStudents.AddRow("Czech Lorem Ipsum", "30", "165", "58");
            tableOfStudents.AddRow("Firr Din Tos", "16", "176", "76");

            tableOfStudents.Show();
            //tableOfStudents.ShowWithNumeration();

            //tableOfStudents.InsertRow(2, "Do Re Mi", "40", "167", "55" );
            //tableOfStudents.ShowWithNumeration();

            //tableOfStudents.ChangeElementAt(0, 0, "Row Din Takel");
            //tableOfStudents.Show();

            //tableOfStudents.ChangeElementWithRowAndTitle(3, "Age", "18");
            //tableOfStudents.Show();

            //tableOfStudents.ChangeRow(2, new string[] { "Wir Ro Min", "33", "195", "95" });
            //tableOfStudents.ShowWithNumeration();

            //tableOfStudents.DeleteRow(1);
            //tableOfStudents.ShowWithNumeration();

            //tableOfStudents.SetSpacesOfColumn(5);
            //Console.WriteLine(tableOfStudents.GetTableAsString());

            Console.WriteLine("Element at 1:0 position: " + tableOfStudents.GetElementAt(1, 0));
            Console.WriteLine("Element of 2nd row and \"Name\" column: " + tableOfStudents.GetElementWithRowAndTitle(2, "Name"));
            Console.WriteLine("Index of \"Height\" title: " + tableOfStudents.GetIndexOfTitle("Height"));

            Console.ReadKey();
        }
    }
}
