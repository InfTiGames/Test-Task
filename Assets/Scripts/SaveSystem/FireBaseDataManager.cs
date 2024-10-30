using Firebase;
using Firebase.Database;
using Firebase.Extensions;
using UnityEngine;

namespace SaveSystem {

    public class FirebaseDataManager : MonoBehaviour {

        private DatabaseReference _databaseReference;

        public string PlayerData { get; private set; } = "playerData";

        public string GravitationAccelerationValue { get; private set; } = "GravitationAccelerationValue";

        public string PlayerID { get; private set; }

        private void Start() {
            PlayerID = SystemInfo.deviceUniqueIdentifier;

            FirebaseApp.CheckAndFixDependenciesAsync().ContinueWithOnMainThread(task => {
                FirebaseApp app = FirebaseApp.DefaultInstance;
                _databaseReference = FirebaseDatabase.DefaultInstance.RootReference;
            });
        }

        /// <summary>
        /// Saves player data to Firebase
        /// </summary>
        /// <param name="data"></param>
        public void SaveDataToFirebase(string data) {
            _databaseReference.Child(PlayerData).Child(PlayerID).Child(GravitationAccelerationValue).SetValueAsync(data);
        }
    }
}