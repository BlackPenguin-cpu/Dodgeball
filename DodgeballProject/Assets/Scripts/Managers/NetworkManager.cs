using Photon.Pun;
using Photon.Realtime;
using UnityEngine;

namespace Managers
{
    public class NetworkManager : MonoBehaviourPunCallbacks
    {
        private static string PLAYER_OBJ_NAME = "Player";

        private GameObject playerObj;

        private void Awake()
        {
            Screen.SetResolution(1920, 1080, false);
            PhotonNetwork.ConnectUsingSettings();
        }

        public override void OnJoinedRoom()
        {
            var randX = Random.Range(-5f, 5f);
            var randY = Random.Range(-5f, 5f);
            playerObj = PhotonNetwork.Instantiate($"{NetworkUtil.NETWORK_PREFAB_PATH}{PLAYER_OBJ_NAME}",
                new Vector3(randX, randY), Quaternion.identity);
        }

        public override void OnConnectedToMaster() =>
            PhotonNetwork.JoinOrCreateRoom("Room", new RoomOptions() { MaxPlayers = 2 }, null);
    }
}