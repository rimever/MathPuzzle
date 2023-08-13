namespace MathPuzzle;

public class Tests
{
    [SetUp]
    public void Setup()
    {
    }

    [Test]
    public void Q1()
    {
        for (var i = 11;; i += 2)
        {
            if (i.ToString() != Reverse(i.ToString())
                || Convert.ToString(i, 8) != Reverse(Convert.ToString(i, 8))
                || Convert.ToString(i, 2) != Reverse(Convert.ToString(i, 2))
               )
            {
                continue;
            }
            Console.WriteLine(i);
            break;
        }

        string Reverse(string i)
        {
            return new string(i.Reverse().ToArray());
        }
    }

    [Test]
    public void Q3()
    {
        var cards = new bool[100];
        for (var i = 1; i < cards.Length; ++i)
        {
            for (var j = i; j < cards.Length; j += i + 1)
            {
                cards[j] = !cards[j];
            }
        }

        Console.WriteLine(string.Join(",", Enumerable.Range(0, cards.Length).Where(i => !cards[i]).Select(i => i + 1)));
    }

    [Test]
    public void Q4()
    {
        Console.WriteLine(CutBar2(20, 3));
        Console.WriteLine(CutBar2(100, 5));
        return;

        int CutBar(int length, int members, int currentBars = 1)
        {
            if (length <= currentBars)
            {
                return 0;
            }

            if (currentBars < members)
            {
                return 1 + CutBar(length, members, currentBars + currentBars);
            }

            return 1 + CutBar(length, members, members + currentBars);
        }

        int CutBar2(int length, int member)
        {
            var count = 0;
            var current = 1;
            while (length > current)
            {
                current += current < member ? current : member;
                count += 1;
            }

            return count;
        }
    }

    [Test]
    public void Q5()
    {
        var count = 0;
        var coins = new List<int>(new[] { 10, 50, 100, 500 });
        const int coinNumber = 15;
        const int money = 1000;
        //TODO:Refactoring
        for (var i0 = 0; i0 <= money / coins[0] && i0 <= coinNumber; i0++)
        {
            for (var i1 = 0; i1 <= money / coins[1] && i1 <= coinNumber; i1++)
            {
                for (var i2 = 0; i2 <= money / coins[2] && i2 <= coinNumber; i2++)
                {
                    for (var i3 = 0; i3 <= money / coins[3] && i3 <= coinNumber; i3++)
                    {
                        if (i0 * coins[0] + i1 * coins[1] + i2 * coins[2] + i3 * coins[3] == money
                            && i0 + i1 + i2 + i3 <= coinNumber)
                        {
                            count++;
                        }
                    }
                }
            }
        }
        Console.Write(count);
    }
}