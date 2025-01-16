using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Coroutines02 : MonoBehaviour
{
    [SerializeField] GameObject _go01;
    [SerializeField] GameObject _go02;
    [SerializeField] float _stepTransparency = 0.1f;

    private Renderer _renderer01;
    private Renderer _renderer02;
    private Color _c01;
    private Color _c02;
    private bool _blink = false;

    private float _maxAlpha = 1f;
    private float _minAlpha = 0f;

    private Coroutine fadeCoroutine;

    private void Awake() {
        if (_go01 == null) throw new System.Exception("ERROR: gameobject1 is null!!!");
        _renderer01 = _go01.GetComponent<Renderer>();
        if (_renderer01 == null) throw new System.Exception("ERROR: gameobject1 has no Renderer component!!!");
        _c01 = _renderer01.material.color;

        if (_go02 == null) throw new System.Exception("ERROR: gameobject2 is null!!!");
        _renderer02 = _go02.GetComponent<Renderer>();
        if (_renderer02 == null) throw new System.Exception("ERROR: gameobject2 has no Renderer component!!!");
        _c02 = _renderer02.material.color;
    }

    public void FadeIn()
    {
        if (fadeCoroutine != null) StopCoroutine(fadeCoroutine);
        fadeCoroutine = StartCoroutine(IFade(_minAlpha, _maxAlpha, _stepTransparency));
    }

    public void FadeOut()
    {
        if (fadeCoroutine != null) StopCoroutine(fadeCoroutine);
        fadeCoroutine = StartCoroutine(IFade(_minAlpha, _maxAlpha, _stepTransparency * (-1)));
    }

    public void StartBlink()
    {
        if (fadeCoroutine != null) StopCoroutine(fadeCoroutine);
        _blink = true;
        fadeCoroutine = StartCoroutine(IFade(_minAlpha, _maxAlpha, _stepTransparency * (-1)));
    }

    public void StopBlink()
    {
        if (fadeCoroutine != null) StopCoroutine(fadeCoroutine);
        _blink = false;
    }

    IEnumerator IFade(float minAlpha, float maxAlpha, float stepTransparency)
    {
        float num = _c01.a;
        if (stepTransparency > 0)
        {
            while (num <= maxAlpha)
            {
                num += stepTransparency;
                SetAlpha(Math.Min(maxAlpha, num));
                yield return new WaitForSeconds(.1f);
            }
        }
        else if (stepTransparency < 0)
        {
            while (num >= minAlpha)
            {
                num += stepTransparency;
                SetAlpha(Math.Max(minAlpha, num));
                yield return new WaitForSeconds(.1f);
            }
        }
        if (_blink) fadeCoroutine = StartCoroutine(IFade(minAlpha, maxAlpha, stepTransparency * (-1)));
    }

    private void SetAlpha(float newAlpha)
    {
        _c01.a = newAlpha;
        _c02.a = newAlpha;
        _renderer01.material.color = _c01;
        _renderer02.material.color = _c02;        
    }
}
