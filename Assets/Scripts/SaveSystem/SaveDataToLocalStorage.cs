using SaveSystem;
using TMPro;
using UnityEngine;

namespace SaveHandlers {

    public class SaveDataToLocalStorage : MonoBehaviour, IDataSaver {

        [SerializeField] private TMP_InputField _inputField;

        public void Save() => PlayerPrefsManager.SavePlayerGravitationAccelerationValue(float.Parse(_inputField.text));
    }
}