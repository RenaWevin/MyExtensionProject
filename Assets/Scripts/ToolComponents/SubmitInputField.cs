using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

/// <summary>
/// 按Enter會送出的InputField
/// </summary>
[RequireComponent(typeof(InputField))]
public class SubmitInputField : MonoBehaviour {

    private InputField m_inputField;

    [SerializeField, Tooltip("禁用Tab鍵與\\t")]
    public bool IsDisableTab = true;

    public UnityEvent onSubmit;

    public string Text {
        get {
            return m_inputField.text;
        }
    }

    /// <summary>
    /// 啟動時自動抓取InputField
    /// </summary>
    void Start() {
        m_inputField = GetComponent<InputField>();
        if (m_inputField == null) {
            Debug.LogError("ReturnInputField組件找不到必需的InputField組件！");
        } else {
            m_inputField.lineType = InputField.LineType.MultiLineNewline;
            m_inputField.onValidateInput -= OnValidateCommand;
            m_inputField.onValidateInput += OnValidateCommand;
        }
    }

    /// <summary>
    /// 抓取輸入的最後一個字元
    /// </summary>
    private char OnValidateCommand(string text, int charIndex, char addedChar) {

        //tab禁用
        if (IsDisableTab && addedChar == '\t') {
            return '\0';
        }

        //送出
        if (addedChar == '\n') {

            if (text.Length > 0) {
                //執行送出
                onSubmit.Invoke();
            }

            m_inputField.text = "";

            return '\0';
        }

        return addedChar;
    }
}