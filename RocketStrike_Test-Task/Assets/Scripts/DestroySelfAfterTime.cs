using UnityEngine;

public class DestroySelfAfterTime : MonoBehaviour {

    /// <summary>
    /// Destroy FX after 1s when instantiated
    /// </summary>
    private void Start() => Destroy(gameObject, 1f);
}