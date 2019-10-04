using System.Collections.Generic;
using WebServer.DTOS;
using WebServer.Controllers;
using System;

namespace WebServer.Models
{
    public class Frequency
    {
        public static IDictionary<char, LetterFrequency> Statistic;
        public Data data;
        // This constructor accuires data from vk api and sets dictionary for letters
        public Frequency(Data data)
        {
            this.data = data;
            Statistic = new Dictionary<char, LetterFrequency>();
            Statistic.Add('а', new LetterFrequency { Letter = 'а', Count = 0 });
            Statistic.Add('б', new LetterFrequency { Letter = 'б', Count = 0 });
            Statistic.Add('в', new LetterFrequency { Letter = 'в', Count = 0 });
            Statistic.Add('г', new LetterFrequency { Letter = 'г', Count = 0 });
            Statistic.Add('д', new LetterFrequency { Letter = 'д', Count = 0 });
            Statistic.Add('е', new LetterFrequency { Letter = 'е', Count = 0 });
            Statistic.Add('ё', new LetterFrequency { Letter = 'ё', Count = 0 });
            Statistic.Add('ж', new LetterFrequency { Letter = 'ж', Count = 0 });
            Statistic.Add('з', new LetterFrequency { Letter = 'з', Count = 0 });
            Statistic.Add('и', new LetterFrequency { Letter = 'и', Count = 0 });
            Statistic.Add('й', new LetterFrequency { Letter = 'й', Count = 0 });
            Statistic.Add('к', new LetterFrequency { Letter = 'к', Count = 0 });
            Statistic.Add('л', new LetterFrequency { Letter = 'л', Count = 0 });
            Statistic.Add('м', new LetterFrequency { Letter = 'м', Count = 0 });
            Statistic.Add('н', new LetterFrequency { Letter = 'н', Count = 0 });
            Statistic.Add('о', new LetterFrequency { Letter = 'о', Count = 0 });
            Statistic.Add('п', new LetterFrequency { Letter = 'п', Count = 0 });
            Statistic.Add('р', new LetterFrequency { Letter = 'р', Count = 0 });
            Statistic.Add('с', new LetterFrequency { Letter = 'с', Count = 0 });
            Statistic.Add('т', new LetterFrequency { Letter = 'т', Count = 0 });
            Statistic.Add('у', new LetterFrequency { Letter = 'у', Count = 0 });
            Statistic.Add('ф', new LetterFrequency { Letter = 'ф', Count = 0 });
            Statistic.Add('х', new LetterFrequency { Letter = 'х', Count = 0 });
            Statistic.Add('ц', new LetterFrequency { Letter = 'ц', Count = 0 });
            Statistic.Add('ш', new LetterFrequency { Letter = 'ш', Count = 0 });
            Statistic.Add('щ', new LetterFrequency { Letter = 'щ', Count = 0 });
            Statistic.Add('ъ', new LetterFrequency { Letter = 'ъ', Count = 0 });
            Statistic.Add('ы', new LetterFrequency { Letter = 'ы', Count = 0 });
            Statistic.Add('ь', new LetterFrequency { Letter = 'ь', Count = 0 });
            Statistic.Add('э', new LetterFrequency { Letter = 'э', Count = 0 });
            Statistic.Add('ю', new LetterFrequency { Letter = 'ю', Count = 0 });
            Statistic.Add('я', new LetterFrequency { Letter = 'я', Count = 0 });
        }
        // This method counts letters for posts
        public string CountLetters()
        {
            string result = "";
            string statics = "";
            foreach (PostDTO id in data.deserealizeResponse.response.items)
            {
                result += id.text;
            }
            result.ToLower();

            foreach (char c in result)
            {
                if (Frequency.Statistic.ContainsKey(c))
                {
                    Frequency.Statistic[c].Count++;
                }
            }

            foreach (char c in Statistic.Keys)
            {
                statics += (" " + c + " Count = " + Statistic[c].Count);
            }
            return statics;
        }
    }
}