namespace CsvTask;

internal class CsvToHtmlParser
{
    static void Main(string[] args)
    {
        string path = "..\\..\\..\\"; 

        using StreamReader streamReader = new(path + "input.csv");

        string currentLine;
        string cell = string.Empty;
        bool isInsideQuotes = false;

        using StreamWriter streamWriter = new StreamWriter(path + "output.html");

        SetHeadTags(streamWriter);

        while ((currentLine = streamReader.ReadLine()) != null)
        {
            streamWriter.WriteLine("<tr>");
            cell = string.Empty;

            for (int i = 0; i < currentLine.Length; i++)
            {
                if (currentLine[i] == '"' && !isInsideQuotes)
                {
                    isInsideQuotes = true;
                    continue;
                }

                if (isInsideQuotes)
                {
                    if (i + 1 < currentLine.Length && currentLine[i + 1] == '"' && currentLine[i] == '"')
                    {
                        cell += '"';
                        i++;
                        continue;
                    }

                    if (currentLine[i] == '"')
                    {
                        isInsideQuotes = false;
                        continue;
                    }

                    if (i == currentLine.Length - 1)
                    {
                        cell += currentLine[i]+"</br>";
                        i = -1;
                        currentLine = streamReader.ReadLine();
                        
                        continue;
                    }

                    cell += GetHtmlSymbolCodes(currentLine[i]);
                }
                else
                {
                    if (currentLine[i] == ',')
                    {
                        streamWriter.WriteLine("    <td>" + cell + "</td>");
                        cell = "";
                    }
                    else
                    {
                        cell += GetHtmlSymbolCodes(currentLine[i]);
                    }
                }
            }

            streamWriter.WriteLine("    <td>" + cell + "</td>");
            streamWriter.WriteLine("</tr>");
        }

        SetBottomTags(streamWriter);
    }
    
    public static void SetHeadTags(StreamWriter streamWriter)
    {
        streamWriter.WriteLine("<!DOCTYPE HTML>");
        streamWriter.WriteLine("<html>");
        streamWriter.WriteLine("<head>");
        streamWriter.WriteLine("    <title></title>");
        streamWriter.WriteLine("    <meta charset=\"utf-8\">");
        streamWriter.WriteLine("</head>");
        streamWriter.WriteLine("<body>");
        streamWriter.WriteLine("<table border=\"2\">");
    }

    public static void SetBottomTags(StreamWriter streamWriter)
    {

        streamWriter.WriteLine("</table>");
        streamWriter.WriteLine("</body>");
        streamWriter.Write("</html>");
    }

    public static string GetHtmlSymbolCodes(char literal) => literal switch
    {
        '<' => "&lt;",
        '>' => "&gt;",
        '&' => "&amp;",
        _ => string.Concat(literal)
    };
}