using UnityEngine;

namespace Scripts.Interfaces.PaddleMovement
{
    public class LinearMovement : IPaddleMovement
    {
        float acceleration;

        public LinearMovement(float acceleration)
        {
            this.acceleration = acceleration;
        }

        float IPaddleMovement.GetVelocity(float time)
        {
            Debug.Log("Linear");
            return acceleration * time;
        }
    }
}
