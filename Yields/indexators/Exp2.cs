using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Yields.indexators
{
    public class Word
    {
        public Word(string present, string translated)
        {
            Present = present;
            Translated = translated;
        }

        public string Present { get; set; }
        public string Translated { get; set; }

        public override string ToString()
        {
            return $"{Present} - {Translated}";
        }
    }

    public class Dictionary
    {
        Word[] words;

        public Dictionary()
        {
            words = new Word[]
            {
                new Word("red", "красный"),
                new Word("blue", "синий"),
                new Word("green", "зеленый")
            };
        }

        public int GetLength()
        {
            return words.Length;
        }

        public string this[string name]
        {
            get
            {
                foreach (var item in words)
                {
                    if (item.Present == name)
                        return item.Translated;
                }
                return null;
            }
            set
            {
                foreach (var item in words)
                {
                    if (item.Present == name)
                        item.Translated = value;
                }
            }
        }

        public Word this[int index]
        {
            get
            {
                if (index >= 0 && index < words.Length)
                    return words[index];
                return null;
            }
        }
    }
}
