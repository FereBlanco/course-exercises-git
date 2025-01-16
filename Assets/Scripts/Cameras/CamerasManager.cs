using UnityEngine;
using UnityEngine.Assertions;

namespace Scripts.Cameras
{

    public class CamerasManager : MonoBehaviour
    {
        [SerializeField] Camera[] cameras;
        private int currentCamera;

        private void Awake() {
            foreach (var camera in cameras) Assert.IsNotNull(camera, "ERROR: any camera is null");

            GUIStyle style = new GUIStyle();
            style.fontSize = 12;            
        }

        private void Start() {
            SetCamera(1);
        }

        void Update()
        {
            if (Input.GetKeyDown(KeyCode.C)) NextCamera();

            if (Input.GetKeyDown(KeyCode.Keypad1)) SetCamera(1);
            if (Input.GetKeyDown(KeyCode.Keypad2)) SetCamera(2);
            if (Input.GetKeyDown(KeyCode.Keypad3)) SetCamera(3);
            if (Input.GetKeyDown(KeyCode.Keypad4)) SetCamera(4);
            if (Input.GetKeyDown(KeyCode.Keypad5)) SetCamera(5);
            if (Input.GetKeyDown(KeyCode.Keypad6)) SetCamera(6);
            if (Input.GetKeyDown(KeyCode.Keypad7)) SetCamera(7);
            if (Input.GetKeyDown(KeyCode.Keypad8)) SetCamera(8);
            if (Input.GetKeyDown(KeyCode.Keypad9)) SetCamera(9);
        }

        private void NextCamera()
        {
            int nextCamera = currentCamera + 1;
            if (nextCamera > cameras.Length) nextCamera = 1;
            SetCamera(nextCamera);
        }

        private void SetCamera(int numCamera)
        {
            if (numCamera > 0 && numCamera <= cameras.Length)
            {
                currentCamera = numCamera;
                foreach (var camera in cameras) camera.enabled = false;
                cameras[numCamera-1].enabled = true;
            }
            else
            {
                Debug.Log($"ERROR: camera {numCamera} doesn't exist");
            }
        }

        private void OnGUI()
        {
            GUI.Label(new Rect(10, 0, 1000, 100), $"Camera Number {currentCamera}");
        }        
    }
}
