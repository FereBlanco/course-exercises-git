using UnityEngine;

public class Crow : ISoundMaker
{
    void ISoundMaker.MakeSound()
    {
        Debug.Log("Crow: MakeSound (Aaaargh)");
    }
}
