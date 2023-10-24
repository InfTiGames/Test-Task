using Photon.Pun;
using UnityEngine;

public class StartMove : MonoBehaviour {

    private Rigidbody _rigidbody;
    private PhotonView _view;

    private void Start() {
        _rigidbody = GetComponent<Rigidbody>();
        _view = GetComponent<PhotonView>();
    }

    private void Update() {
        StartMoving();
    }

    /// <summary>
    /// Disables isKinematic state on RigidBody component
    /// </summary>
    private void StartMoving() {
        if (_view.IsMine) {
            if (Input.anyKeyDown) {
                _rigidbody.isKinematic = false;
                enabled = false;
            }
        }
    }
}