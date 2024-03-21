using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Fusion;
using Fusion.Sockets;
using System;


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


        public async void ConnectToRunner( string playerName )
        {
            _playerName = playerName;

            if (runner == null)
            {
                runner = gameObject.AddComponent<NetworkRunner>();
            }

            await runner.StartGame(new StartGameArgs()
            {

                GameMode = GameMode.Shared,
                SessionName = "test",
                PlayerCount = 2,
                //SceneManager = gameObject.AddComponent<NetworkSceneManagerDefault>(),

            });
        }

        public void OnConnectedToServer(NetworkRunner runner)
        {
            Debug.Log("Connected server");

            if (playerApperance)
            {
                NetworkObject playerObject = runner.Spawn(playerPrefab, Vector3.zero);

                runner.SetPlayerObject(runner.LocalPlayer, playerObject);
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

        public void OnSessionListUpdated(NetworkRunner runner, List<SessionInfo> sessionList)
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

