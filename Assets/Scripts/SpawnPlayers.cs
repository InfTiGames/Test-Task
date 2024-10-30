using UnityEngine;
using Photon.Pun;

public class SpawnPlayers : MonoBehaviour {

    [SerializeField] private PlayerMovement _playerPrefab;

    private Vector3 _firstPlayerSpawnPoint = new(-8f, 1f, 0), _secondPlayerSpawnPoint = new(8f, 1f, 0);

    private void Start() => SpawnPlayer();

    /// <summary>
    /// Used to spawn player on start and to respawn whed player is dead
    /// </summary>
    public void SpawnPlayer() {
        if (PhotonNetwork.IsMasterClient) PhotonNetwork.Instantiate(_playerPrefab.gameObject.name, _firstPlayerSpawnPoint, Quaternion.identity);
        else PhotonNetwork.Instantiate(_playerPrefab.gameObject.name, _secondPlayerSpawnPoint, Quaternion.identity);
    }
}