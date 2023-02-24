
using UnityEngine;
using UnityEngine.UI;

public static class RawImageExtension {

    #region 縮放成大於等於指定範圍

    /// <summary>
    /// 將RawImage縮放成至少其中一邊等於最小長寬的大小(其中一邊可能會超出範圍)
    /// </summary>
    /// <param name="rawImage">RawImage本身</param>
    /// <param name="minW">最小寬度</param>
    /// <param name="minH">最小高度</param>
    /// <param name="dontResizeIfSmallerThanMin">為true時便會在圖片大小比指定範圍小時不縮放至min大小</param>
    public static void SetNewSizeAboveMinimum(this RawImage rawImage, float minW, float minH, bool dontResizeIfSmallerThanMin = false) {
        if (rawImage.texture == null) {
            return;
        }
        if (dontResizeIfSmallerThanMin) {
            if ((rawImage.texture.width <= minW) && (rawImage.texture.height <= minH)) {
                rawImage.SetNativeSize();
                return;
            }
        }
        float newSize = rawImage.texture.width * (minH / rawImage.texture.height);
        if (newSize < minW) {
            newSize = rawImage.texture.height * (minW / rawImage.texture.width);
            rawImage.rectTransform.sizeDelta = new Vector2(minW, newSize);
        } else {
            rawImage.rectTransform.sizeDelta = new Vector2(newSize, minH);
        }
    }

    /// <summary>
    /// 將RawImage等比縮放成至少其中一邊等於指定RectTransform容器的大小(其中一邊可能會超出範圍)
    /// </summary>
    /// <param name="rawImage">RawImage本身</param>
    /// <param name="containerRect">指定容器</param>
    /// <param name="dontResizeIfSmallerThanContainer">為true時便會在圖片大小比指定範圍小時不縮放</param>
    public static void SetNewSizeAboveMinimum(this RawImage rawImage, RectTransform containerRect, bool dontResizeIfSmallerThanContainer = false) {
        SetNewSizeAboveMinimum(
            rawImage: rawImage,
            minW: containerRect.sizeDelta.x,
            minH: containerRect.sizeDelta.y,
            dontResizeIfSmallerThanMin: dontResizeIfSmallerThanContainer);
    }

    #endregion
    #region 縮放成小於等於指定範圍

    /// <summary>
    /// 將超過大小的RawImage縮放成小於最大長寬的大小
    /// </summary>
    /// <param name="rawImage">RawImage本身</param>
    /// <param name="maxW">最大寬度</param>
    /// <param name="maxH">最大高度</param>
    public static void SetNewSizeBelowMaximum(this RawImage rawImage, float maxW, float maxH) {
        if ((rawImage.texture.width > maxW) || (rawImage.texture.height > maxH)) {
            float newSize = rawImage.texture.width * (maxH / rawImage.texture.height);
            if (newSize > maxW) {
                newSize = rawImage.texture.height * (maxW / rawImage.texture.width);
                rawImage.rectTransform.sizeDelta = new Vector2(maxW, newSize);
            } else {
                rawImage.rectTransform.sizeDelta = new Vector2(newSize, maxH);
            }
        } else {
            rawImage.SetNativeSize();
        }
    }

    /// <summary>
    /// 將超過大小的RawImage縮放成小於指定RectTransform容器的大小
    /// </summary>
    /// <param name="rawImage">RawImage本身</param>
    /// <param name="containerRect">指定容器</param>
    public static void SetNewSizeBelowMaximum(this RawImage rawImage, RectTransform containerRect) {
        SetNewSizeBelowMaximum(rawImage: rawImage,
                                     maxW: containerRect.sizeDelta.x,
                                     maxH: containerRect.sizeDelta.y);
    }

    #endregion

}
