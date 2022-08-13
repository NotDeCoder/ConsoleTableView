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
        private int GetLargestWidthsFromColumn(string[] newTitles, List<List<string>> newElements, int column)
        {
            int maxLength = newTitles[column].Length;
            for (int i = 0; i < newElements.Count; i++)
            {
                if (newElements[i][column].ToString().Length > maxLength)
                    maxLength = newElements[i][column].ToString().Length;
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

        public void InsertRow(int index, params object[] newRow)
        {
            if (newRow.Length != titles.Length)
                throw new Exception($"The number of elements in a new row ({newRow.Length}) does not match the number of columns ({titles.Length})");

            if (index < 0 || index > elements.Count)
                throw new Exception($"Index ({index}) is out of range");

            elements.Insert(index, newRow.Select(x => x.ToString()).ToList());
        }
        
        public void DeleteRow(int row)
        {
            if (row > elements.Count || row < 0)
                throw new Exception($"Row {row} does not exist");

            elements.RemoveAt(row);
        }

        public void ChangeRow(int row, params object[] newRow)
        {
            if (row > elements.Count || row < 0)
                throw new Exception($"Row {row} does not exist");
            
            if (newRow.Length != titles.Length)
                throw new Exception($"The number of elements in a new row ({newRow.Length}) does not match the number of columns ({titles.Length})");
            
            elements[row] = newRow.Select(x => x.ToString()).ToList();
        }


        public int GetIndexOfTitle(string title)
        {
            if (Array.IndexOf(titles, title) == -1)
                throw new Exception($"Column \"{title}\" does not exist");

            return Array.IndexOf(titles, title);
        }

        public string GetElementAt(int row, int column)
        {
            if (row > elements.Count || row < 0)
                throw new Exception($"Row {row} does not exist");

            if (column > elements[row].Count || column < 0)
                throw new Exception($"Column {column} does not exist");

            return elements[row][column];
        }

        public string GetElementWithRowAndTitle(int row, string title)
        {
            if (row > elements.Count || row < 0)
                throw new Exception($"Row {row} does not exist");

            return elements[row][GetIndexOfTitle(title)];
        }

        
        
        public void ChangeElementAt(int row, int column, string newElement)
        {
            if (row > elements.Count || row < 0)
                throw new Exception($"Row {row} does not exist");
            
            if (column > elements[row].Count || column < 0)
                throw new Exception($"Column {column} does not exist");
            
            elements[row][column] = newElement;
        }

        public void ChangeElementWithRowAndTitle(int row, string title, string newElement)
        {
            if (row > elements.Count || row < 0)
                throw new Exception($"Row {row} does not exist");

            elements[row][GetIndexOfTitle(title)] = newElement;
        }
        

        
        public void SetSpacesOfColumn(int space)
        {
            if (space < 0)
                throw new Exception("The space of column must be positive");

            spaceOfColumn = space;
        }

        public string GetTableAsString(bool doWeDrawNumbers = false)
        {
            string resultString = "";

            string[] newTitles;
            List<List<string>> newElements;
            if (doWeDrawNumbers) //Add new title, add number to every element
            {
                newTitles = titles.Prepend("Number").ToArray();
                newElements = elements.Select(x => x.Prepend(elements.IndexOf(x).ToString()).ToList()).ToList();
            }
            else
            {
                newTitles = titles;
                newElements = elements;
            }

            //Array with largest widths from each column
            int[] columnsWidth = new int[newTitles.Length];
            for (int i = 0; i < columnsWidth.Length; i++)
                columnsWidth[i] = 2 * spaceOfColumn + GetLargestWidthsFromColumn(newTitles, newElements, i);


            //Print upper lines of table`s titles
            for (int i = 0; i < newTitles.Length; i++)
            {
                if (i == 0)
                    resultString += TOP_LEFT_JOINT + new string(HORIZONTAL_LINE, columnsWidth[i]); // ┌────
                else if (i == newTitles.Length - 1)
                    resultString += TOP_JOINT + new string(HORIZONTAL_LINE, columnsWidth[i]) + TOP_RIGHT_JOINT + '\n'; // ┬────┐
                else
                    resultString += TOP_JOINT + new string(HORIZONTAL_LINE, columnsWidth[i]); // ┬────
            }

            //print titles
            for (int i = 0; i < newTitles.Length; i++)
            {
                string leftPadding = VERTICAL_LINE + new string(PADDING, (columnsWidth[i] - newTitles[i].Length) / 2);
                string rightPadding = new string(PADDING, columnsWidth[i] - newTitles[i].Length - (columnsWidth[i] - newTitles[i].Length) / 2);
                if (i == newTitles.Length - 1)
                    rightPadding = rightPadding + VERTICAL_LINE + '\n';

                resultString += leftPadding + newTitles[i] + rightPadding; // "│  NotLastTitle  ",    "│  LastTitle  │"
            }

            //Print lower lines of table`s titles
            for (int i = 0; i < newTitles.Length; i++)
            {
                if (i == 0)
                    resultString += LEFT_JOINT + new string(HORIZONTAL_LINE, columnsWidth[i]); // ├────
                else if (i == newTitles.Length - 1)
                    resultString += JOINT + new string(HORIZONTAL_LINE, columnsWidth[i]) + RIGHT_JOINT + '\n'; // ┼────┤
                else
                    resultString += JOINT + new string(HORIZONTAL_LINE, columnsWidth[i]); // ┼────
            }

            //Print elements of table
            for (int i = 0; i < newElements.Count; i++)
            {
                for (int j = 0; j < newElements[i].Count; j++)
                {
                    string leftPadding = VERTICAL_LINE + new string(PADDING, (columnsWidth[j] - newElements[i][j].Length) / 2);
                    string rightPadding = new string(PADDING, columnsWidth[j] - newElements[i][j].Length - ((columnsWidth[j] - newElements[i][j].Length) / 2));
                    if (j == newElements[i].Count - 1) //If it`s last cell
                        rightPadding = rightPadding + VERTICAL_LINE + '\n';
                    resultString += leftPadding + newElements[i][j] + rightPadding; // "│  NotLastElement  ",    "│  LastElement  │"
                }
                if (i != newElements.Count - 1) //if it`s not last row
                {
                    for (int j = 0; j < newTitles.Length; j++)
                    {
                        if (j == 0)
                            resultString += LEFT_JOINT + new string(HORIZONTAL_LINE, columnsWidth[j]); // ├────
                        else if (j == newTitles.Length - 1)
                            resultString += JOINT + new string(HORIZONTAL_LINE, columnsWidth[j]) + RIGHT_JOINT + '\n'; // ┼────┤
                        else
                            resultString += JOINT + new string(HORIZONTAL_LINE, columnsWidth[j]); // ┼────
                    }
                }
                else //If it`s last row
                {
                    for (int j = 0; j < newTitles.Length; j++)
                    {
                        if (j == 0)
                            resultString += BOTTOM_LEFT_JOINT + new string(HORIZONTAL_LINE, columnsWidth[j]); // └────
                        else if (j == newTitles.Length - 1)
                            resultString += BOTTOM_JOINT + new string(HORIZONTAL_LINE, columnsWidth[j]) + BOTTOM_RIGHT_JOINT + '\n'; // ┴────┘
                        else
                            resultString += BOTTOM_JOINT + new string(HORIZONTAL_LINE, columnsWidth[j]); // ┴────
                    }
                }

            }
            return resultString;
        }

        public void Show()
        {
            Console.WriteLine(GetTableAsString());
        }
        
        public void ShowWithNumeration()
        {
            Console.WriteLine(GetTableAsString(true));
        }
        
        #endregion
    }
}
