using UnityEngine;

public class MakeSounds : MonoBehaviour
{
    ISoundMaker polymorphicSoundMaker;

    // I also can use different vbles
    ISoundMaker crowSoundMaker;
    ISoundMaker duckSoundMaker;
    ISoundMaker owlSoundMaker;

    private void Awake() {
        Debug.Log("-- Polymorphic Bird:");
        polymorphicSoundMaker = new Crow();
        polymorphicSoundMaker.MakeSound();
        polymorphicSoundMaker = new Duck();
        polymorphicSoundMaker.MakeSound();
        polymorphicSoundMaker = new Owl();
        polymorphicSoundMaker.MakeSound();

        Debug.Log("-- Crow:");
        crowSoundMaker = new Crow();
        crowSoundMaker.MakeSound();
        Debug.Log("-- Duck:");
        duckSoundMaker = new Duck(3);
        duckSoundMaker.MakeSound();
        Debug.Log("-- Owl:");
        owlSoundMaker = new Owl();
        owlSoundMaker.MakeSound();
    }
}
