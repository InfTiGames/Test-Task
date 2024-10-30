using UnityEngine;
using SaveSystem;
using System.Collections;
using TMPro;

public class SettingsValueSetuper : MonoBehaviour {

    [SerializeField] private DataSynchronizer _dataSynchronizer;
    [SerializeField] private TMP_InputField _inputField;

    private void Start() => StartCoroutine(PlaceSettingsValues());

    /// <summary>
    /// Places synchronyzed gravity acceleration value to input field when starts
    /// </summary>
    /// <returns></returns>
    private IEnumerator PlaceSettingsValues() {
        yield return new WaitUntil(predicate: () => _dataSynchronizer.IsSynchronized);
        if (_dataSynchronizer.IsSynchronized) {
            float gravitationAcceleration = _dataSynchronizer.Data;
            _inputField.text = gravitationAcceleration.ToString();
            Vector3 onStartGravity = new(0f, -gravitationAcceleration, 0f);
            Physics.gravity = onStartGravity;
        }
    }
}