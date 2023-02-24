using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MainLogic : MonoBehaviour {

    [SerializeField]
    private CanvasGroup canvasGroup;

    [SerializeField]
    private RectTransform container;

    [SerializeField]
    private RawImage rawImage;

    [SerializeField]
    private Image image;

    public float width;
    public float height;


    void Start() {

    }

    void Update() {

    }

    public void SetCanvasGroupON() {
        canvasGroup?.SetEnable(true);
    }

    public void SetCanvasGroupOFF() {
        canvasGroup?.SetEnable(false);
    }

    public void SetSizeAbove() {
        rawImage.SetNewSizeAboveMinimum(container);
    }

    public void SetSizeBelow() {
        rawImage.SetNewSizeBelowMaximum(container);
    }

}
