using Firebase;
using Firebase.Database;
using Firebase.Extensions;
using UnityEngine;
using System.Collections;
using System.Threading.Tasks;

namespace SaveSystem {

    public class DataSynchronizer : MonoBehaviour {

        private DatabaseReference _databaseReference;
        private FirebaseDataManager _firebaseDataManager;
        private const float DefaultGravitationAccelerationValue = 9.81f;

        public float Data { get; private set; }
        public bool IsSynchronized { get; private set; }

        private void Start() {
            _firebaseDataManager = GetComponent<FirebaseDataManager>();
            FirebaseApp.CheckAndFixDependenciesAsync().ContinueWithOnMainThread(task => {
                FirebaseApp app = FirebaseApp.DefaultInstance;
                _databaseReference = FirebaseDatabase.DefaultInstance.RootReference;
                StartCoroutine(SynchronizeData());
            });
        }

        private IEnumerator SynchronizeData() {
            if (Application.internetReachability != NetworkReachability.NotReachable) {
                Task<DataSnapshot> task = _databaseReference
                    .Child(_firebaseDataManager.PlayerData)
                    .Child(_firebaseDataManager.PlayerID)
                    .Child(_firebaseDataManager.GravitationAccelerationValue)
                    .GetValueAsync();
                yield return new WaitUntil(predicate: () => task.IsCompleted);
                if (task != null) {
                    DataSnapshot snapshot = task.Result;
                    if (snapshot.Exists) {
                        Data = float.Parse(snapshot.Value.ToString());
                        Debug.Log("Firebase Data Used");
                        PlayerPrefsManager.SavePlayerGravitationAccelerationValue(Data);
                    } else {
                        Data = DefaultGravitationAccelerationValue;
                        Debug.Log("Default Data Used");
                        PlayerPrefsManager.SavePlayerGravitationAccelerationValue(Data);
                    }
                }
            } else {
                if (PlayerPrefsManager.GetPlayerGravitationAccelerationValue() != 0) {
                    Data = PlayerPrefsManager.GetPlayerGravitationAccelerationValue();
                    PlayerPrefsManager.SavePlayerGravitationAccelerationValue(Data);
                    Debug.Log("Local Data Used");
                } else {
                    Data = DefaultGravitationAccelerationValue;
                    Debug.Log("Default Data Used");
                    PlayerPrefsManager.SavePlayerGravitationAccelerationValue(Data);
                }
            }
            IsSynchronized = true;
        }
    }
}