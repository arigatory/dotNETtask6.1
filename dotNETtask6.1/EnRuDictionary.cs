using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace dotNETtask6._1
{
    class EnRuDictionary
    {
        TupleSet<string,string> wordPairs;

        public EnRuDictionary()
        {
            wordPairs = new TupleSet<string, string>
            {
                {"be","быть"},
                {"be","быть"},
                {"what","что"},
                {"you","ты"},
                {"you","вы"},
                {"but","но"},
                {"this","это"},
                {"just","только что"},
                {"just","просто"},
                {"other","другой"},
                {"different","другой"},
                {"be","быть"},
            };
        }

        public void Delete(string word)
        {
            wordPairs.RemoveWhere(v => v.itemEn == word || v.itemRu == word);
        }
        public void Add(string word, List<string> translation)
        {
            if (IsRussian(word))
            {
                AddRu(word,translation);
            }
            else
            {
                AddEn(word,translation);
            }
        }
        public void AddRu(string ruWord, List<string> enTranslation)
        {
            foreach (string s in enTranslation)
            {
                wordPairs.Add(s,ruWord);
            }
        }

        public void AddEn(string enWord, List<string> ruTranslation)
        {
            foreach (string s in ruTranslation)
            {
                wordPairs.Add(enWord,s);
            }
        }

        public List<string> GetTranslations(string word)
        {
            List<string> res = new List<string>();
            if (IsRussian(word))
            {
                foreach ((string itemEn, string itemRu) pair in wordPairs)
                {
                    if (pair.itemRu == word)
                    {
                        res.Add(pair.itemEn);
                    }
                }
            }
            else
            {
                foreach ((string itemEn, string itemRu) pair in wordPairs)
                {
                    if (pair.itemEn == word)
                    {
                        res.Add(pair.itemRu);
                    }
                }
            }

            return res;
        }

        public static bool IsRussian(string word)
        {
            if (Regex.IsMatch(word,"^[а-яА-Я]*$"))
            {
                return true;
            }
            else
            {
                return false;
            }
        }
        
        //для отладки
        public void Print()
        {
            SortedSet<string> enSet = new SortedSet<string>();
            foreach ((string itemEn, string itemRu) pair in wordPairs)
            {
                enSet.Add(pair.itemEn);
            }

            foreach (string s in enSet)
            {
                Console.WriteLine($"{s}:");
                foreach ((string itemEn, string itemRu) pair in wordPairs)
                {
                    if (s == pair.itemEn)
                        Console.WriteLine($"   {pair.Item2}");
                }
            }
        }
        
        private class TupleSet<T1,T2>:SortedSet<(T1 itemEn,T2 itemRu)>
        {
            public void Add(T1 itemEn, T2 itemRu)
            {
                Add((itemEn,itemRu));
            }
        }
    }
}
