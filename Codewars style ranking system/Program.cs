using System.Collections.Generic;
using System.Linq;
using System;

public class User
{
    private int _rank;
    public int progress { get; set; }
    public static Dictionary<int, int> availableRanks = new Dictionary<int, int> 
    { { 1, -8 }, { 2, -7 }, { 3, -6 }, { 4, -5 }, { 5, -4 }, { 6, -3 }, { 7, -2 }, { 8, -1 }, 
        { 9, 1 }, { 10, 2 }, { 11, 3 }, { 12, 4 }, { 13, 5 }, { 14, 6 }, { 15, 7 }, { 16, 8 } };

    public static void Main()
    {
        // Test
        User user = new();
        user.incProgress(-7);
        var t = user.progress;
        // ...should return 10
    }

    public User()
    {
        _rank = 1;
        progress = 0;
    }

    public int rank 
    { 
        get { return availableRanks[_rank]; } 
        set 
        { 
             _rank = value;

            if (_rank >= 16)
            {
                _rank = 16;
                progress = 0;
            }
        }
    }

    public void incProgress(int actRank)
    {
        if (!availableRanks.ContainsValue(actRank))
            throw new ArgumentException();

        int kataRank = availableRanks.First(x => x.Value == actRank).Key;
        int difference = kataRank - _rank;
        int points = difference switch
        {
            -1 => 1,
            0 => 3,
            >0 => 10 * difference * difference,
            _ => 0
        };

        int lvls = (progress + points) / 100;
        progress += points - lvls * 100;
        incRank(lvls);
    }

    private void incRank(int lvlsCount)
    {
        rank = _rank + lvlsCount;
    }
}