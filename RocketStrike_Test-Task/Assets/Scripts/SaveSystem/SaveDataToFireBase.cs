using SaveSystem;
using TMPro;
using UnityEngine;

namespace SaveHandlers {

    public class SaveDataToFireBase : MonoBehaviour, IDataSaver {

        [SerializeField] private FirebaseDataManager _firebaseDataManager;
        [SerializeField] private TMP_InputField _inputField;

        public void Save() => _firebaseDataManager.SaveDataToFirebase(_inputField.text);
    }
}