using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Fusion;
using Fusion.Sockets;
using System;
using UnityEngine.UI;


namespace GooglyEyesGames.FusionBites
{
    public class FusionConection : MonoBehaviour, INetworkRunnerCallbacks
    {
        public static FusionConection instance;
        public bool connectOnAway = false;

        [HideInInspector]
        public NetworkRunner runner;

        [HideInInspector]
        public static bool playerApperance = false;

        [SerializeField] NetworkObject playerPrefab;

        public string _playerName = null;



        [Header("Session List")]
        public GameObject roomListCanvas;
        private List<SessionInfo> _sessions = new List<SessionInfo>();
        public Button refreshButton;
        public Transform sessionListContent;
        public GameObject sessionEntryPrefab;

        private void Awake()
        {
            if(instance == null)
            {
                instance = this;
            }
            //if(connectOnAway == true)
            //{
            //    ConnectToRunner("Anonymous");
            //}
        }



        public async  void ConnectToLobby(string playerName)
        {
            roomListCanvas.SetActive(true);
            _playerName = playerName;

            if (runner == null)
            {
                runner = gameObject.AddComponent<NetworkRunner>();
            }
            runner.JoinSessionLobby(SessionLobby.Shared);

        }


        public async void ConnectToSession(string sessionName)
        {
            roomListCanvas.SetActive(false);
            if (runner == null)
            {
                runner = gameObject.AddComponent<NetworkRunner>();
            }

            await runner.StartGame(new StartGameArgs()
            {

                GameMode = GameMode.Shared,
                SessionName = sessionName,
                PlayerCount = 2,

            });
        }

        public async void  CreateSession()
        {
            roomListCanvas.SetActive(false);
            int randomInt = UnityEngine.Random.Range(1000, 9999);
            string randomSessionName = "Room-" + randomInt.ToString();

            if (runner == null)
            {
                runner = gameObject.AddComponent<NetworkRunner>();
            }

            await runner.StartGame(new StartGameArgs()
            {

                GameMode = GameMode.Shared,
                SessionName = randomSessionName,
                PlayerCount = 2,

            });
        }

        public void OnConnectedToServer(NetworkRunner runner)
        {
            Debug.Log("Connected server");

           
                NetworkObject playerObject = runner.Spawn(playerPrefab, Vector3.zero);

                runner.SetPlayerObject(runner.LocalPlayer, playerObject);
           
        }

        public void OnSessionListUpdated(NetworkRunner runner, List<SessionInfo> sessionList)
        {
           _sessions.Clear();
           _sessions = sessionList;
        }

        public void RefreshSessionListUI()
        {
            //clears our Session List
            foreach(Transform child in sessionListContent)
            {
                Destroy(child.gameObject);
            }

            foreach(SessionInfo session in _sessions)
            {
                if (session.IsVisible)
                {
                    GameObject entry = GameObject.Instantiate(sessionEntryPrefab, sessionListContent);
                    SessionEntryPrefab script = entry.GetComponent<SessionEntryPrefab>();
                    script.sessionName.text = session.Name;
                    script.playerCount.text = session.PlayerCount + "/" + session.MaxPlayers;

                    if(session.IsOpen == false || session.PlayerCount >= session.MaxPlayers)
                    {
                        script.joinButton.interactable = false;
                    }
                    else
                    {
                        script.joinButton.interactable= true;
                    }
                }
            }
        }

        public void OnConnectFailed(NetworkRunner runner, NetAddress remoteAddress, NetConnectFailedReason reason)
        {
          
        }

        public void OnConnectRequest(NetworkRunner runner, NetworkRunnerCallbackArgs.ConnectRequest request, byte[] token)
        {

        }

        public void OnCustomAuthenticationResponse(NetworkRunner runner, Dictionary<string, object> data)
        {

        }

        public void OnDisconnectedFromServer(NetworkRunner runner, NetDisconnectReason reason)
        {

        }

        public void OnHostMigration(NetworkRunner runner, HostMigrationToken hostMigrationToken)
        {

        }

        public void OnInput(NetworkRunner runner, NetworkInput input)
        {

        }

        public void OnInputMissing(NetworkRunner runner, PlayerRef player, NetworkInput input)
        {

        }

        public void OnObjectEnterAOI(NetworkRunner runner, NetworkObject obj, PlayerRef player)
        {

        }

        public void OnObjectExitAOI(NetworkRunner runner, NetworkObject obj, PlayerRef player)
        {

        }

        public void OnPlayerJoined(NetworkRunner runner, PlayerRef player)
        {
            Debug.Log("OnPlayerJoined");
        }

        public void OnPlayerLeft(NetworkRunner runner, PlayerRef player)
        {

        }

        public void OnReliableDataProgress(NetworkRunner runner, PlayerRef player, ReliableKey key, float progress)
        {

        }

        public void OnReliableDataReceived(NetworkRunner runner, PlayerRef player, ReliableKey key, ArraySegment<byte> data)
        {

        }

        public void OnSceneLoadDone(NetworkRunner runner)
        {

        }

        public void OnSceneLoadStart(NetworkRunner runner)
        {

        }

       

        public void OnShutdown(NetworkRunner runner, ShutdownReason shutdownReason)
        {

        }

        public void OnUserSimulationMessage(NetworkRunner runner, SimulationMessagePtr message)
        {

        }


    }

  }

