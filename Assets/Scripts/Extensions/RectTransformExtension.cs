
using UnityEngine;

public static class RectTransformExtension {

    /// <summary>
    /// 取得寬度(像素)
    /// </summary>
    /// <param name="rectTransform"></param>
    public static float GetWidth(this RectTransform rectTransform) {
        return rectTransform.sizeDelta.x;
    }

    /// <summary>
    /// 取得高度(像素)
    /// </summary>
    /// <param name="rectTransform"></param>
    public static float GetHeight(this RectTransform rectTransform) {
        return rectTransform.sizeDelta.y;
    }

    /// <summary>
    /// 設定寬度(像素)
    /// </summary>
    /// <param name="rectTransform"></param>
    /// <param name="width"></param>
    public static void SetWidth(this RectTransform rectTransform, float width) {
        rectTransform.sizeDelta = new Vector2(Mathf.Max(width, 0), rectTransform.sizeDelta.y);
    }

    /// <summary>
    /// 設定高度(像素)
    /// </summary>
    /// <param name="rectTransform"></param>
    /// <param name="height"></param>
    public static void SetHeight(this RectTransform rectTransform, float height) {
        rectTransform.sizeDelta = new Vector2(rectTransform.sizeDelta.x, Mathf.Max(height, 0));
    }

}
