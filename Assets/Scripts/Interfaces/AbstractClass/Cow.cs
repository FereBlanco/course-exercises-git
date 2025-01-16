using UnityEngine;

namespace Scripts.Interfaces.AbstractClass
{
    public class Cow : AbstractSoundMaker
    {
        [SerializeField] int repetitions = 1;

        public override void MakeSound()
        {
            string st = "Cow (";
            string sound = "Muuuuu!";
            AudioSource audio = GetComponent<AudioSource>();
            for (int i = 1; i <= repetitions; i++)
            {
                st += (i != repetitions) ? sound+" " : sound;
                audio.Play();
            }
            st += ")";
            Debug.Log(st);
        }
    }
}
