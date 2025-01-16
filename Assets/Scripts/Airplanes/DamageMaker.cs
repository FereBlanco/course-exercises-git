using System;
using UnityEngine;

namespace Scripts.Airplanes
{
    public class DamageMaker : MonoBehaviour
    {
        // public event Action<DamageMaker> OnAirplaneCollides;
        private void OnCollisionEnter(Collision other)
        {
            if (other.gameObject.tag == Constants.TAG_PLAYER)
            {
                other.gameObject.GetComponent<AirplaneController>().Destroy();
                // OnAirplaneCollides?.Invoke(this);
            }
        }
    }
}
