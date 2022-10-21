using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class DebugPanel : MonoBehaviour
{
    public static string debugText = "";
    public float speed = 5f;
    public float maxAnchorMinValue = 0.5f;
    
    private RectTransform _rectTransform;
    private GameObject _textInButtonGO;
    private TextMeshPro _text;

    private void Awake()
    {
        _textInButtonGO = gameObject.transform.GetChild(0).gameObject;
        _text = _textInButtonGO.GetComponent<TextMeshPro>();
        _rectTransform = GetComponent<RectTransform>();
    }

    private void Update()
    {
        _text.text = debugText;
    }

    private void OnEnable()
    {
        _rectTransform.anchorMin = new Vector2(_rectTransform.anchorMin.x, 1f);
        StartCoroutine(EnableDebugAnim());
    }

    private void OnDisable()
    {
        StartCoroutine(DisableDebugAnim());
    }

    IEnumerator EnableDebugAnim()
    {
        float currVel = 0f;
        while (!Mathf.Approximately(_rectTransform.anchorMin.y, 0.5f))
        {
            Vector2 tempAnchorMin = _rectTransform.anchorMin;

            tempAnchorMin.y = Mathf.SmoothDamp(tempAnchorMin.y, 0.5f, ref currVel, speed * Time.deltaTime);
            _rectTransform.anchorMin = tempAnchorMin;
            yield return null;
        }

        yield return 0;
    }

    IEnumerator DisableDebugAnim()
    {
        float currVel = 0f;
        while (!Mathf.Approximately(_rectTransform.anchorMin.y, 1f))
        {
            Vector2 tempAnchorMin = _rectTransform.anchorMin;

            tempAnchorMin.y = Mathf.SmoothDamp(tempAnchorMin.y, 1, ref currVel, speed * Time.deltaTime);
            _rectTransform.anchorMin = tempAnchorMin;
            yield return null;
        }

        yield return 0;
    }
}
