using TMPro;
using UnityEngine;

public class ApplySettings : MonoBehaviour {

    [SerializeField] private TMP_InputField _inputField;

    /// <summary>
    /// Applies data was putted into input field from starting (Sets Physics gravity.y value)
    /// </summary>
    public void ApplyGravityAcceleration() {
        float gravityY = float.Parse(_inputField.text);
        Vector3 gravity = new(0f, -gravityY, 0f);
        Physics.gravity = gravity;
    }
}