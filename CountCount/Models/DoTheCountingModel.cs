using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace dms82
{
    public class DoTheCountingModel
    {
        private static int defaultSortValue = 4;
        private string text;
        private string internalMessage;
        private Dictionary<char, int> charCount = new Dictionary<char, int>();
        private Dictionary<string, int> wordCount = new Dictionary<string, int>();
        public int RadioAnswer1 { get; set; }
        public int RadioAnswer2 { get; set; }
        public int fetchCode { get; set; } = defaultSortValue;
        public void loadText(string textToLoad)
        {
            text = textToLoad;
        }

        public string fetchLoadedText()
        {
            return text;
        }

        private string countLoadedTextChars()
        {
            return text == null ? Environment.NewLine + "Unable to count words because no text has been loaded." : countChars(text);
        }

        private string countLoadedTextWords()
        {
            return text == null ? Environment.NewLine + "Unable to count words because no text has been loaded." : countWords(text);
        }

        private string countChars(string textToCount)
        {
            try
            {
                foreach (char c in textToCount)
                {
                    charCount.TryGetValue(c, out int currentCount);
                    charCount[c] = currentCount + 1;
                }
                return Environment.NewLine + "The character count succeeded.";
            }
            catch
            {
                return Environment.NewLine + "The character count failed.";
            }
        }

        private string countWords(string textToCount)
        {
            try
            {
                string[] eachWord = textToCount.Split();
                foreach (string word in eachWord)
                {
                    wordCount.TryGetValue(word, out int currentCount);
                    wordCount[word] = currentCount + 1;
                }
                return Environment.NewLine + "The word count succeeded."; 
            }
            catch
            {
                return Environment.NewLine + "The word count failed."; 
            }
        }
        public IDictionary<string, int> fetchCountedWords(bool forceRefresh = false)
        {
            try
            {
                internalMessage += forceRefresh ? countLoadedTextWords() : wordCount.Count() == 0 ? countLoadedTextWords() : "Successfully fetched word count.\n";
                return fetchCode == defaultSortValue ? wordCount : fetchWordSort(fetchCode);
            }
            catch
            {
                internalMessage += Environment.NewLine + "Unable to fetch the word count.";
                return null;
            }
        }
        public IDictionary<char, int> fetchCountedChars(bool forceRefresh = false)
        {
            try
            {
                internalMessage += forceRefresh ? countLoadedTextChars() : charCount.Count == 0 ? countLoadedTextChars() : "Successfully fetched character count.\n";
                return fetchCode == defaultSortValue ? charCount : fetchCharSort(fetchCode);                
            }
            catch
            {
                internalMessage += Environment.NewLine + "Unable to fetch the character count.";
                return null;
            }
        }
        public string readInternalMessage()
        {
            return internalMessage;
        }
        private IDictionary<string, int> fetchWordSort(int fetchCode)
        {
            Dictionary<string, int> temp = new Dictionary<string, int>();
            switch (fetchCode)
            {
                case 0:
                    foreach (KeyValuePair<string, int> item in wordCount.OrderBy(a => a.Key))
                    {
                        temp.Add(item.Key, item.Value);
                    }
                    break;
                case 1:
                    foreach (KeyValuePair<string, int> item in wordCount.OrderByDescending(a => a.Key))
                    {
                        temp.Add(item.Key, item.Value);
                    }
                    break;
                case 2:
                    foreach (KeyValuePair<string, int> item in wordCount.OrderBy(a => a.Value))
                    {
                        temp.Add(item.Key, item.Value);
                    }
                    break;
                case 3:
                default:
                    foreach (KeyValuePair<string, int> item in wordCount.OrderByDescending(a => a.Value))
                    {
                        temp.Add(item.Key, item.Value);
                    }
                    break;
            }
            return temp;
        }
        private IDictionary<char, int> fetchCharSort(int fetchCode)
        {
            Dictionary<char, int> temp = new Dictionary<char, int>();
            switch(fetchCode)
            {
                case 0:
                    foreach(KeyValuePair<char, int> item in charCount.OrderBy(a => a.Key))
                    {
                        temp.Add(item.Key, item.Value);
                    }
                    break;
                case 1:
                    foreach (KeyValuePair<char, int> item in charCount.OrderByDescending(a => a.Key))
                    {
                        temp.Add(item.Key, item.Value);
                    }
                    break;
                case 2:
                    foreach (KeyValuePair<char, int> item in charCount.OrderBy(a => a.Value))
                    {
                        temp.Add(item.Key, item.Value);
                    }
                    break;
                case 3:
                default:
                    foreach (KeyValuePair<char, int> item in charCount.OrderByDescending(a => a.Value))
                    {
                        temp.Add(item.Key, item.Value);
                    }
                    break;
            }
            return temp;
        }
    }
}
