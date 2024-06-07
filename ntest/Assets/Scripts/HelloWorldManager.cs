using Unity.Netcode;
using UnityEngine;
using UnityEngine.UIElements;

namespace HelloWorld
{
	public class HelloWorldManager : MonoBehaviour
	{
		void OnGUI()
		{
			GUILayout.BeginArea(new Rect(10, 10, 500, 300));
			if (!NetworkManager.Singleton.IsClient && !NetworkManager.Singleton.IsServer)
			{
				StartButtons();
			}
			else
			{
				StatusLabels();
			}

			GUILayout.EndArea();
		}

		static void StartButtons()
		{
			if (GUILayout.Button("Host")) NetworkManager.Singleton.StartHost();
			if (GUILayout.Button("Client")) NetworkManager.Singleton.StartClient();
			if (GUILayout.Button("Server")) NetworkManager.Singleton.StartServer();
		}

		static void StatusLabels()
		{
			var mode = NetworkManager.Singleton.IsHost ?
				"Host" : NetworkManager.Singleton.IsServer ? "Server" : "Client";

			GUILayout.Label("Transport: " +
				NetworkManager.Singleton.NetworkConfig.NetworkTransport.GetType().Name);
			GUILayout.Label("Mode: " + mode);
		}

		void Update()
		{
			if (Input.GetKeyDown(KeyCode.W))
			{
				if (NetworkManager.Singleton.IsServer && !NetworkManager.Singleton.IsClient)
				{
					foreach (ulong uid in NetworkManager.Singleton.ConnectedClientsIds)
						NetworkManager.Singleton.SpawnManager.GetPlayerNetworkObject(uid).GetComponent<HelloWorldPlayer>().Up();
				}
				else
				{
					var playerObject = NetworkManager.Singleton.SpawnManager.GetLocalPlayerObject();
					var player = playerObject.GetComponent<HelloWorldPlayer>();
					player.Up();
				}
			}

			if (Input.GetKeyDown(KeyCode.S))
			{
				if (NetworkManager.Singleton.IsServer && !NetworkManager.Singleton.IsClient)
				{
					foreach (ulong uid in NetworkManager.Singleton.ConnectedClientsIds)
						NetworkManager.Singleton.SpawnManager.GetPlayerNetworkObject(uid).GetComponent<HelloWorldPlayer>().Down();
				}
				else
				{
					var playerObject = NetworkManager.Singleton.SpawnManager.GetLocalPlayerObject();
					var player = playerObject.GetComponent<HelloWorldPlayer>();
					player.Down();
				}
			}

			if (Input.GetKeyDown(KeyCode.A))
			{
				if (NetworkManager.Singleton.IsServer && !NetworkManager.Singleton.IsClient)
				{
					foreach (ulong uid in NetworkManager.Singleton.ConnectedClientsIds)
						NetworkManager.Singleton.SpawnManager.GetPlayerNetworkObject(uid).GetComponent<HelloWorldPlayer>().Left();
				}
				else
				{
					var playerObject = NetworkManager.Singleton.SpawnManager.GetLocalPlayerObject();
					var player = playerObject.GetComponent<HelloWorldPlayer>();
					player.Left();
				}
			}

			if (Input.GetKeyDown(KeyCode.D))
			{
				if (NetworkManager.Singleton.IsServer && !NetworkManager.Singleton.IsClient)
				{
					foreach (ulong uid in NetworkManager.Singleton.ConnectedClientsIds)
						NetworkManager.Singleton.SpawnManager.GetPlayerNetworkObject(uid).GetComponent<HelloWorldPlayer>().Right();
				}
				else
				{
					var playerObject = NetworkManager.Singleton.SpawnManager.GetLocalPlayerObject();
					var player = playerObject.GetComponent<HelloWorldPlayer>();
					player.Right();
				}
			}
		}
	}
}
