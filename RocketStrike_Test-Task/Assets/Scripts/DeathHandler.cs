using Photon.Pun;
using System;
using UnityEngine;

public class DeathHandler : MonoBehaviour {

    [SerializeField] private GameObject _explosionFXParticklePrefab;
    private PhotonView _view;

    public static Action OnPlayerDead;

    private const string GroundTag = "Ground";
    private const float XPosLimit = 12f, ZPosLimit = 8f;

    private void Start() => _view = GetComponent<PhotonView>();

    private void Update() {
        CheckPosition();
    }

    private void OnCollisionEnter(Collision collision) {
        CollisionCheck(collision);
    }


    /// <summary>
    /// Checks player position and calls Die() if player out of camera
    /// </summary>
    private void CheckPosition() {
        if (Mathf.Abs(transform.position.x) > XPosLimit || Mathf.Abs(transform.position.z) > ZPosLimit) {
            Die();
        }
    }

    /// <summary>
    /// Calls Die() when player hits ground and checks collision
    /// </summary>
    /// <param name="collision"></param>
    private void CollisionCheck(Collision collision) {
        if (collision.gameObject.CompareTag(GroundTag)) {
            Die();
        }
    }

    /// <summary>
    /// Handles death state
    /// </summary>
    private void Die() {
        OnPlayerDead?.Invoke();

        if (_view.IsMine)
            _view.RPC(nameof(InicializePartickles), RpcTarget.All);

        PhotonNetwork.Destroy(gameObject);
    }

    /// <summary>
    /// Allows to synchronize partickle system between clients
    /// </summary>
    [PunRPC]
    private void InicializePartickles() {
        GameObject explosionFX = PhotonNetwork.Instantiate(_explosionFXParticklePrefab.name, transform.position, Quaternion.identity);
        explosionFX.GetComponent<ParticleSystem>().Play();
    }
}