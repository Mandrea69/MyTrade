using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;

namespace OANDA.Utilities
{
    public class AutoComplete
    {
        public static string Run()
        {

            List<Model.Instrument> instruments = Data.Instrument.AllFromFile().OrderBy(x => x.Name).ToList();
            var builder = new StringBuilder();
            var input = Console.ReadKey(intercept: true);
            int i = 0;
            Model.Instrument match = null;
            while (input.Key != ConsoleKey.Enter)
            {
                var currentInput = builder.ToString();
                if (input.Key == ConsoleKey.Tab)
                {
                  
                    if (i == 0)
                    {
                        match = instruments.FirstOrDefault(item => item.Name != currentInput && item.Name.StartsWith(currentInput, true, CultureInfo.InvariantCulture));
                        for (int y = 0; y < instruments.Count; y++)
                        {
                            if (instruments[y].Name == match.Name)
                            {

                                i = y;
                            }
                        }
                    }


                    else
                        match = instruments[i];

                    if (string.IsNullOrEmpty(match.Name))
                    {
                        input = Console.ReadKey(intercept: true);
                        continue;
                    }

                    ClearCurrentLine();
                    builder.Clear();

                    Console.Write(match.Name);
                    builder.Append(match.Name);
                    i += 1;
                }
                else
                {
                    if (input.Key == ConsoleKey.Backspace && currentInput.Length > 0)
                    {
                        builder.Remove(builder.Length - 1, 1);
                        ClearCurrentLine();

                        currentInput = currentInput.Remove(currentInput.Length - 1);
                        Console.Write(currentInput);
                    }
                    else
                    {
                        i = 0;
                        var key = input.KeyChar;
                        builder.Append(key);
                        Console.Write(key);
                    }
                }

                input = Console.ReadKey(intercept: true);
            }
           
            Console.Write(input.KeyChar);
            Console.WriteLine(match.Name);
            return match.Name;
        }

        /// <remarks>
        /// https://stackoverflow.com/a/8946847/1188513
        /// </remarks>>
        private static void ClearCurrentLine()
        {
            var currentLine = Console.CursorTop;
            Console.SetCursorPosition(0, Console.CursorTop);
            Console.Write(new string(' ', Console.WindowWidth));
            Console.SetCursorPosition(0, currentLine);
        }

    }
}

