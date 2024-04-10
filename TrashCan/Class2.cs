using CsvTask;


public static class CsvToHtmlConverter
{
    public static void Convert(string input, string output)
    {
        using StreamReader streamReader = new(input);
        using StreamWriter streamWriter = new(output);

        WriteHeadTags(streamWriter);

        string currentLine;
        bool isInsideQuotes = false;

        while ((currentLine = streamReader.ReadLine()) != null)
        {
            streamWriter.WriteLine("<tr>");
            streamWriter.Write("\t<td>");

            for (int i = 0; i < currentLine.Length; i++)
            {
                if (currentLine[i] == '"' && !isInsideQuotes)
                {
                    isInsideQuotes = true;

                    if (i == currentLine.Length - 1)
                    {
                        streamWriter.Write("<br/>");
                        i = -1;
                        currentLine = streamReader.ReadLine();

                        while (currentLine.Length == 0)
                        {
                            streamWriter.Write("<br/>");
                            currentLine = streamReader.ReadLine();
                        }
                    }

                    continue;
                }

                if (isInsideQuotes)
                {
                    if (i + 1 < currentLine.Length && currentLine[i + 1] == '"' && currentLine[i] == '"')
                    {
                        streamWriter.Write('"');
                        i++;

                        if (i == currentLine.Length - 1)
                        {
                            streamWriter.Write(currentLine[i] + "<br/>");
                            i = -1;
                            currentLine = streamReader.ReadLine();

                            while (currentLine.Length == 0)
                            {
                                streamWriter.Write("<br/>");
                                currentLine = streamReader.ReadLine();
                            }

                            continue;
                        }

                        continue;
                    }

                    if (currentLine[i] == '"')
                    {
                        isInsideQuotes = false;
                        continue;
                    }

                    if (i == currentLine.Length - 1)
                    {
                        streamWriter.Write(currentLine[i] + "<br/>");
                        i = -1;
                        currentLine = streamReader.ReadLine();

                        while (currentLine.Length == 0)
                        {
                            streamWriter.Write("<br/>");
                            currentLine = streamReader.ReadLine();
                        }

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

            streamWriter.WriteLine("</td>");
            streamWriter.WriteLine("</tr>");
        }

        WriteBottomTags(streamWriter);
        Console.WriteLine("Parsing is done");
        Console.ReadKey();
    }

    public static void WriteHeadTags(StreamWriter streamWriter)
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

    public static void WriteBottomTags(StreamWriter streamWriter)
    {
        streamWriter.WriteLine("</table>");
        streamWriter.WriteLine("</body>");
        streamWriter.Write("</html>");
    }

    public static void WriteCharAsHtmlEntity(char character, StreamWriter streamWriter)
    {
        switch (character)
        {
            case '<':
                streamWriter.Write("&lt;");
                break;
            case '>':
                streamWriter.Write("&gt;");
                break;
            case '&':
                streamWriter.Write("&amp;");
                break;
            default:
                streamWriter.Write(character);
                break;
        }
    }
}