using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.AI;

public class UpdateTypes : MonoBehaviour
{
    [SerializeField] GameObject[] monigots;
    [SerializeField] bool _considerTime = false;
    [SerializeField] TMP_Text tMP_TextDeltaTime;
    [SerializeField] TMP_Text tMP_TextFrames;
    private float _speed = 0.01f;
    private int _frames = 0;
    private int _fixed = 0;
    private int _late = 0;


    void FixedUpdate()
    {
        MoveMonigot(monigots[0]);
        _fixed++;
    }

    private void Update()
    {
        MoveMonigot(monigots[1]);
        _frames++;
    }
    private void LateUpdate()
    {
        MoveMonigot(monigots[2]);
        _late++;
    }

    private void MoveMonigot(GameObject monigot)
    {
        if (_considerTime) {
            monigot.transform.position += new Vector3(_speed * 100f, 0f, 0f) * Time.deltaTime;
            // 60 fps -> 1s/60 = 0.016s = 16 ms per frame
        }
        else{
            monigot.transform.position += new Vector3(_speed, 0f, 0f);
        }
        tMP_TextDeltaTime.text = Time.deltaTime.ToString();
        tMP_TextFrames.text = $"[{_fixed}] / [{_frames}] / [{_late}]";
    }
}
