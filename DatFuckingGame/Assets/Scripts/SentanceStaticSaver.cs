using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

public static class SentanceStaticSaver
{
    public static int TotalMatches;
    public static List<string> Sentances = new List<string>();

    public static void Clear()
    {
        TotalMatches = 0;
        Sentances = new List<string>();
    }
}

