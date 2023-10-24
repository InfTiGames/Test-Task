using UnityEngine;
using Photon.Pun;
using Photon.Realtime;
using TMPro;

public class ConnectionManager : MonoBehaviourPunCallbacks {

    [SerializeField] private TMP_InputField _createRoomInput, _joinRoomInput;
    private const string LevelName = "MainGame";

    /// <summary>
    /// Creates room when input field is not empty and Create button is pressed
    /// </summary>
    public void CreateRoom() {
        if (PhotonNetwork.IsConnectedAndReady && _createRoomInput.text.Length != 0) {
            RoomOptions roomOptions = new() { MaxPlayers = 2 };
            PhotonNetwork.CreateRoom(_createRoomInput.text, roomOptions);
        }
    }

    /// <summary>
    /// Joins to room when input field is not empty andJoin button is pressed
    /// </summary>
    public void JoinRoom() {
        if (PhotonNetwork.IsConnectedAndReady && _joinRoomInput.text.Length != 0)
            PhotonNetwork.JoinRoom(_joinRoomInput.text);
    }

    public override void OnJoinedRoom() => PhotonNetwork.LoadLevel(LevelName);
}