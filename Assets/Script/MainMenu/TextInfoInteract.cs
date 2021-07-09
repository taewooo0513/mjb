using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TextInfoInteract : MonoBehaviour
{
    [SerializeField] private GameObject explainText;
    private RectTransform pos;

    private void Awake()
    {
        pos = GetComponent<RectTransform>();
    }
    // Update is called once per frame
    void Update()
    {
        
    }

    public void InfoOn()
    {
        pos.anchoredPosition = Vector3.up * 150;
        explainText.SetActive(true);
    }

    public void InfoOff()
    {
        pos.anchoredPosition = Vector3.zero;
        explainText.SetActive(false);
    }
}
