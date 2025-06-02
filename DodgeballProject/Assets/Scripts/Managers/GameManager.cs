using System.Reflection;
using Photon.Pun;
using Photon.Realtime;
using UnityEngine;

namespace Managers
{
    public class GameManager : MonoBehaviourPunCallbacks
    {
        private void Awake()
        {
            Screen.SetResolution(1920, 1080, false);
            PhotonNetwork.ConnectUsingSettings();
        }

        public void PressStartButton()
        {
            OnConnectedToMaster();
        }

        public override void OnConnectedToMaster() =>
            PhotonNetwork.JoinRandomOrCreateRoom(null, 2, MatchmakingMode.FillRoom);
    }
}