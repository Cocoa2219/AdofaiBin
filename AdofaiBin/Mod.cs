using System;
using ADOFAI;
using SFB;
using UnityEngine;
using UnityModManagerNet;

namespace AdofaiBin
{
    public static class Mod
    {
        private static UnityModManager.ModEntry.ModLogger _logger;

        public static void Initialize(UnityModManager.ModEntry modEntry)
        {
            modEntry.OnGUI = OnGUI;

            _logger = modEntry.Logger;
        }

        private static string _inputFilePath = "";
        private static string _outputFilePath = "";

        private static void OnGUI(UnityModManager.ModEntry modEntry)
        {
            var style = new GUIStyle(GUI.skin.label)
            {
                alignment = TextAnchor.MiddleCenter,
                fontSize = 24,
                fontStyle = FontStyle.Bold
            };
            GUILayout.Label("AdofaiBin Converter", style);

            GUILayout.Space(10);

            GUILayout.BeginHorizontal();
            GUILayout.Label("Input File Path:", GUILayout.Width(150));
            _inputFilePath = GUILayout.TextField(_inputFilePath, GUILayout.Width(300));

            if (GUILayout.Button("Browse", GUILayout.Width(100)))
            {
                var paths = StandaloneFileBrowser.OpenFilePanel("Select ADOFAI Level File", "", "adofai", false);
                if (paths.Length > 0)
                {
                    _inputFilePath = paths[0];
                }
            }

            GUILayout.EndHorizontal();

            GUILayout.Space(5);

            GUILayout.BeginHorizontal();
            GUILayout.Label("Output File Path:", GUILayout.Width(150));
            _outputFilePath = GUILayout.TextField("", GUILayout.Width(300));
            if (GUILayout.Button("Browse", GUILayout.Width(100)))
            {
                var paths = StandaloneFileBrowser.SaveFilePanel("Select Output File", "", "level.adobin", "adobin");
                if (paths.Length > 0)
                {
                    _outputFilePath = paths;
                }
            }

            GUILayout.EndHorizontal();

            GUILayout.Space(10);
        }
    }
}