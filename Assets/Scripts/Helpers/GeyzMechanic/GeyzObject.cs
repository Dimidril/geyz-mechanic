using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GeyzObject : MonoBehaviour
{
    [SerializeField] private float _startWatchDuration = 0.5f;
    [SerializeField] private float _endWatchDuration = 1f;
    [SerializeField] private GameObject _objectToWatch;

    private IEnumerator _showCoroutine;
    private IEnumerator _hideCoroutine;

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

    private IEnumerator ShowObject()
    {
        StopCoroutine(_hideCoroutine);
        yield return new WaitForSeconds(_startWatchDuration);
        _objectToWatch.SetActive(true);
    }

    private IEnumerator HideObject()
    {
        StopCoroutine(_showCoroutine);
        yield return new WaitForSeconds(_endWatchDuration);
        _objectToWatch.SetActive(false);
    }
}
