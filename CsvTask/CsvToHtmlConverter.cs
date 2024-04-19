namespace CsvTask;

public static class CsvToHtmlConverter
{
    public static void Convert(string inputCsvPath, string outputHtmlPath)
    {
        using StreamReader streamReader = new(inputCsvPath);
        using StreamWriter streamWriter = new(outputHtmlPath);

        WriteHeadTags(streamWriter);

        string? currentLine;
        bool isInsideQuotes = false;

        while ((currentLine = streamReader.ReadLine()) != null)
        {
            if (isInsideQuotes)
            {
                streamWriter.Write("<br/>");
            }
            else
            {
                streamWriter.WriteLine("<tr>");
                streamWriter.Write("\t<td>");
            }

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
                        streamWriter.Write('"');
                        i++;

                        continue;
                    }

                    if (currentLine[i] == '"')
                    {
                        isInsideQuotes = false;

                        continue;
                    }

                    WriteCharAsHtmlEntity(currentLine[i], streamWriter);
                }
                else
                {
                    if (currentLine[i] == ',')
                    {
                        streamWriter.WriteLine("</td>");
                        streamWriter.Write("\t<td>");
                    }
                    else
                    {
                        WriteCharAsHtmlEntity(currentLine[i], streamWriter);
                    }
                }
            }

            if (!isInsideQuotes)
            {
                streamWriter.WriteLine("</td>");
                streamWriter.WriteLine("</tr>");
            }
        }

        WriteBottomTags(streamWriter);
    }

    private static void WriteHeadTags(StreamWriter streamWriter)
    {
        streamWriter.WriteLine("<!DOCTYPE HTML>");
        streamWriter.WriteLine("<html>");
        streamWriter.WriteLine("<head>");
        streamWriter.WriteLine("\t<title>Данные из CSV файла в виде таблицы HTML</title>");
        streamWriter.WriteLine("\t<meta charset=\"utf-8\">");
        streamWriter.WriteLine("</head>");
        streamWriter.WriteLine("<body style=\"background-color:lightslategray\">");
        streamWriter.WriteLine("<table border=\"2\">");
    }

    private static void WriteBottomTags(StreamWriter streamWriter)
    {
        streamWriter.WriteLine("</table>");
        streamWriter.WriteLine("</body>");
        streamWriter.Write("</html>");
    }

    public static void WriteCharAsHtmlEntity(char character, StreamWriter streamWriter)
    {
        streamWriter.Write(character switch
        {
            '<' => "&lt;",
            '>' => "&gt;",
            '&' => "&amp;",
            _ => character.ToString()
        });
    }
}