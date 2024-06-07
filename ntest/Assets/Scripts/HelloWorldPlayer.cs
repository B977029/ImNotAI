using Unity.Netcode;
using UnityEngine;
using static UnityEngine.RuleTile.TilingRuleOutput;

namespace HelloWorld
{
	public class HelloWorldPlayer : NetworkBehaviour
	{
		public NetworkVariable<Vector3> Position = new NetworkVariable<Vector3>();

		public override void OnNetworkSpawn()
		{
			if (IsOwner)
			{
				Spawn();
			}
		}

		public void Spawn()
		{
			SubmitPositionRequestServerRpc();
		}

		public void Up()
		{
			UPRequestServerRpc();
		}

		public void Down()
		{
			DownRequestServerRpc();
		}

		public void Left()
		{
			LeftRequestServerRpc();
		}

		public void Right()
		{
			RightRequestServerRpc();
		}

		[Rpc(SendTo.Server)]
		void SubmitPositionRequestServerRpc(RpcParams rpcParams = default)
		{
			var randomPosition = GetRandomPosition();
			transform.position = randomPosition;
			Position.Value = randomPosition;
		}

		static Vector3 GetRandomPosition()
		{
			return new Vector3(Random.Range(-3f, 3f), 1f, Random.Range(-3f, 3f));
		}

		[Rpc(SendTo.Server)]
		void UPRequestServerRpc()
		{
			transform.position = new Vector3(0f, 3f, 1f);
			Position.Value = new Vector3(0f, 3f, 1f);
		}

		[Rpc(SendTo.Server)]
		void DownRequestServerRpc()
		{
			transform.position = new Vector3(0f, -3f, 1f);
			Position.Value = new Vector3(0f, -3f, 1f);
		}

		[Rpc(SendTo.Server)]
		void LeftRequestServerRpc()
		{
			transform.position = new Vector3(-3f, 0f, 1f);
			Position.Value = new Vector3(-3f, 0f, 1f);
		}

		[Rpc(SendTo.Server)]
		void RightRequestServerRpc()
		{
			transform.position = new Vector3(3f, 0f, 1f);
			Position.Value = new Vector3(3f, 0f, 1f);
		}

		void Update()
		{
			transform.position = Position.Value;
		}
	}
}
