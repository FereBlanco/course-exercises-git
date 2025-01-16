using UnityEngine;

public class Owl : ISoundMaker
{
    void ISoundMaker.MakeSound()
    {
        Debug.Log("Owl: MakeSound (Uuuuuuh)");
    }
}
