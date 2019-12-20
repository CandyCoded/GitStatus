// Copyright (c) Scott Doxey. All Rights Reserved. Licensed under the MIT License. See LICENSE in the project root for license information.

#if UNITY_EDITOR
using System;
using UnityEditor;
using UnityEngine;

namespace CandyCoded.GitStatus
{

    public class GitStatusPanel : EditorWindow
    {

        [MenuItem("Git/Git Status")]
        public static void ShowWindow()
        {

            GetWindow(typeof(GitStatusPanel), false, "Git Status", true);

        }

        private void OnGUI()
        {

            GUILayout.Space(5);

            var selectedBranch = Array.IndexOf(GitStatus.branches, GitStatus.branch);

            selectedBranch = EditorGUILayout.Popup("Branch:", selectedBranch, GitStatus.branches);

            if (!GitStatus.branches[selectedBranch].Equals(GitStatus.branch))
            {

                if (GitStatus.changedFiles?.Length > 0)
                {

                    EditorUtility.DisplayDialog(
                        "Unable to checkout branch",
                        $"Unable to checkout {GitStatus.branches[selectedBranch]} as with {GitStatus.changedFiles?.Length} changes. " +
                        "Commit, discard or stash before checking out a different branch.",
                        "Ok");

                }
                else
                {

                    Git.CheckoutBranch(GitStatus.branches[selectedBranch]);

                }

            }

            GUILayout.Label($"Number of Changes: {GitStatus.changedFiles?.Length}");
            GUILayout.Label($"Untracked Files: {GitStatus.untrackedFiles?.Length}");
            GUILayout.Label($"Last Updated: {GitStatus.lastUpdated}");

            if (GUILayout.Button("Refresh"))
            {

                GitStatus.Update();

            }

        }

    }

}

#endif
