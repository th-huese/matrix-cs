public class Matrix
{
    private static double density = .7;
    private static int minTail = 22;
    private static int maxTail = 44;
    private static int minBreak = -33;
    private static int maxBreak = -66;

    private static int[] counter = new int[150];
    private static Random r = new();
    private static string output = "";

    public static void Main()
    {
        while (true)
        {
            output = "";
            Console.ForegroundColor = ConsoleColor.Green;
            for (int i = 0; i < counter.Length; i++)
            {
                if (counter[i] > 0)
                {
                    if (counter[i] <= minTail) resumeTail(i);
                    else if (counter[i] > maxTail) newBreak(i);
                    else
                    {
                        if (r.NextInt64((int)Math.Ceiling(15 / density)) == 1) resumeTail(i);
                        else newBreak(i);
                    }
                }
                else
                {
                    if (counter[i] >= minBreak) resumeBreak(i);
                    else if (counter[i] < maxBreak) newTail(i);
                    else
                    {
                        if (r.NextInt64((int)Math.Ceiling(15 / density)) == 1) newTail(i);
                        else resumeBreak(i);
                    }
                }
            }
            Console.WriteLine(output);
            Thread.Sleep(1);
        }
    }

    private static void resumeTail(int i)
    {
        output += (char)(r.NextInt64(93) + 33);
        counter[i]++;
    }

    private static void resumeBreak(int i)
    {
        output += " ";
        counter[i]--;
    }

    private static void newTail(int i)
    {
        counter[i] = 1;
        resumeTail(i);
    }
    private static void newBreak(int i)
    {
        counter[i] = -1;
        resumeBreak(i);
    }
}