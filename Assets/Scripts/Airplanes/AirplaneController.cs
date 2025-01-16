using System;
using UnityEngine;
using UnityEngine.Assertions;

namespace Scripts.Airplanes
{
    public class AirplaneController : MonoBehaviour
    {
        [SerializeField, Range(5f, 20f), Tooltip("Forward speed m/s")] float forwardSpeed = 10f;
        [SerializeField, Range(5f, 20f), Tooltip("Vertical speed m/s")] float verticalSpeed = 15f;
        [SerializeField, Range(5f, 20f), Tooltip("Horizontal speed m/s")] float horizontalSpeed = 15f;
        [SerializeField, Range(10f, 90f), Tooltip("Horizontal speed m/s")] float pitchLimit = 30f;
        [SerializeField, Range(10f, 90f), Tooltip("Horizontal speed m/s")] float rollLimit = 45f;
        [SerializeField, Range(1f, 5f), Tooltip("Turbulence limit")] float turbulenceValue = 3f;
        float verticalInput;
        float horizontalInput;
        float currentVerticalInput;
        float currentHorizontalInput;
        float rotateSpeed;
        float epsilonRotation;
        [SerializeField, Tooltip("X axis left limit")] float minX = 80f;
        [SerializeField, Tooltip("X axis right limit")] float maxX = 100f;
        [SerializeField, Tooltip("Y axis top limit")] float maxY = 18f;
        [SerializeField, Tooltip("Y axis bottom limit")] float minY = 7f;
        [SerializeField] bool verticalSwap = true; // Let us swap up & down keys (different flying sensations)
        private float verticalSwapValue;
        [SerializeField] ParticleSystem psExplosionPrefab;

        private void Awake() {
            Assert.IsNotNull(psExplosionPrefab,"ERROR: psExplosionPrefab is null");

            GUIStyle style = new GUIStyle();
            style.fontSize = 12;

            verticalSwapValue = verticalSwap ? -1f : 1f;

            currentVerticalInput = 0f;
            currentHorizontalInput = 0f;
            rotateSpeed = 0.05f;
            epsilonRotation = 2.5f;
        }

        private void Update()
        {
            horizontalInput = Input.GetAxis(Constants.HORIZONTAL_AXIS);
            verticalInput = verticalSwapValue * Input.GetAxis(Constants.VERTICAL_AXIS);

            UpdateTranslation();
            UpdateRotation();
        }

        private void UpdateRotation()
        {
            if (currentVerticalInput < verticalInput) currentVerticalInput += rotateSpeed;
            if (currentVerticalInput > verticalInput) currentVerticalInput -= rotateSpeed;

            if (currentHorizontalInput < horizontalInput) currentHorizontalInput += rotateSpeed;
            if (currentHorizontalInput > horizontalInput) currentHorizontalInput -= rotateSpeed;

            float rotationX = currentVerticalInput * pitchLimit * -1f;
            if (Mathf.Abs(rotationX) < 6) rotationX = 0f;
            
            float rotationY = currentHorizontalInput * rollLimit * -1f;
            if (Mathf.Abs(rotationY) < epsilonRotation) rotationY = 0f;

            // transform.eulerAngles = new Vector3(rotationX, 0f, rotationY);
            transform.rotation = Quaternion.Euler(rotationX, 0f, rotationY);
        }

        private void UpdateTranslation()
        {

            Vector3 forwardTranslation = forwardSpeed * Time.deltaTime * Vector3.forward;
            Vector3 translation = forwardTranslation + GetTurbulenceTranslation();

            if ((transform.position.y <= maxY && verticalInput > 0) || (transform.position.y >= minY && verticalInput < 0))
            {
                translation += GetVerticalTranslation();
            }
            if ((transform.position.x <= maxX && horizontalInput > 0) || (transform.position.x >= minX && horizontalInput < 0))
            {
                translation += GetHorizontalTranslation();
            }

            transform.Translate(translation, Space.World);
        }

        private Vector3 GetVerticalTranslation()
        {
            return verticalInput * verticalSpeed * Time.deltaTime * Vector3.up;
        }

        private Vector3 GetHorizontalTranslation()
        {
            return horizontalInput * horizontalSpeed * Time.deltaTime * Vector3.right;
        }

        private Vector3 GetTurbulenceTranslation()
        {
            float minRange = transform.position.y <= maxX ? turbulenceValue : 0f;
            float maxRange = transform.position.y >= minY ? turbulenceValue * -1f : 0f;

            return UnityEngine.Random.Range(minRange, maxRange) * Time.deltaTime * Vector3.up;
        }

        private void OnGUI()
        {
            GUI.Label(new Rect(10, 0, 1000, 100), "Euler X: " + transform.rotation.eulerAngles.x);
            GUI.Label(new Rect(10, 15, 1000, 100), "Euler Z: " + transform.rotation.eulerAngles.z);
            GUI.Label(new Rect(10, 30, 1000, 100), "Vertical Input: " + verticalInput);
            GUI.Label(new Rect(10, 45, 1000, 100), "Horizontal Input: " + horizontalInput);
            GUI.Label(new Rect(10, 60, 1000, 100), "Current Vertical Input: " + currentVerticalInput);
            GUI.Label(new Rect(10, 75, 1000, 100), "Current Horizontal Input: " + currentHorizontalInput);
        }

        public void Destroy()
        {
            var psExplosion = Instantiate(psExplosionPrefab, transform.position, transform.rotation);
            //transform.SetParent(psExplosion.transform);
            gameObject.SetActive(false);
        }
    }
}
