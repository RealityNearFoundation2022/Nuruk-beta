//using Photon.Pun;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
//using Photon.Realtime;
using agora_gaming_rtc;
using System.Linq;
//using System;
using Mirror;

public class SpatialAudio : NetworkBehaviour
{
	[SerializeField] float radius;

//	PhotonView PV;
	NetworkIdentity PV;

	static Dictionary<uint, SpatialAudio> spatialAudioFromPlayers = new Dictionary<uint, SpatialAudio>();

	IAudioEffectManager agoraAudioEffects;

	void Awake()
	{
		PV = GetComponent<NetworkIdentity>();
		agoraAudioEffects = VoiceChatManager.Instance.GetRtcEngine().GetAudioEffectManager();

	}
	public void OnConnectedToServer()
    {
        spatialAudioFromPlayers[NetworkClient.localPlayer.netId] = this;
    }
	void OnDestroy()
	{
		foreach(var item in spatialAudioFromPlayers.Where(x => x.Value == this).ToList())
		{
			spatialAudioFromPlayers.Remove(item.Key);
		}
	}

	void Update()
	{
		if(!isLocalPlayer)
			return;

		foreach(var player in NetworkClient.spawned)
		{
			if(player.Value.isLocalPlayer)
				continue;

			//if(player.CustomProperties.TryGetValue("agoraID", out object agoraID))
			if(VoiceChatManager.Instance.players.ContainsKey(player.Value.netId))
			{
				string agoraID = VoiceChatManager.Instance.players[player.Value.netId];
				if(spatialAudioFromPlayers.ContainsKey(player.Value.netId))
				{
					SpatialAudio other = spatialAudioFromPlayers[player.Value.netId];

					float gain = GetGain(other.transform.position);
					float pan = GetPan(other.transform.position);

					agoraAudioEffects.SetRemoteVoicePosition(uint.Parse((string)agoraID), pan, gain);
				}
				else
				{
					agoraAudioEffects.SetRemoteVoicePosition(uint.Parse((string)agoraID), 0, 0);
				}
			}
		}
	}

	float GetGain(Vector3 otherPosition)
	{
		float distance = Vector3.Distance(transform.position, otherPosition);
		float gain = Mathf.Max(1 - (distance / radius), 0) * 100f;
		return gain;
	}

	float GetPan(Vector3 otherPosition)
	{
		Vector3 direction = otherPosition - transform.position;
		direction.Normalize();
		float dotProduct = Vector3.Dot(transform.right, direction);
		return dotProduct;
	}
}
