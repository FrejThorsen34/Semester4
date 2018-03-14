using System.Collections.Generic;
using GUIAssignment;

public class Utility
{
    public static List<Player> ReadPlayerData(string filename)
    {
        string input;
        List<Player> names = new List<Player>();

        using (System.IO.StreamReader reader =
            new System.IO.StreamReader(filename))
        {
            input = reader.ReadLine();
            while (input != null)
            {
                names.Add(new Player(input));
                input = reader.ReadLine();
            }
        }
        return names;
    }
}