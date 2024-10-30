using UnityEngine;
using Photon.Pun;

public class ConnectToServer : MonoBehaviourPunCallbacks {

    private void Start() => PhotonNetwork.ConnectUsingSettings();

    public override void OnConnectedToMaster() => Debug.Log("Connection Established");
}