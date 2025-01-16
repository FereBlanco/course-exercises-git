using UnityEngine;

namespace Scripts.Interfaces.PaddleMovement
{
    public class PaddleMovement : MonoBehaviour
    {
        float time = 10f;

        private void Awake() {
            IPaddleMovement paddleMovement;
            paddleMovement = new ConstantMovement(5f);
            Debug.Log(paddleMovement.GetVelocity(time));
            paddleMovement = new LinearMovement(5f);
            Debug.Log(paddleMovement.GetVelocity(time));
            paddleMovement = new SquareRoot(5f);
            Debug.Log(paddleMovement.GetVelocity(time));
        }
    }
}
