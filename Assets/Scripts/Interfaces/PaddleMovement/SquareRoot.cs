using UnityEngine;

namespace Scripts.Interfaces.PaddleMovement
{
    public class SquareRoot : IPaddleMovement
    {
        float value;

        public SquareRoot(float acceleration)
        {
            this.value = acceleration;
        }

        float IPaddleMovement.GetVelocity(float time)
        {
            Debug.Log("SquareRoot");            
            return Mathf.Sqrt(value * time);
        }
    }
}
