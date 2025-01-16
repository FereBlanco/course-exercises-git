using UnityEngine;

namespace Scripts.Interfaces.AbstractClass
{
    public class Dog : AbstractSoundMaker
    {
        [SerializeField] int repetitions = 2;

        public override void MakeSound()
        {
            string st = "Dog (";
            string sound = "Guau!";
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
