using UnityEngine;
using System.Collections;
using System.Collections.Generic;


public class WordBank {

    public IDictionary<string, string> words = new Dictionary<string, string>();

    public string[] phrase;

    public IList<string> what = new List<string>();
    public IList<string> where = new List<string>();
    public IList<string> when = new List<string>();
    public IList<string> who = new List<string>();

    int index = 0;

    public KeyValuePair<string, string> this[int i]
    {
        get {
            IList<string> wordList = null;
            do {
                switch (i)
                {
                    case 0:
                        wordList = what;
                        break;
                    case 1:
                        wordList = where;
                        break;
                    case 2:
                        wordList = when;
                        break;
                    default:
                        wordList = who;
                        break;
                }
                
            } while ((wordList == null || wordList.Count == 0) && what.Count > 0 && where.Count > 0 && when.Count > 0 && who.Count > 0);

            string wordKey = wordList[0];
            wordList.RemoveAt(0);
            return new KeyValuePair<string, string>(wordKey, words[wordKey]);
        }
    }

    public string GetWord(string type)
    {
        IList<string> wordList = null;
        switch (type)
        {
            case "who":
                wordList = who;
                break;
            case "what":
                wordList = what;
                break;
            case "where":
                wordList = where;
                break;
            case "when":
                wordList = when;
                break;
        }
        if (wordList.Count == 0) return string.Empty;
        string wordKey = wordList[0];
        wordList.RemoveAt(0);
        return wordKey;
    }

    public IEnumerable<TValue> RandomValues<TKey, TValue>(IDictionary<TKey, TValue> dict)
    {
        System.Random rand = new System.Random();
        List<TValue> values = System.Linq.Enumerable.ToList(dict.Values);
        int size = dict.Count;
        while (true)
        {
            yield return values[rand.Next(size)];
        }
    }

    public WordBank () {
        CreateWhatWords();
        CreateWhenWords();
        CreateWhereWords();
        CreateWhoWords();
	}

    private void CreateWhatWords()
    {
        //Put a word + phrase type in the dictionary using words.Add(string, string), and to the list for what.Add(string)
        words.Add("summoned a spirit", "what");
        what.Add("summoned a spirit");

        words.Add("sat quietly", "what");
        what.Add("sat quietly");

        words.Add("prayed", "what");
        what.Add("prayed");

        words.Add("ran", "what");
        what.Add("ran");

        words.Add("howled", "what");
        what.Add("howled");

        words.Add("sang", "what");
        what.Add("sang");

        words.Add("died", "what");
        what.Add("died");

        words.Add("galloped", "what");
        what.Add("galloped");

        words.Add("watched hungrily", "what");
        what.Add("watched hungrily");

        words.Add("crushed people", "what");
        what.Add("crushed people");

        words.Add("danced", "what");
        what.Add("danced");

        words.Add("planted roses", "what");
        what.Add("planted roses");

        words.Add("read poetry", "what");
        what.Add("read poetry");

        words.Add("performed naughty things", "what");
        what.Add("performed naughty things");

        words.Add("smoked", "what");
        what.Add("smoked");

        words.Add("whispered slowly", "what");
        what.Add("whispered slowly");

        words.Add("vanished", "what");
        what.Add("vanished");

        words.Add("fooled around", "what");
        what.Add("fooled around");

        words.Add("ate cereal", "what");
        what.Add("ate cereal");

        words.Add("defeated the evil mage", "what");
        what.Add("defeated the evil mage");

    }

    private void CreateWhenWords()
    {
        words.Add("at midnight", "when");
        when.Add("at midnight");

        words.Add("while others slept", "when");
        when.Add("while others slept");

        words.Add("all day long", "when");
        when.Add("all day long");

        words.Add("during lunch", "when");
        when.Add("during lunch");

        words.Add("at tea time", "when");
        when.Add("at tea time");

        words.Add("during showtime", "when");
        when.Add("during showtime");

        words.Add("at dusk", "when");
        when.Add("at dusk");

        words.Add("while on a coffee break", "when");
        when.Add("while on a coffee break");

        words.Add("tomorrow", "when");
        when.Add("tomorrow");

        words.Add("before breakfast", "when");
        when.Add("before breakfast");

        words.Add("last week", "when");
        when.Add("last week");

        words.Add("in July", "when");
        when.Add("in July");

        words.Add("during brunch", "when");
        when.Add("during brunch");

        words.Add("while the rooster sang", "when");
        when.Add("while the rooster sang");

        words.Add("while the children played", "when");
        when.Add("while the children played");

        words.Add("during my birthday", "when");
        when.Add("during my birthday");

        words.Add("at bedtime", "when");
        when.Add("at bedtime");

        words.Add("all the time", "when");
        when.Add("all the time");

        words.Add("at highmoon", "when");
        when.Add("at highmoon");

        words.Add("at the darkest hour", "when");
        when.Add("at the darkest hour");
    }

    private void CreateWhereWords()
    {
        words.Add("in the basement", "where");
        where.Add("in the basement");

        words.Add("by the window", "where");
        where.Add("by the window");

        words.Add("within the chapel", "where");
        where.Add("within the chapel");

        words.Add("at the factory", "where");
        where.Add("at the factory");

        words.Add("in the void", "where");
        where.Add("in the void");

        words.Add("at the concert hall", "where");
        where.Add("at the concert hall");

        words.Add("in the center of town", "where");
        where.Add("in the center of town");

        words.Add("by the rainbow", "where");
        where.Add("by the rainbow");

        words.Add("from the abyss", "where");
        where.Add("from the abyss");

        words.Add("in the village", "where");
        where.Add("in the village");

        words.Add("at the ceremony", "where");
        where.Add("at the ceremony");

        words.Add("in the garden", "where");
        where.Add("in the garden");

        words.Add("at the dog park", "where");
        where.Add("at the dog park");

        words.Add("in the bathroom", "where");
        where.Add("in the bathroom");

        words.Add("by the room", "where");
        where.Add("by the room");

        words.Add("in the L'Hospital", "where");
        where.Add("in the L'Hospital");

        words.Add("in the desert", "where");
        where.Add("in the desert");

        words.Add("at the beach", "where");
        where.Add("at the beach");

        words.Add("in the attic", "where");
        where.Add("in the attic");

        words.Add("in the castle", "where");
        where.Add("in the castle");
    }

    private void CreateWhoWords()
    {
        words.Add("the occultist", "who");
        who.Add("the occultist");

        words.Add("the cat", "who");
        who.Add("the cat");

        words.Add("the troubled cleric", "who");
        who.Add("the troubled cleric");

        words.Add("the vile machine", "who");
        who.Add("the vile machine");

        words.Add("the spooked spirit", "who");
        who.Add("The Spooked Spirit");

        words.Add("the muse", "who");
        who.Add("the muse");

        words.Add("the cowboy", "who");
        who.Add("the cowboy");

        words.Add("the unicorn", "who");
        who.Add("the unicorn");

        words.Add("the eyes", "who");
        who.Add("the eyes");

        words.Add("the monster", "who");
        who.Add("the monster");

        words.Add("Abraham Lincoln", "who");
        who.Add("Abraham Lincoln");

        words.Add("Jacob", "who");
        who.Add("Jacob");

        words.Add("Cecil", "who");
        who.Add("Cecil");

        words.Add("the cherry", "who");
        who.Add("the cherry");

        words.Add("the children", "who");
        who.Add("the children");

        words.Add("the butcher", "who");
        who.Add("the butcher");

        words.Add("the corrupt politician", "who");
        who.Add("the corrupt politician");

        words.Add("Barney", "who");
        who.Add("Barney");

        words.Add("I", "who");
        who.Add("I");

        words.Add("the hero", "who");
        who.Add("the hero");

    }
	
}
