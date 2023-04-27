using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using agora_gaming_rtc;
using System;
using Mirror;
//using Hashtable = ExitGames.Client.Photon.Hashtable;

public class VoiceChatManager : NetworkBehaviour
{
	string appID = "00334a841638456ab144afcf8e2bdb83";

	public static VoiceChatManager Instance;

	IRtcEngine rtcEngine;

	//public Dict<string> players = new List<string>();
	public Dictionary<uint, string> players = new Dictionary<uint, string>();


	void Awake()
	{
		if(Instance)
		{
			Destroy(gameObject);
		}
		else
		{
			Instance = this;
			DontDestroyOnLoad(gameObject);
		}
	}

	private void Start()
	{
		if(string.IsNullOrEmpty(appID))
		{
			Debug.LogError("App ID not set in VoiceChatManager script");
			return;
		}

		rtcEngine = IRtcEngine.GetEngine(appID);

		rtcEngine.OnJoinChannelSuccess += OnJoinChannelSuccess;
		rtcEngine.OnLeaveChannel += OnLeaveChannel;
		rtcEngine.OnError += OnError;

		rtcEngine.EnableSoundPositionIndication(true);
	}

	void OnError(int error, string msg)
	{
		Debug.LogError("Error with Agora: " + msg);
	}

	void OnLeaveChannel(RtcStats stats)
	{
		Debug.Log("Left channel with duration " + stats.duration);
	}

	void OnJoinChannelSuccess(string channelName, uint uid, int elapsed)
	{
		Debug.Log("Joined channel " + channelName);
		Debug.Log(NetworkClient.localPlayer.netId);

		players.Add(NetworkClient.localPlayer.netId, uid.ToString());
		/* Hashtable hash = new Hashtable();
		hash.Add("agoraID", uid.ToString());
		PhotonNetwork.SetPlayerCustomProperties(hash); */
	}

	public IRtcEngine GetRtcEngine()
	{
		return rtcEngine;
	}
	public override void OnStartClient()
    {
		rtcEngine.JoinChannel("unity3d");
    }

    public override void OnStopClient()
    {
		rtcEngine.LeaveChannel();
    }

	void OnDestroy()
	{
		IRtcEngine.Destroy();
	}
}
