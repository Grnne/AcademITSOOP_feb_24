namespace CsvTask;

public static class CsvToHtmlParser
{
    public static void ParseCsvToHtml(string input, string output)
    {
        try
        {

            //if (i == currentLine.Length - 1)
            //{
            //    cell += currentLine[i] + "<br/>";
            //    i = -1;
            //    Console.WriteLine(currentLine);
            //    currentLine = streamReader.ReadLine();

            //    while (currentLine.Length == 0)
            //    {

            //        cell += "<br/>";
            //        currentLine = streamReader.ReadLine();
            //    }

            //    continue;
            //}



            using StreamReader streamReader = new(input);

            string cell = string.Empty;
            bool isInsideQuotes = false;

            using StreamWriter streamWriter = new(output);

            WriteHeadTags(streamWriter);

            string currentLine;

            while ((currentLine = streamReader.ReadLine()) != null)
            {
                streamWriter.WriteLine("<tr>");
                cell = string.Empty;

                for (int i = 0; i < currentLine!.Length; i++)
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

                        if (i == currentLine.Length - 1)
                        {
                            cell += currentLine[i] + "<br/>";
                            i = -1;
                            currentLine = streamReader.ReadLine();

                            continue;
                        }

                        cell += ConvertCharToHtmlEntity(currentLine[i]);
                    }
                    else
                    {
                        if (currentLine[i] == ',')
                        {
                            streamWriter.WriteLine("\t<td>" + cell + "</td>");
                            cell = "";
                        }
                        else
                        {
                            cell += ConvertCharToHtmlEntity(currentLine[i]);
                        }
                    }
                }

                streamWriter.WriteLine("\t<td>" + cell + "</td>");
                streamWriter.WriteLine("</tr>");
            }

            WriteBottomTags(streamWriter);
        }
        catch (FileNotFoundException)
        {
            Console.WriteLine("File not found, enter input and output file paths, input must be .csv and output - .html");
        }
    }

    public static void WriteHeadTags(StreamWriter streamWriter)
    {
        streamWriter.WriteLine("<!DOCTYPE HTML>");
        streamWriter.WriteLine("<html>");
        streamWriter.WriteLine("<head>");
        streamWriter.WriteLine("\t<title>Даже не знаю, что тут нужно писать</title>");
        streamWriter.WriteLine("\t<meta charset=\"utf-8\">");
        streamWriter.WriteLine("</head>");
        streamWriter.WriteLine("<body>");
        streamWriter.WriteLine("<table border=\"2\">");
    }

    public static void WriteBottomTags(StreamWriter streamWriter)
    {
        streamWriter.WriteLine("</table>");
        streamWriter.WriteLine("</body>");
        streamWriter.Write("</html>");
    }

    public static string ConvertCharToHtmlEntity(char character) => character switch
    {
        '<' => "&lt;",
        '>' => "&gt;",
        '&' => "&amp;",
        _ => character.ToString()
    };
}



