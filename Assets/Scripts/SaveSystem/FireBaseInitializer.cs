using Firebase;
using Firebase.Database;
using Firebase.Extensions;
using UnityEngine;

public class FireBaseInitializer : MonoBehaviour {

    private void Start() => Initialize();

    private void Initialize() {
        FirebaseApp.CheckAndFixDependenciesAsync().ContinueWithOnMainThread(task => {
            FirebaseApp app = FirebaseApp.DefaultInstance;
            FirebaseDatabase database = FirebaseDatabase.DefaultInstance;
        });
    }
}