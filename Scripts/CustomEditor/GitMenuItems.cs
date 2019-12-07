// Copyright (c) Scott Doxey. All Rights Reserved. Licensed under the MIT License. See LICENSE in the project root for license information.

#if UNITY_EDITOR
using System;
using System.IO;
using UnityEditor;

namespace CandyCoded.GitStatus
{

    public static class GitMenuItems
    {

        private const int PRIORITY = 5000;

        private static string GetSelectedPath()
        {

            return Path.Combine(Environment.CurrentDirectory, AssetDatabase.GetAssetPath(Selection.activeObject));

        }

        [MenuItem("Assets/Discard Changes", false, PRIORITY)]
        private static void DiscardChanges()
        {

            Git.DiscardChanges(GetSelectedPath());

        }

        [MenuItem("Assets/Discard Changes", true, PRIORITY)]
        private static bool ValidateDiscardChanges()
        {

            return Selection.activeObject && File.Exists(GetSelectedPath());

        }

        [MenuItem("Assets/Discard All Changes", false, PRIORITY)]
        private static void DiscardAllChanges()
        {

            if (EditorUtility.DisplayDialog(
                "Discard all changes",
                $"Are you sure you want to discard all changes in {Selection.activeObject.name}?",
                "Yes",
                "Cancel"))
            {

                Git.DiscardChanges(GetSelectedPath());

            }

        }

        [MenuItem("Assets/Discard All Changes", true, PRIORITY)]
        private static bool ValidateDiscardAllChanges()
        {

            return Selection.activeObject && Directory.Exists(GetSelectedPath());

        }

    }

}

#endif
