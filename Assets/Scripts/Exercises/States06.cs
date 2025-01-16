using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.VisualScripting;
using Unity.VisualScripting.AssemblyQualifiedNameParser;
using UnityEngine;
using UnityEngine.UI;

public class States06: MonoBehaviour
{
    [SerializeField] TMP_InputField txt_Input;
    [SerializeField] Image img_Hearts;
    private float _heartUnitWidth;

    private void Awake() {
        _heartUnitWidth = img_Hearts.rectTransform.sizeDelta.x;
        SetLivesNumber(5);
        Debug.Log($"Base image width is {_heartUnitWidth}");
    }

    private void Update() {
    }

    public void AssignLifes()
    {
        float newLives = float.Parse(txt_Input.text);
        SetLivesNumber(newLives);
    }

    private void SetLivesNumber(float newLives)
    {
        if (newLives >= 0 && (newLives % 0.5 == 0))
        {
            img_Hearts.rectTransform.sizeDelta = new Vector2(_heartUnitWidth * newLives, img_Hearts.rectTransform.sizeDelta.y);
            float redEffectLimit = 0.5f;
            float redEffect = ((newLives-1) * redEffectLimit > 1 ? 1 : (newLives-1) * redEffectLimit);
            img_Hearts.color = new Color(1f, redEffect, redEffect, 1f);
        }
        else
        {
            Debug.Log($"New value needs to be greater or equal to 0 and multiple of 0.5");
        }
    }
}
