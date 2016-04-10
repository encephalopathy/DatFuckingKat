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

        //1
        words.Add("summoned a spirit", "what");
        what.Add("summoned a spirit");

        //2
        words.Add("sat quietly", "what");
        what.Add("sat quietly");

        //3
        words.Add("prayed", "what");
        what.Add("prayed");

        //4
        words.Add("ran", "what");
        what.Add("ran");

        //4
        words.Add("howled", "what");
        what.Add("howled");

        //5
        words.Add("sang", "what");
        what.Add("sang");
        
        //6
        words.Add("died", "what");
        what.Add("died");

        //7
        words.Add("galloped", "what");
        what.Add("galloped");

        //8
        words.Add("watched hungrily", "what");
        what.Add("watched hungrily");

        //9
        words.Add("crushed people", "what");
        what.Add("crushed people");

        //10
        words.Add("danced", "what");
        what.Add("danced");

        //11
        words.Add("planted roses", "what");
        what.Add("planted roses");

        //12
        words.Add("read poetry", "what");
        what.Add("read poetry");

        //13
        words.Add("performed naughty things", "what");
        what.Add("performed naughty things");

        //14
        words.Add("smoked", "what");
        what.Add("smoked");

        //15
        words.Add("whispered slowly", "what");
        what.Add("whispered slowly");

        //16
        words.Add("vanished", "what");
        what.Add("vanished");

        //17
        words.Add("fooled around", "what");
        what.Add("fooled around");

        //18
        words.Add("ate cereal", "what");
        what.Add("ate cereal");

        //19
        words.Add("defeated the evil mage", "what");
        what.Add("defeated the evil mage");

        //20
        words.Add("wandered around", "what");
        what.Add("wandered around");

        //21
        words.Add("got bored", "what");
        what.Add("got bored");

        //22
        words.Add("became president", "what");
        what.Add("became president");

        //23
        words.Add("went to jail", "what");
        what.Add("went to jail");

        //24
        words.Add("got drunk", "what");
        what.Add("got drunk");

        //25
        words.Add("stole money", "what");
        what.Add("stole money");

        //26
        words.Add("enveloped the target", "what");
        what.Add("enveloped the target");

        //27
        words.Add("is playing DAT FUCKING KAT", "what");
        what.Add("is playing DAT FUCKING KAT");

        //28
        words.Add("dug a hole", "what");
        what.Add("dug a hole");

        //29
        words.Add("radiated arrogance", "what");
        what.Add("radiated arrogance");

        //30
        words.Add("did not sleep", "what");
        what.Add("did not sleep");

        //31
        words.Add("got cancer", "what");
        what.Add("got cancer");

        //32
        words.Add("became worthless", "what");
        what.Add("became worthless");
    }

    private void CreateWhenWords()
    {
        //1
        words.Add("at midnight", "when");
        when.Add("at midnight");

        //2
        words.Add("while others slept", "when");
        when.Add("while others slept");

        //3
        words.Add("all day long", "when");
        when.Add("all day long");

        //4
        words.Add("during lunch", "when");
        when.Add("during lunch");

        //5
        words.Add("at tea time", "when");
        when.Add("at tea time");

        //6
        words.Add("during showtime", "when");
        when.Add("during showtime");

        //7
        words.Add("at dusk", "when");
        when.Add("at dusk");

        //8
        words.Add("while on a coffee break", "when");
        when.Add("while on a coffee break");

        //9
        words.Add("tomorrow", "when");
        when.Add("tomorrow");

        //10
        words.Add("before breakfast", "when");
        when.Add("before breakfast");

        //11
        words.Add("last week", "when");
        when.Add("last week");

        //12
        words.Add("in July", "when");
        when.Add("in July");

        //13
        words.Add("during brunch", "when");
        when.Add("during brunch");

        //14
        words.Add("while the rooster sang", "when");
        when.Add("while the rooster sang");

        //15
        words.Add("while the children played", "when");
        when.Add("while the children played");

        //16
        words.Add("during my birthday", "when");
        when.Add("during my birthday");

        //17
        words.Add("at bedtime", "when");
        when.Add("at bedtime");

        //18
        words.Add("all the time", "when");
        when.Add("all the time");

        //19
        words.Add("at highmoon", "when");
        when.Add("at highmoon");

        //20
        words.Add("at the darkest hour", "when");
        when.Add("at the darkest hour");

        //21
        words.Add("after dinner time", "when");
        when.Add("after dinner time");

        //22
        words.Add("after the party", "when");
        when.Add("after the party");

        //23
        words.Add("before the world ended", "when");
        when.Add("before the world ended");

        //24
        words.Add("in a few seconds", "when");
        when.Add("in a few seconds");

        //25
        words.Add("during the showdown", "when");
        when.Add("during the showdown");

        //26
        words.Add("right now", "when");
        when.Add("right now");

        //27
        words.Add("before falling asleep", "when");
        when.Add("before falling asleep");

        //28
        words.Add("during detention", "when");
        when.Add("during detention");

        //29
        words.Add("at sunrise", "when");
        when.Add("at sunrise");

        //30
        words.Add("sometimes", "when");
        when.Add("sometimes");

        //31
        words.Add("after a good fart", "when");
        when.Add("after a good fart");

        //32
        words.Add("after yoga practice", "when");
        when.Add("after yoga practice");
    }

    private void CreateWhereWords()
    {
        //1
        words.Add("in the basement", "where");
        where.Add("in the basement");

        //2
        words.Add("by the window", "where");
        where.Add("by the window");

        //3
        words.Add("within the chapel", "where");
        where.Add("within the chapel");
        
        //4
        words.Add("at the factory", "where");
        where.Add("at the factory");

        //5
        words.Add("in the void", "where");
        where.Add("in the void");

        //6
        words.Add("at the concert hall", "where");
        where.Add("at the concert hall");

        //7
        words.Add("in the center of town", "where");
        where.Add("in the center of town");

        //8
        words.Add("by the rainbow", "where");
        where.Add("by the rainbow");

        //9
        words.Add("from the abyss", "where");
        where.Add("from the abyss");

        //10
        words.Add("in the village", "where");
        where.Add("in the village");

        //11
        words.Add("at the ceremony", "where");
        where.Add("at the ceremony");

        //12
        words.Add("in the garden", "where");
        where.Add("in the garden");

        //13
        words.Add("at the dog park", "where");
        where.Add("at the dog park");

        //14
        words.Add("in the bathroom", "where");
        where.Add("in the bathroom");

        //15
        words.Add("by the room", "where");
        where.Add("by the room");

        //16
        words.Add("in the L'Hospital", "where");
        where.Add("in the L'Hospital");

        //17
        words.Add("in the desert", "where");
        where.Add("in the desert");

        //18
        words.Add("at the beach", "where");
        where.Add("at the beach");

        //19
        words.Add("in the attic", "where");
        where.Add("in the attic");

        //20
        words.Add("in the castle", "where");
        where.Add("in the castle");

        //21
        words.Add("in heaven", "where");
        where.Add("in heaven");

        //22
        words.Add("somewhere in downtown", "where");
        where.Add("somewhere in downtown");

        //23
        words.Add("in hell", "where");
        where.Add("in hell");

        //24
        words.Add("near asia", "where");
        where.Add("near asia");

        //25
        words.Add("at my mom's house", "where");
        where.Add("at my mom's house");

        //26
        words.Add("on the plateau", "where");
        where.Add("on the plateau");

        //27
        words.Add("on the computer", "where");
        where.Add("on the computer");

        //28
        words.Add("beyond the 3rd dimension", "where");
        where.Add("beyond the 3rd dimension");

        //29
        words.Add("in hogwarts", "where");
        where.Add("in hogwarts");

        //30
        words.Add("within a wet dream", "where");
        where.Add("within a wet dream");

        //31
        words.Add("in the alley", "where");
        where.Add("in the alley");

        //32
        words.Add("by the strip club", "where");
        where.Add("by the strip club");
    }

    private void CreateWhoWords()
    {
        //1
        words.Add("the occultist", "who");
        who.Add("the occultist");

        //2
        words.Add("the cat", "who");
        who.Add("the cat");

        //3
        words.Add("the troubled cleric", "who");
        who.Add("the troubled cleric");

        //4
        words.Add("the vile machine", "who");
        who.Add("the vile machine");

        //5
        words.Add("the spooked spirit", "who");
        who.Add("The Spooked Spirit");

        //6
        words.Add("the muse", "who");
        who.Add("the muse");

        //7
        words.Add("the cowboy", "who");
        who.Add("the cowboy");

        //8
        words.Add("the unicorn", "who");
        who.Add("the unicorn");

        //9
        words.Add("the eyes", "who");
        who.Add("the eyes");

        //10
        words.Add("the monster", "who");
        who.Add("the monster");

        //11
        words.Add("Abraham Lincoln", "who");
        who.Add("Abraham Lincoln");

        //12
        words.Add("Jacob", "who");
        who.Add("Jacob");

        //13
        words.Add("Cecil", "who");
        who.Add("Cecil");

        //14
        words.Add("the cherry", "who");
        who.Add("the cherry");

        //15
        words.Add("the children", "who");
        who.Add("the children");

        //16
        words.Add("the butcher", "who");
        who.Add("the butcher");

        //17
        words.Add("the corrupt politician", "who");
        who.Add("the corrupt politician");

        //18
        words.Add("Barney", "who");
        who.Add("Barney");

        //19
        words.Add("I", "who");
        who.Add("I");

        //20
        words.Add("the hero", "who");
        who.Add("the hero");
        
        //21
        words.Add("the lonely demon", "who");
        who.Add("the lonely demon");

        //22
        words.Add("He", "who");
        who.Add("He");

        //23
        words.Add("Donald Trump", "who");
        who.Add("Donald Trump");

        //24
        words.Add("GODZILLA", "who");
        who.Add("GODZILLA");

        //25
        words.Add("the vandal", "who");
        who.Add("the vandal");

        //26
        words.Add("many cockroaches", "who");
        who.Add("many cockroaches");

        //27
        words.Add("the gamer", "who");
        who.Add("the gamer");

        //28
        words.Add("you", "who");
        who.Add("you");

        //29
        words.Add("my brother", "who");
        who.Add("my brother");

        //30
        words.Add("we", "who");
        who.Add("we");

        //31
        words.Add("the bitch", "who");
        who.Add("the bitch");

        //32
        words.Add("the old man", "who");
        who.Add("the old man");
    }
	
}
