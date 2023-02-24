
using UnityEngine;

public static class CanvasGroupExtension {

    /// <summary>
    /// 設定CanvasGroup是否顯示內容，將會直接影響內部的3個參數，不影響GameObject
    /// </summary>
    /// <param name="canvasGroup"></param>
    /// <param name="isEnable"></param>
    public static void SetEnable(this CanvasGroup canvasGroup, bool isEnable) {
        canvasGroup.alpha = isEnable ? 1 : 0;
        canvasGroup.interactable = isEnable;
        canvasGroup.blocksRaycasts = isEnable;
    }

}
