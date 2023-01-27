#if UNITY_EDITOR
using System;
using System.IO;
using City;
using Mirror;
using Mirror.SimpleWeb;
using UnityEditor;
using UnityEditor.Build.Reporting;
using UnityEngine;

public class BuildManager : MonoBehaviour
{
    
    static string buildPathWebGl = Path.Combine(Application.dataPath, "builds", "NurukJS");
    static string buildPathServer = Path.Combine(Application.dataPath, "builds", "server");
    
    // WebGL
    private static string hostServer = "servernuruk.devsgio.tech";
    
    [MenuItem("Builds/Build Server")]
    public static void BuildServerLinux()
    {
        var args = Environment.GetCommandLineArgs();
        for (var i = 0; i < args.Length; i++)
        {
            switch (args[i])
            {
                case "-buildPath":
                    buildPathServer = args[i + 1];
                    break;
            }
        }

        // if the output folder doesn't exist create it now
        if (!Directory.Exists(buildPathServer))
        {
            Directory.CreateDirectory(buildPathServer);
        }
        
        EditorApplication.OpenScene("Assets/Scenes/City.unity");
        // Setting transport config
        GameObject gameObjectNetwork = GameObject.Find("Network");
        // Getting transport
        SimpleWebTransport simpleWebTransport = gameObjectNetwork.GetComponent<SimpleWebTransport>();
        Debug.Log(simpleWebTransport);
        UnityEngine.Debug.Log(simpleWebTransport);
        simpleWebTransport.port = 443;
        simpleWebTransport.sslEnabled = true;
        simpleWebTransport.clientUseWss = true;

        NetworkManagerHUD hub = gameObjectNetwork.GetComponent<NetworkManagerHUD>();
        hub.enabled = false;
        
        
        // save
        EditorApplication.SaveScene("Assets/Scenes/City.unity");


        UnityEditor.PlayerSettings.runInBackground = false;
        var buildPlayerOptions = new BuildPlayerOptions()
        {
            scenes = new [] {"Assets/Scenes/City.unity"},
            subtarget = (int) StandaloneBuildSubtarget.Server,
            target = BuildTarget.StandaloneLinux64,
            locationPathName = buildPathServer,
            options = BuildOptions.EnableHeadlessMode | BuildOptions.StrictMode
        };
        BuildReport buildReport = BuildPipeline.BuildPlayer(buildPlayerOptions );
        UnityEngine.Debug.Log(buildReport.summary);
    }
    
    [MenuItem("Builds/Build Server Windows Dev")]
    public static void BuildServerWindows()
    {
        var args = Environment.GetCommandLineArgs();
        for (var i = 0; i < args.Length; i++)
        {
            switch (args[i])
            {
                case "-buildPath":
                    buildPathServer = args[i + 1];
                    break;
            }
        }

        // if the output folder doesn't exist create it now
        if (!Directory.Exists(buildPathServer))
        {
            Directory.CreateDirectory(buildPathServer);
        }
        
        EditorApplication.OpenScene("Assets/Scenes/City.unity");
        // Getting network gameObjectNetwork
        GameObject gameObjectNetwork = GameObject.Find("Network");
        // Setting transport config
        SimpleWebTransport simpleWebTransport = gameObjectNetwork.GetComponent<SimpleWebTransport>();
        Debug.Log(simpleWebTransport);
        UnityEngine.Debug.Log(simpleWebTransport);
        simpleWebTransport.port = 443;
        simpleWebTransport.sslEnabled = false;
        simpleWebTransport.clientUseWss = false;

        NetworkManagerHUD hub = gameObjectNetwork.GetComponent<NetworkManagerHUD>();
        hub.enabled = false;
        
        
        // save
        EditorApplication.SaveScene("Assets/Scenes/City.unity");


        UnityEditor.PlayerSettings.runInBackground = false;
        var buildPlayerOptions = new BuildPlayerOptions()
        {
            scenes = new [] {"Assets/Scenes/City.unity"},
            subtarget = (int) StandaloneBuildSubtarget.Server,
            target = BuildTarget.StandaloneWindows64,
            locationPathName = "../builds/windowServer",
            options = BuildOptions.EnableHeadlessMode | BuildOptions.StrictMode
        };
        BuildReport buildReport = BuildPipeline.BuildPlayer(buildPlayerOptions );
        UnityEngine.Debug.Log(buildReport.summary);
    }

    [MenuItem("Builds/Build WebGL")]
    public static void BuildWebGl()
    {
        var args = Environment.GetCommandLineArgs();
        for (var i = 0; i < args.Length; i++)
        {
            switch (args[i])
            {
                case "-buildPath":
                    buildPathWebGl = args[i + 1];
                    break;
                case "-host":
                    hostServer = args[i + 1];
                    break;
            }
        }
        
        // if the output folder doesn't exist create it now
        if (!Directory.Exists(buildPathWebGl))
        {
            Directory.CreateDirectory(buildPathWebGl);
        }
        
        # region Setting Scene
        EditorApplication.OpenScene("Assets/Scenes/City.unity");
        // Getting network gameObjectNetwork
        GameObject gameObjectNetwork = GameObject.Find("Network");
        // Setting transport config
        SimpleWebTransport simpleWebTransport = gameObjectNetwork.GetComponent<SimpleWebTransport>();
        simpleWebTransport.port = 443;
        simpleWebTransport.sslEnabled = true;
        simpleWebTransport.clientUseWss = true;
        // Setting network manager
        CityNetworkManager cityNetworkManager = gameObjectNetwork.GetComponent<CityNetworkManager>();
        cityNetworkManager.SetHostname(hostServer);
        

        NetworkManagerHUD hub = gameObjectNetwork.GetComponent<NetworkManagerHUD>();
        hub.enabled = false;
        
        // WebGL configuration
        PlayerSettings.WebGL.decompressionFallback = true;
        PlayerSettings.WebGL.template = "";
        PlayerSettings.WebGL.compressionFormat = WebGLCompressionFormat.Gzip;
        PlayerSettings.runInBackground = false;
        EditorApplication.SaveScene("Assets/Scenes/City.unity");
        
        # endregion
        var buildPlayerOptions = new BuildPlayerOptions()
        {
            scenes = new []
            {
                "Assets/Scenes/Opening.unity",
                "Assets/Scenes/LoginNuruk.unity",
                "Assets/Scenes/Register.unity",
                "Assets/Scenes/CharacterSelect.unity",
                "Assets/Scenes/City.unity",
                "Assets/Scenes/LoginNear.unity",
                "Assets/Scenes/recoveryPass.unity",
            },
            target = BuildTarget.WebGL,
            locationPathName = buildPathWebGl,
            options = BuildOptions.EnableHeadlessMode | BuildOptions.StrictMode 
        };
        BuildReport buildReport = BuildPipeline.BuildPlayer(buildPlayerOptions );
        UnityEngine.Debug.Log(buildReport.summary);
    }
}
#endif