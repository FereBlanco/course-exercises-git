using UnityEngine;

namespace Scripts.Interfaces.AbstractClass
{
    public class Pig : AbstractSoundMaker
    {
        [SerializeField] int repetitions = 3;

        public override void MakeSound()
        {
            string st = "Pig (";
            string sound = "Oink!";
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
