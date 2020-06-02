using System;
using System.Collections.Generic;
using System.Linq;

namespace Client
{
    static class Message
    {
        public enum FormatType { Normal, Bold, Italic, Strike, Underlined };
        private static FormatEventHandler onRecieveMessage;

        public static void SubscribeToMessageReciever(FormatEventHandler handler)
        {
            onRecieveMessage += new FormatEventHandler(handler);
        }

        public static void RecieveMessage(string username, string message)
        {
            var formattedStringAsList = FormatString(message);

            onRecieveMessage?.Invoke(username, formattedStringAsList);
        }

        private static List<Tuple<string, string>> FormatString(string s)
        {
            var intervals = GetIntervals(GetValidSymbolsPositions(s));

            var list = new List<Tuple<string, string>>();

            if (intervals.Count > 0)
            {
                if (intervals.Last().Item3 != s.Length - 1) // the last interval might be left out if it's not formatted
                    intervals.Add(Tuple.Create("", intervals.Last().Item3, s.Length));

                foreach (Tuple<string, int, int> tuple in intervals)
                {
                    string formatting = tuple.Item1;
                    int firstPosition = tuple.Item2 + 1;
                    int stringLegth = tuple.Item3 - firstPosition;

                    list.Add(Tuple.Create(formatting, s.Substring(firstPosition, stringLegth)));
                }
            }
            else
            {
                list.Add(Tuple.Create("", s));
            }
            return list;
        }

        private static List<Tuple<char, int>> GetValidSymbolsPositions(string s)
        {
            var list = new List<Tuple<char, int>>();

            string symbols = "*~`_"; // all the symbols used for formatting


            var symbolCount = new Dictionary<char, int>();

            foreach (char c in symbols)
                symbolCount.Add(c, 0);


            for (int i = 0; i < s.Length; ++i)               // for each character of the message
            {
                if (symbols.Contains(s[i]))                // if the character is a symbol
                {
                    list.Add(Tuple.Create(s[i], i));     // it is added along with its position inside a list
                    symbolCount[s[i]]++;                // and its number of apparitions is incremented 
                }
            }

            foreach (KeyValuePair<char, int> pair in symbolCount)    // for each (symbol, position) pair
            {
                var symbol = pair.Key;
                var apparitions = pair.Value;

                if (apparitions % 2 == 1)                          // if the current symbol appears for an odd number of times
                {
                    for (int i = list.Count - 1; i > -1; --i)      // its last apparition is removed from the list
                        if (list[i].Item1 == symbol)
                        {
                            list.RemoveAt(i);
                            break;
                        }
                }
            }

            return list;
        }

        private static List<Tuple<string, int, int>> GetIntervals(List<Tuple<char, int>> symbolsPositions)
        {
            // this part is hard to explain y'all, but it kinda works xD

            var list = new List<Tuple<string, int, int>>();

            var openedSymbols = new Dictionary<char, int>();

            int highestPositionReached = 0;

            foreach (Tuple<char, int> tuple in symbolsPositions)
            {
                var symbol = tuple.Item1;
                var position = tuple.Item2;

                if (openedSymbols.Count > 0) // if there's "opened" symbols
                {
                    string formats = "";

                    foreach (KeyValuePair<char, int> pair in openedSymbols)  // the symbols in the dictionary tell how the current interval should be formatted
                        formats += pair.Key;

                    list.Add(Tuple.Create(formats, highestPositionReached, position));  // add the format, the position of the last symbol, and the position of the current symbol
                }

                if (openedSymbols.ContainsKey(symbol))
                    openedSymbols.Remove(symbol);
                else
                {
                    openedSymbols.Add(symbol, position);
                }

                if (position > highestPositionReached)
                    highestPositionReached = position;
            }


            for (int i = 0; i < list.Count - 1; ++i) // fills in the empty spaces between the formatted intervals with unformatted intevals
            {
                if (list[i].Item3 != list[i + 1].Item2)
                {
                    list.Insert(i + 1, Tuple.Create("", list[i].Item3, list[i + 1].Item2));
                }
            }

            return list;
        }

        public delegate void FormatEventHandler(string s, List<Tuple<string, string>> list);
    }


}
