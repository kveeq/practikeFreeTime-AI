using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Yields.indexators
{
    public class Word<T, Y>
    {
        public Word(T present, Y translated)
        {
            Key = present;
            Value = translated;
        }

        public T Key { get; set; }
        public Y Value { get; set; }

        public override string ToString()
        {
            return $"{Key.ToString()} - {Value.ToString()}";
        }
    }

    public class Dictionary<T, Y>
    {
        Word<T, Y>[] words;


        public Dictionary(Word<T, Y>[] word)
        {
            words = word;

            //words = new Word<T, Y>[]
            //{
            //    new Word<T, Y>("red", "красный"),
            //    new Word<string, string>("blue", "синий"),
            //    new Word<string, string>("green", "зеленый"),
            //    new Word<string, string>("excepstringion", "ошибка"),
            //    new Word<string, string>("word", "слово"),
            //    new Word<string, string>("whistringe", "белый"),
            //    new Word<string, string>("stringellow", "желтый"),
            //    new Word<string, string>("black", "черный"),
            //    new Word<string, string>("grastring", "серый"),
            //};
        }

        public int GetLength()
        {
            return words.Length;
        }

        public IEnumerator<Word<T, Y>> GetEnumerator()
        {
            foreach (var item in words)
            {
                yield return item;
            }
        }

        public Y this[T name]
        {
            get
            {
                foreach (var item in words)
                {
                    if (item.Key.Equals(name))
                        return item.Value;
                }
                return default;
            }
            set
            {
                foreach (var item in words)
                {
                    if (item.Key.Equals(name))
                        item.Value = value;
                }
            }
        }

        //public Word<T, Y> this[int index]
        //{
        //    get
        //    {
        //        if (index >= 0 && index < words.Length)
        //            return words[index];
        //        return null;
        //    }
        //}
    }
}
