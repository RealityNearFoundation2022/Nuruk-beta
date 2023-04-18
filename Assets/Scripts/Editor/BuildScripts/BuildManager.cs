#if UNITY_EDITOR
using System;
using System.IO;
using City;
using Mirror;
using Mirror.SimpleWeb;
using UnityEditor;
using UnityEditor.Build.Reporting;
using UnityEditor.SceneManagement;
using UnityEngine;

public class BuildManager : MonoBehaviour
{
    
    static string buildPathWebGl = Path.Combine("builds", "web", "NurukJS");
    static string buildPathServer = Path.Combine("builds", "server", "server");
    
    // WebGL
    private static string hostServer = "servicenuruk.realitynear.org";
    
    [MenuItem("Builds/Build Server")]
    public static void BuildServerLinux()
    {
        // Getting arguments from command line
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
        
        // Opening scene
        var scene = EditorSceneManager.OpenScene("Assets/Scenes/City.unity");
        // Setting transport config
        GameObject gameObjectNetwork = GameObject.Find("Network");
        // Getting transport
        SimpleWebTransport simpleWebTransport = gameObjectNetwork.GetComponent<SimpleWebTransport>();
        // Setting port
        simpleWebTransport.port = 7777;
        // Setting ssl
        simpleWebTransport.sslEnabled = false;
        // Setting wss
        simpleWebTransport.clientUseWss = false;

        // Setting HUD
        NetworkManagerHUD hub = gameObjectNetwork.GetComponent<NetworkManagerHUD>();
        // Disabling HUD
        hub.enabled = false;
        
        // save
        EditorSceneManager.SaveScene(scene);

        // Building
        UnityEditor.PlayerSettings.runInBackground = false;
        var buildPlayerOptions = new BuildPlayerOptions()
        {
            scenes = new [] {"Assets/Scenes/City.unity"},
            subtarget = (int) StandaloneBuildSubtarget.Server,
            target = BuildTarget.StandaloneLinux64,
            locationPathName = buildPathServer,
            options = BuildOptions.StrictMode
        };
        // Building
        BuildReport buildReport = BuildPipeline.BuildPlayer(buildPlayerOptions );
    }
    
    [MenuItem("Builds/Build Server Windows Dev")]
    public static void BuildServerWindows()
    {
        // Getting arguments from command line
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
        
        var scene = EditorSceneManager.OpenScene("Assets/Scenes/City.unity");
        // Getting network gameObjectNetwork
        GameObject gameObjectNetwork = GameObject.Find("Network");
        // Setting transport config
        SimpleWebTransport simpleWebTransport = gameObjectNetwork.GetComponent<SimpleWebTransport>();
        // Setting port
        simpleWebTransport.port = 7778;
        // Setting ssl
        simpleWebTransport.sslEnabled = false;
        // Setting wss
        simpleWebTransport.clientUseWss = false;

        // Setting HUD
        NetworkManagerHUD hub = gameObjectNetwork.GetComponent<NetworkManagerHUD>();
        // Disabling HUD
        hub.enabled = false;

        // save
        EditorSceneManager.SaveScene(scene);

        UnityEditor.PlayerSettings.runInBackground = false;
        var buildPlayerOptions = new BuildPlayerOptions()
        {
            scenes = new [] {"Assets/Scenes/City.unity"},
            subtarget = (int) StandaloneBuildSubtarget.Server,
            target = BuildTarget.StandaloneWindows64,
            locationPathName = "../builds/windowServer",
            options = BuildOptions.StrictMode
        };
        // Building
        BuildReport buildReport = BuildPipeline.BuildPlayer(buildPlayerOptions );
    }


    // WebGL build script
    [MenuItem("Builds/Build WebGL (Client)")]
    public static void BuildWebGl()
    {
        // Getting arguments from command line
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
        
        # region Setting Scene
        // Opening scene
        var scene = EditorSceneManager.OpenScene("Assets/Scenes/City.unity");
        // Getting network gameObjectNetwork
        GameObject gameObjectNetwork = GameObject.Find("Network");
        // Setting transport config
        SimpleWebTransport simpleWebTransport = gameObjectNetwork.GetComponent<SimpleWebTransport>();
        // Setting port
        simpleWebTransport.port = 7777;
        // Setting ssl
        simpleWebTransport.sslEnabled = false;
        // Setting wss
        simpleWebTransport.clientUseWss = true;
        // Setting network manager
        CityNetworkManager cityNetworkManager = gameObjectNetwork.GetComponent<CityNetworkManager>();
        // Setting host
        cityNetworkManager.SetHostname(hostServer);
        
        // Setting HUD
        NetworkManagerHUD hub = gameObjectNetwork.GetComponent<NetworkManagerHUD>();
        // Disabling HUD
        hub.enabled = false;
        
        // WebGL configuration
        PlayerSettings.WebGL.decompressionFallback = true;
        PlayerSettings.WebGL.template = "";
        PlayerSettings.WebGL.compressionFormat = WebGLCompressionFormat.Gzip;
        PlayerSettings.runInBackground = false;
        EditorSceneManager.SaveScene(scene);
        
        # endregion
        // Building WebGL
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
                "Assets/Scenes/RecoveryPass.unity",
            },
            target = BuildTarget.WebGL,
            locationPathName = buildPathWebGl,
            options = BuildOptions.StrictMode 
        };
        // Building
        BuildReport buildReport = BuildPipeline.BuildPlayer(buildPlayerOptions);
    }
}
#endif