using System;

namespace TableOfInfo
{
    internal class Program
    {
        static void Main(string[] args)
        {
            TableOfData showTable = new TableOfData("Name", "Age", "Height", "Weight");
            
            showTable.AddRow("Kim Min Yang", "101", "180", "80");
            showTable.AddRow("Dorkiva Albel Rovo De Gusto Bret IV", "9", "95", "40");
            showTable.AddRow("Czech Lorem Ipsum", "30", "165", "58");
            showTable.AddRow("Firr Din Tos", "16", "176", "76");

            showTable.Show();
            showTable.ShowWithNumeration();

            showTable.DeleteRow(1);
            showTable.ShowWithNumeration();

            showTable.SetSpacesOfColumn(5);
            Console.WriteLine(showTable.GetTableAsString());


            Console.ReadKey();
        }
    }
}
