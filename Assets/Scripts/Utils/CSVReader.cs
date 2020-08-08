/* 
* -------------------------------------------Copyright--By--Thuan.NguyenDuc-------------------------------------------------
* -----------------------------------------Email--nguyenducthuanbkdn@gmail.com----------------------------------------------
*/

namespace Utils
{
    public class ColumnData
    {
        private string columnName;
        public string ColumnName { get { return columnName; } }

        private string[] dataInColumn;
        public string[] DataInColumn { get { return dataInColumn; } }

        public ColumnData(string columnName, string[] dataInColumn)
        {
            this.columnName = columnName;
            this.dataInColumn = dataInColumn;
        }
    }


    public static class CSVReader
    {

        private const string BREAK_LINE_SYMBOL_IN_A_BOX_OF_CSV_FILE = "<bl>";
        private const string COMMA_SYMBOL_IN_A_BOX_OF_CSV_FILE = "<nc>";
        private const string REPLACE_STRING_IN_TEXT_FOR_BREAK_LINE = "\n";
        private const string REPLACE_STRING_IN_TEXT_FOR_COMMA = ",";
        private const char BREAK_LINE_ESCAPE = '\n';
        private const char NEW_COLUMN_ESCAPE = ',';


        public static string[] GetArrayDataFollowPerRow(string fileContents)
        {
            return fileContents.Split(BREAK_LINE_ESCAPE);
        }


        public static ColumnData[] GetArrayDataFollowPerColumn(string fileContents)
        {
            string[] arrayDataFollowPerRow = GetArrayDataFollowPerRow(fileContents);
            string[] arrayHeader = GetColumnNamesOfHeader(arrayDataFollowPerRow);
            int numberColumns = arrayHeader.Length;
            int numberRows = arrayDataFollowPerRow.Length;
            ColumnData[] columnDatas = new ColumnData[numberColumns];

            for (int column = 0; column < numberColumns; column++)
            {
                string[] dataInAColumn = new string[numberRows - 1];

                for (int row = 1; row < numberRows; row++)
                {
                    dataInAColumn[row - 1] = GetArrayDataInARow(arrayDataFollowPerRow[row])[column];
                }

                columnDatas[column] = new ColumnData(arrayHeader[column], dataInAColumn);
            }

            return columnDatas;
        }


        public static ColumnData GetDataForAColumn(string fileContents, string conlumnName)
        {
            ColumnData[] columnDatas = GetArrayDataFollowPerColumn(fileContents);
            int numberColumn = columnDatas.Length;

            for (int i = 0; i < numberColumn; i++)
            {
                if(columnDatas[i].ColumnName == conlumnName)
                {
                    return columnDatas[i];
                }
            }

            return null;
        }


        public static ColumnData GetDataForAColumn(string fileContents, int comlumnIndex)
        {
            ColumnData[] columnDatas = GetArrayDataFollowPerColumn(fileContents);
            
            if (comlumnIndex >= columnDatas.Length)
            {
                return null;
            }

            return columnDatas[comlumnIndex];
        }


        public static string[] GetColumnNamesOfHeader(string[] arrayDataFollowPerRow)
        {
            return arrayDataFollowPerRow[0].Split(NEW_COLUMN_ESCAPE);
        }


        public static string[] GetArrayDataInARow(string dataInThisRow)
        {
            return dataInThisRow.Split(NEW_COLUMN_ESCAPE);
        }


        public static string ReplaceStringInABoxOfCSVFileIntoUnityText(string stringInABox)
        {
            return stringInABox
                .Replace(BREAK_LINE_SYMBOL_IN_A_BOX_OF_CSV_FILE, REPLACE_STRING_IN_TEXT_FOR_BREAK_LINE)
                .Replace(COMMA_SYMBOL_IN_A_BOX_OF_CSV_FILE, REPLACE_STRING_IN_TEXT_FOR_COMMA);
        }
    }
}
