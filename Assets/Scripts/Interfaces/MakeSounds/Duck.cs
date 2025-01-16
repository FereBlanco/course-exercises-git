using UnityEngine;

public class Duck : ISoundMaker
{
    private int repetitions;

    public Duck()
    {
        repetitions = 2;    // default value
    }

    public Duck(int repetitions)
    {
        this.repetitions = repetitions;
    }

    void ISoundMaker.MakeSound()
    {
        string st = "Duck: MakeSound (";
        for (int i = 1; i <= repetitions; i++)
        {
            st += (i != repetitions) ? "Cuac " : "Cuac";
        }
        st += ")";
        Debug.Log(st);
    }
}
