using UnityEngine;
using TMPro;

public class TMPInputLimits : MonoBehaviour {

    private TMP_InputField _inputField;
    private const float MinValue = 9.81f, MaxValue = 19.62f;

    private void Start() {
        _inputField = GetComponent<TMP_InputField>();
        _inputField.onEndEdit.AddListener(OnInputFieldEndEdit);
    }

    /// <summary>
    /// Restriction of min and max possible value in input field
    /// </summary>
    /// <param name="newValue"></param>
    private void OnInputFieldEndEdit(string newValue) {
        if (float.TryParse(newValue, out float parsedValue)) {
            parsedValue = Mathf.Clamp(parsedValue, MinValue, MaxValue);
            if (parsedValue > MinValue || parsedValue < MaxValue) {
                _inputField.text = parsedValue.ToString("F2");
            } else if (parsedValue > MaxValue) {
                _inputField.text = MaxValue.ToString();
            } else if (parsedValue < MinValue) {
                _inputField.text = MinValue.ToString();
            }
        } else {
            _inputField.text = MinValue.ToString();
        }
    }
}