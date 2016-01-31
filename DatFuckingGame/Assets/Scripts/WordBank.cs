using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class WordBank {

    public IDictionary<int, KeyValuePair<string, string>> words = new Dictionary<int, KeyValuePair<string, string>>();

    public IList<string> what = new List<string>();
    public IList<string> where = new List<string>();
    public IList<string> when = new List<string>();
    public IList<string> who = new List<string>();

    int index = 0;

    public IList<string> this[int i]
    {
        get {
            switch (i)
            {
                case 1:
                    return what;
                case 2:
                    return where;
                case 3:
                    return when;
                case 4:
                    return who;
            }
            return null;
        }
    }


    void Start () {
        CreateWhatWords();
        CreateWhenWords();
        CreateWhereWords();
        CreateWhoWords();
	}

    private void CreateWhatWords()
    {
        //Put a word + phrase type in the dictionary using words.Add(string, string), and to the list for what.Add(string)
        words.Add(index++, new KeyValuePair<string, string>("summoned a spirit", "what"));
        what.Add("summoned a spirit");

        words.Add(index++, new KeyValuePair<string, string>("sat quietly", "what"));
        what.Add("sat quietly");

        words.Add(index++, new KeyValuePair<string, string>("prayed", "what"));
        what.Add("prayed");

        words.Add(index++, new KeyValuePair<string, string>("ran", "what"));
        what.Add("ran");

        words.Add(index++, new KeyValuePair<string, string>("howled", "what"));
        what.Add("howled");

        words.Add(index++, new KeyValuePair<string, string>("sang", "what"));
        what.Add("sang");

        words.Add(index++, new KeyValuePair<string, string>("died", "what"));
        what.Add("died");

        words.Add(index++, new KeyValuePair<string, string>("galloped", "what"));
        what.Add("galloped");

        words.Add(index++, new KeyValuePair<string, string>("watched hungrily" , "what"));
        what.Add("watched hungrily");

    }

    private void CreateWhenWords()
    {
        words.Add(index++, new KeyValuePair<string, string>("at midnight", "when"));
        when.Add("at midnight");

        words.Add(index++, new KeyValuePair<string, string>("while others slept", "when"));
        when.Add("while others slept");

        words.Add(index++, new KeyValuePair<string, string>("all day long", "when"));
        when.Add("all day long");

        words.Add(index++, new KeyValuePair<string, string>("during lunch", "when"));
        when.Add("during lunch");

        words.Add(index++, new KeyValuePair<string, string>("at tea time", "when"));
        when.Add("at tea time");

        words.Add(index++, new KeyValuePair<string, string>("during showtime", "when"));
        when.Add("during showtime");

        words.Add(index++, new KeyValuePair<string, string>("at dusk", "when"));
        when.Add("at dusk");

        words.Add(index++, new KeyValuePair<string, string>("while on a coffee break", "when"));
        when.Add("while on a coffee break");

        words.Add(index++, new KeyValuePair<string, string>("tomorrow", "when"));
        when.Add("tomorrow");

    }

    private void CreateWhereWords()
    {
        words.Add(index++, new KeyValuePair<string, string>("in the basement", "where"));
        where.Add("in the basement");

        words.Add(index++, new KeyValuePair<string, string>("by the window", "where"));
        where.Add("by the window");

        words.Add(index++, new KeyValuePair<string, string>("within the chapel", "where"));
        where.Add("within the chapel");

        words.Add(index++, new KeyValuePair<string, string>("at the factory", "where"));
        where.Add("at the factory");

        words.Add(index++, new KeyValuePair<string, string>("in the void", "where"));
        where.Add("in the void");

        words.Add(index++, new KeyValuePair<string, string>("at the concert hall", "where"));
        where.Add("at the concert hall");

        words.Add(index++, new KeyValuePair<string, string>("in the center of town", "where"));
        where.Add("in the center of town");

        words.Add(index++, new KeyValuePair<string, string>("by the rainbow", "where"));
        where.Add("by the rainbow");

        words.Add(index++, new KeyValuePair<string, string>("from the abyss", "where"));
        where.Add("from the abyss");

    }

    private void CreateWhoWords()
    {
        words.Add(index++, new KeyValuePair<string, string>("the occultist", "who"));
        who.Add("the occultist");

        words.Add(index++, new KeyValuePair<string, string>("the cat", "who"));
        who.Add("the cat");

        words.Add(index++, new KeyValuePair<string, string>("the troubled cleric", "who"));
        who.Add("the troubled cleric");

        words.Add(index++, new KeyValuePair<string, string>("the vile machine", "who"));
        who.Add("the vile machine");

        words.Add(index++, new KeyValuePair<string, string>("the spooked spirit", "who"));
        who.Add("The Spooked Spirit");

        words.Add(index++, new KeyValuePair<string, string>("the muse", "who"));
        who.Add("the muse");

        words.Add(index++, new KeyValuePair<string, string>("the cowboy", "who"));
        who.Add("the cowboy");

        words.Add(index++, new KeyValuePair<string, string>("the unicorn", "who"));
        who.Add("the unicorn");

        words.Add(index++, new KeyValuePair<string, string>("the eyes", "who"));
        who.Add("the eyes");

    }
	
}
