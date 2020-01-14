// Copyright (c) Scott Doxey. All Rights Reserved. Licensed under the MIT License. See LICENSE in the project root for license information.

#if UNITY_EDITOR
using System;
using System.IO;
using System.Linq;
using UnityEditor;

namespace CandyCoded.GitStatus
{

    public static class GitMenuItems
    {

        private const int PRIORITY = 5000;

        private static string GetSelectedAbsolutePath()
        {

            return Path.Combine(Environment.CurrentDirectory, GetSelectedRelativePath());

        }

        private static string GetSelectedRelativePath()
        {

            return AssetDatabase.GetAssetPath(Selection.activeObject);

        }

        [MenuItem("Git/Discard Changes", false, PRIORITY)]
        [MenuItem("Assets/Discard Changes", false, PRIORITY)]
        private static async void DiscardChanges()
        {

            try
            {

                await Git.DiscardChanges(GetSelectedAbsolutePath());

            }
            catch (Exception error)
            {

                EditorUtility.DisplayDialog("Error", error.Message, "Ok");

            }

        }

        [MenuItem("Git/Discard Changes", true, PRIORITY)]
        [MenuItem("Assets/Discard Changes", true, PRIORITY)]
        private static bool ValidateDiscardChanges()
        {

            return Selection.activeObject && File.Exists(GetSelectedAbsolutePath()) &&
                   GitStatus.changedFiles.Contains(GetSelectedRelativePath());

        }

        [MenuItem("Git/Discard All Changes", false, PRIORITY)]
        [MenuItem("Assets/Discard All Changes", false, PRIORITY)]
        private static async void DiscardAllChanges()
        {

            if (EditorUtility.DisplayDialog(
                "Discard all changes",
                $"Are you sure you want to discard all changes in {Selection.activeObject.name}?",
                "Yes",
                "Cancel"))
            {
                try
                {

                    await Git.DiscardChanges(GetSelectedAbsolutePath());

                }
                catch (Exception error)
                {

                    EditorUtility.DisplayDialog("Error", error.Message, "Ok");

                }

            }

        }

        [MenuItem("Git/Discard All Changes", true, PRIORITY)]
        [MenuItem("Assets/Discard All Changes", true, PRIORITY)]
        private static bool ValidateDiscardAllChanges()
        {

            return Selection.activeObject && Directory.Exists(GetSelectedAbsolutePath());

        }

        [MenuItem("Git/Lock File", true, PRIORITY)]
        [MenuItem("Assets/Lock File", true, PRIORITY)]
        private static bool ValidateLockFile()
        {

            return Selection.activeObject && File.Exists(GetSelectedAbsolutePath()) &&
                   !GitStatus.lockedFiles.Contains(GetSelectedRelativePath());

        }

        [MenuItem("Git/Lock File", false, PRIORITY)]
        [MenuItem("Assets/Lock File", false, PRIORITY)]
        private static async void LockFile()
        {

            try
            {

                await Git.LockFile(GetSelectedAbsolutePath());

            }
            catch (Exception error)
            {

                EditorUtility.DisplayDialog("Error", error.Message, "Ok");

            }

        }

        [MenuItem("Git/Unlock File", true, PRIORITY)]
        [MenuItem("Assets/Unlock File", true, PRIORITY)]
        private static bool ValidateUnlockFile()
        {

            return Selection.activeObject && File.Exists(GetSelectedAbsolutePath()) &&
                   GitStatus.lockedFiles.Contains(GetSelectedRelativePath());

        }

        [MenuItem("Git/Unlock File", false, PRIORITY)]
        [MenuItem("Assets/Unlock File", false, PRIORITY)]
        private static async void UnlockFile()
        {

            await Git.UnlockFile(GetSelectedAbsolutePath());

        }

        [MenuItem("Git/Force Unlock File", true, PRIORITY)]
        [MenuItem("Assets/Force Unlock File", true, PRIORITY)]
        private static bool ValidateForceUnlockFile()
        {

            return Selection.activeObject && File.Exists(GetSelectedAbsolutePath()) &&
                   GitStatus.lockedFiles.Contains(GetSelectedRelativePath());

        }

        [MenuItem("Git/Force Unlock File", false, PRIORITY)]
        [MenuItem("Assets/Force Unlock File", false, PRIORITY)]
        private static async void ForceUnlockFile()
        {

            if (EditorUtility.DisplayDialog(
                "Force unlock file",
                $"Are you sure you want to force unlock {Selection.activeObject.name}?",
                "Yes",
                "Cancel"))
            {

                await Git.ForceUnlockFile(GetSelectedAbsolutePath());

            }

        }

    }

}

#endif
