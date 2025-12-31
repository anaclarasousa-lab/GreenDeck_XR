using UnityEngine;
using TMPro;
using System;

public class HoverManager : MonoBehaviour
{
    public TextMeshProUGUI tipText;
    public RectTransform tipWindow;
    
    // Acciones estáticas para llamar desde cualquier carta
    public static Action<string, Vector3> OnMouseHover;
    public static Action OnMouseLoseFocus;

    private void OnEnable()
    {
        OnMouseHover += ShowToolTip;
        OnMouseLoseFocus += HideToolTip;
    }

    private void OnDisable()
    {
        OnMouseHover -= ShowToolTip;
        OnMouseLoseFocus -= HideToolTip;
    }

    void Start() => HideToolTip();

    private void ShowToolTip(string tip, Vector3 position)
    {
        tipText.text = tip;
        // Ajusta el tamaño de la ventana al texto
        tipWindow.sizeDelta = new Vector2(tipText.preferredWidth + 100, tipText.preferredHeight + 250);

        tipWindow.gameObject.SetActive(true);
        tipWindow.transform.position = position;
    }

    private void HideToolTip()
    {
        tipText.text = string.Empty;
        tipWindow.gameObject.SetActive(false);
    }
}