using UnityEngine;

namespace Scripts.Interfaces.AbstractClass
{
    public class Cat : AbstractSoundMaker
    {
        [SerializeField] int repetitions = 1;

        public override void MakeSound()
        {
            string st = "Cat (";
            string sound = "Miau!";
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
