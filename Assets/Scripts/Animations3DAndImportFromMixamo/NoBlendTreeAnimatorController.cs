using UnityEngine;

namespace Scripts.Animations3DAndImportFromMixamo
{
    public class NoBlendTreeAnimatorController : MonoBehaviour
    {
        Animator animator;
        new Rigidbody rigidbody; // Use the new keyword if hiding was intended
        float verticalInput;
        // float horizontalInput;
        float walkingSpeed = 4f;
        float runningSpeed = 6f;
        // float rotateSpeed = 2f;

        float finalSpeed = 0f;

        private void Awake() {
            animator = GetComponent<Animator>();
            rigidbody= GetComponent<Rigidbody>();

            GUIStyle style = new GUIStyle();
            style.fontSize = 12;             
        }

        private void Update() {
            verticalInput = Input.GetAxis(Constants.VERTICAL_INPUT);
            // horizontalInput = Input.GetAxis(Constants.HORIZONTAL_INPUT);

            UpdateAnimation();
            UpdateRigidbody();


            // if (IsWalking())
            // {
            //     // Rotata
            //     transform.Rotate(horizontalInput * 90f * rotateSpeed * Time.deltaTime * Vector3.up);

            //     // Move
            //     if (IsRunning())
            //     {
            //         // transform.Translate(runningSpeed * Time.deltaTime * Vector3.forward);
            //     }
            //     else
            //     {
            //         // transform.Translate(walkingSpeed * Time.deltaTime * Vector3.forward);
            //     }
            // }
        }

        private bool IsWalking()
        {
            return verticalInput > 0.05f;
        }
        private bool IsRunning()
        {
            return IsWalking() && (Input.GetKey(KeyCode.LeftShift) || Input.GetKey(KeyCode.RightShift));
        }

        private void UpdateAnimation()
        {
            animator.SetBool(Constants.IS_WALKING, IsWalking());
            animator.SetBool(Constants.IS_RUNNING, IsRunning());
        }

        private void UpdateRigidbody()
        {
            finalSpeed = IsWalking() && IsRunning() ? runningSpeed : IsWalking() ? walkingSpeed : 0;
            rigidbody.velocity = verticalInput * finalSpeed * Vector3.forward;
            Debug.Log(rigidbody.velocity);
        }

        private void OnGUI()
        {
            GUI.Label(new Rect(10, 0, 1000, 100), $"Vertical Input: {verticalInput}");
            GUI.Label(new Rect(10, 15, 1000, 100), $"IsWalking: {IsWalking()}");
            GUI.Label(new Rect(10, 30, 1000, 100), $"IsRunning: {IsRunning()}");
            GUI.Label(new Rect(10, 45, 1000, 100), $"Rigibody.velocity: {rigidbody.velocity}");
            GUI.Label(new Rect(10, 60, 1000, 100), $"finalSpeed: {finalSpeed}");
            GUI.Label(new Rect(10, 75, 1000, 100), $"Vector3.forward: {Vector3.forward}");
            GUI.Label(new Rect(10, 90, 1000, 100), $"verticalInput * finalSpeed * Vector3.forward: {verticalInput * finalSpeed * Vector3.forward}");
        }          
    }
}
