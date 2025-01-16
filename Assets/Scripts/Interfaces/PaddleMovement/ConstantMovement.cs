using UnityEngine;

namespace Scripts.Interfaces.PaddleMovement
{
    public class ConstantMovement : IPaddleMovement
    {
        float velocity;
        
        public ConstantMovement(float velocity)
        {
            this.velocity = velocity;
        }

        float IPaddleMovement.GetVelocity(float time)
        {
            Debug.Log("Constant");
            return velocity;
        }
    }
}
