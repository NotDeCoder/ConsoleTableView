using System;
using System.Collections.Generic;
using System.Linq;

namespace TableOfInfo
{
    internal class TableOfData
    {
        #region Table Drawing Constants
        const string TOP_LEFT_JOINT = "┌";
        const string TOP_RIGHT_JOINT = "┐";
        const string BOTTOM_LEFT_JOINT = "└";
        const string BOTTOM_RIGHT_JOINT = "┘";
        const string TOP_JOINT = "┬";
        const string BOTTOM_JOINT = "┴";
        const string LEFT_JOINT = "├";
        const string JOINT = "┼";
        const string RIGHT_JOINT = "┤";
        const char HORIZONTAL_LINE = '─';
        const char PADDING = ' ';
        const string VERTICAL_LINE = "│";
        #endregion

        #region Variables
        private string[] titles; //They will be at the top of table
        private List<List<string>> elements; //Map of elements. I use List of List becouse it`s faster than Dictionary
        private int spaceOfColumn;
        //Spaces of every column. Example:
        //If spaceOfColumn == 0 we will have:       If spaceOfColumn == 2 we will have:
        //              │FirstData │                            │  FirstData   │
        //              ├──────────┤                            ├──────────────┤
        //              │SecondData│                            │  SecondData  │   
        //              ├──────────┤                            ├──────────────┤
        //              │ThirdData │                            │  ThirdData   │

        #endregion

        #region Private Methods
        private int GetLargestWidthsFromColumn(int column)
        {
            int maxLength = titles[column].Length;
            for (int i = 0; i < elements.Count; i++)
            {
                if (elements[i][column].ToString().Length > maxLength)
                    maxLength = elements[i][column].ToString().Length;
            }
            return maxLength;
        }
        #endregion

        #region Public Methods
        public TableOfData(params string[] constrTitles)
        {
            if (constrTitles.Length == 0)
                throw new Exception("There must be at least one title. Add they in constructor");
            
            titles = constrTitles;
            elements = new List<List<string>>();
            spaceOfColumn = 2;
        }

        public void AddRow(params object[] newRow)
        {
            if (newRow.Length != titles.Length)
                throw new Exception($"The number of elements in a new row ({newRow.Length}) does not match the number of columns ({titles.Length})");
            elements.Add(newRow.Select(x => x.ToString()).ToList());
        }
        
        public void DeleteRow(int row)
        {
            if (row >= elements.Count || row < 0)
                throw new Exception($"Row {row} does not exist");
            
            elements.RemoveAt(row);

        }
        
        public void SetSpacesOfColumn(int space)
        {
            if (space < 0)
                throw new Exception("The space of column must be positive");
            spaceOfColumn = space;
        }

        public void Show()
        {
            //Array with largest widths from each column
            int[] columnsWidth = new int[titles.Length];
            for (int i = 0; i < columnsWidth.Length; i++)
                columnsWidth[i] = 2 * spaceOfColumn + GetLargestWidthsFromColumn(i);


            //Print upper lines of table`s titles
            for (int i = 0; i < titles.Length; i++)
            {
                if (i == 0)
                    Console.Write(TOP_LEFT_JOINT + new string(HORIZONTAL_LINE, columnsWidth[i])); // ┌────
                else if (i == titles.Length - 1)
                    Console.Write(TOP_JOINT + new string(HORIZONTAL_LINE, columnsWidth[i]) + TOP_RIGHT_JOINT + '\n'); // ┬────┐
                else
                    Console.Write(TOP_JOINT + new string(HORIZONTAL_LINE, columnsWidth[i])); // ┬────
            }

            //print titles
            for (int i = 0; i < titles.Length; i++)
            {
                string leftPadding = VERTICAL_LINE + new string(PADDING, (columnsWidth[i] - titles[i].Length) / 2);
                string rightPadding = new string(PADDING, columnsWidth[i] - titles[i].Length - (columnsWidth[i] - titles[i].Length) / 2);
                if (i == titles.Length - 1)
                    rightPadding = rightPadding + VERTICAL_LINE + '\n';

                Console.Write(leftPadding + titles[i] + rightPadding); // "│  NotLastTitle  ",    "│  LastTitle  │"
            }

            //Print lower lines of table`s titles
            for (int i = 0; i < titles.Length; i++)
            {
                if (i == 0)
                    Console.Write(LEFT_JOINT + new string(HORIZONTAL_LINE, columnsWidth[i])); // ├────
                else if (i == titles.Length - 1)
                    Console.Write(JOINT + new string(HORIZONTAL_LINE, columnsWidth[i]) + RIGHT_JOINT + '\n'); // ┼────┤
                else
                    Console.Write(JOINT + new string(HORIZONTAL_LINE, columnsWidth[i])); // ┼────
            }

            //Print elements of table
            for (int i = 0; i < elements.Count; i++)
            {
                for (int j = 0; j < elements[i].Count; j++)
                {
                    string leftPadding = VERTICAL_LINE + new string(PADDING, (columnsWidth[j] - elements[i][j].Length) / 2);
                    string rightPadding = new string(PADDING, columnsWidth[j] - elements[i][j].Length - ((columnsWidth[j] - elements[i][j].Length) / 2));
                    if (j == elements[i].Count - 1) //If it`s last cell
                        rightPadding = rightPadding + VERTICAL_LINE + '\n';
                    Console.Write(leftPadding + elements[i][j] + rightPadding); // "│  NotLastElement  ",    "│  LastElement  │"
                }
                if (i != elements.Count - 1) //if it`s not last row
                {
                    for (int j = 0; j < titles.Length; j++)
                    {
                        if (j == 0)
                            Console.Write(LEFT_JOINT + new string(HORIZONTAL_LINE, columnsWidth[j])); // ├────
                        else if (j == titles.Length - 1)
                            Console.Write(JOINT + new string(HORIZONTAL_LINE, columnsWidth[j]) + RIGHT_JOINT + '\n'); // ┼────┤
                        else
                            Console.Write(JOINT + new string(HORIZONTAL_LINE, columnsWidth[j])); // ┼────
                    }
                }
                else //If it`s last row
                {
                    for (int j = 0; j < titles.Length; j++)
                    {
                        if (j == 0)
                            Console.Write(BOTTOM_LEFT_JOINT + new string(HORIZONTAL_LINE, columnsWidth[j])); // └────
                        else if (j == titles.Length - 1)
                            Console.Write(BOTTOM_JOINT + new string(HORIZONTAL_LINE, columnsWidth[j]) + BOTTOM_RIGHT_JOINT + '\n'); // ┴────┘
                        else
                            Console.Write(BOTTOM_JOINT + new string(HORIZONTAL_LINE, columnsWidth[j])); // ┴────
                    }
                }

            }
        }

        #endregion
    }
}
