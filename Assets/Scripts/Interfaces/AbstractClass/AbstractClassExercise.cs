using UnityEngine;

namespace Scripts.Interfaces.AbstractClass
{

    public class AbstractClassExercise : MonoBehaviour
    {
        public AbstractSoundMaker dog;
        public AbstractSoundMaker cat;
        public AbstractSoundMaker cow;
        public AbstractSoundMaker pig;

        private AbstractSoundMaker soundMaker;

        private void Update() {
            if (Input.GetKeyUp(KeyCode.Keypad1)) { soundMaker = dog; Debug.Log("Dog selected"); }
            if (Input.GetKeyUp(KeyCode.Keypad2)) { soundMaker = cat; Debug.Log("Cat selected"); }
            if (Input.GetKeyUp(KeyCode.Keypad3)) { soundMaker = cow; Debug.Log("Cow selected"); }
            if (Input.GetKeyUp(KeyCode.Keypad4)) { soundMaker = pig; Debug.Log("Pig selected"); }

            if (Input.GetKeyUp(KeyCode.Space)) {
                soundMaker.MakeSound();
            }
        }
    }


    public abstract class AbstractSoundMaker : MonoBehaviour
    {
        private int numSounds;

        public AbstractSoundMaker()
        {
            numSounds = 1;
        }

        public AbstractSoundMaker(int numSounds)
        {
            this.numSounds = numSounds;
        }

        public abstract void MakeSound();
    }
}
