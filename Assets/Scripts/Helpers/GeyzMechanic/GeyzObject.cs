using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GeyzObject : MonoBehaviour
{
    [SerializeField] float _startWatchDuration = 0.5f;
    [SerializeField] float _endWatchDuration = 1f;
    [SerializeField] GameObject _objectToWatch;

    IEnumerator _showCoroutine;
    IEnumerator _hideCoroutine;

    private void Awake()
    {
        _showCoroutine = ShowObject();
        _hideCoroutine = HideObject();
    }

    public void OnCameraStartWatch()
    {
        StartCoroutine(_showCoroutine);
    }

    public void OnCameraEndWatch()
    {
        StartCoroutine(_hideCoroutine);
    }

    IEnumerator ShowObject()
    {
        StopCoroutine(_hideCoroutine);
        yield return new WaitForSeconds(_startWatchDuration);
        _objectToWatch.SetActive(true);
    }

    IEnumerator HideObject()
    {
        StopCoroutine(_showCoroutine);
        yield return new WaitForSeconds(_endWatchDuration);
        _objectToWatch.SetActive(false);
    }
}
