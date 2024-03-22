namespace CsvTask;

public static class CsvToHtmlParser
{
    public static void ParseCsvToHtml(string input, string output)
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
        streamWriter.WriteLine("\t<title>Даже не знаю, что тут нужно писать</title>");
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

    // Хотелось бы сюда погрузить дублирующийся код, но я имя не могу придумать
    public static void CheckLineEnd(int i, StreamWriter streamWriter, string currentLine) 
    {

    }

    // А тут поди прямо в кейсе можно писать в стрим? без вывода переменной
    public static void WriteCharAsHtmlEntity(char character, StreamWriter streamWriter)
    {
        string str = character switch
        {
            '<' => "&lt;",
            '>' => "&gt;",
            '&' => "&amp;",
            _ => character.ToString()
        };

        streamWriter.Write(str);
    }
}