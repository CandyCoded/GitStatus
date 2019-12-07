// Copyright (c) Scott Doxey. All Rights Reserved. Licensed under the MIT License. See LICENSE in the project root for license information.

#if UNITY_EDITOR
using System;
using System.Collections;
using UnityEditorInternal;
using UnityEngine;
using Unity.EditorCoroutines.Editor;
using UnityEditor;

namespace CandyCoded.GitStatus
{

    public class GitStatusPanel : EditorWindow
    {

        private readonly EditorWaitForSeconds _delayBetweenUpdates = new EditorWaitForSeconds(60);

        private string _branch;

        private string[] _branches;

        private string[] _changedFiles;

        private string[] _untrackedFiles;

        private DateTime _lastUpdated;

        private EditorCoroutine _coroutine;

        private bool _isEditorFocused;

        [MenuItem("Window/CandyCoded/Git Status")]
        public static void ShowWindow()
        {

            GetWindow(typeof(GitStatusPanel), false, "Git Status", true);

        }

        private void Update()
        {

            if (InternalEditorUtility.isApplicationActive && !_isEditorFocused)
            {

                UpdateData();

            }

            _isEditorFocused = InternalEditorUtility.isApplicationActive;

        }

        private void OnGUI()
        {

            GUILayout.Space(5);

            var selectedBranch = Array.IndexOf(_branches, _branch);

            selectedBranch = EditorGUILayout.Popup("Branch:", selectedBranch, _branches);

            if (!_branches[selectedBranch].Equals(_branch))
            {

                if (_changedFiles?.Length > 0)
                {

                    EditorUtility.DisplayDialog(
                        $"Unable to checkout branch",
                        $"Unable to checkout {_branches[selectedBranch]} as with {_changedFiles?.Length} changes. " +
                        "Commit, discard or stash before checking out a different branch.",
                        "Ok");

                }
                else
                {

                    Git.CheckoutBranch(_branches[selectedBranch]);

                    _branch = _branches[selectedBranch];

                }

            }

            GUILayout.Label($"Number of Changes: {_changedFiles?.Length}");
            GUILayout.Label($"Untracked Files: {_untrackedFiles?.Length}");
            GUILayout.Label($"Last Updated: {_lastUpdated}");

            if (GUILayout.Button("Refresh"))
            {

                UpdateData();

            }

        }

        private void UpdateData()
        {

            _branch = Git.Branch();

            _branches = Git.Branches();

            _changedFiles = Git.ChangedFiles();

            _untrackedFiles = Git.UntrackedFiles();

            _lastUpdated = DateTime.Now;

            Repaint();

        }

        private IEnumerator UpdateCoroutine()
        {

            while (true)
            {

                UpdateData();

                yield return _delayBetweenUpdates;

            }

        }

        private void OnEnable()
        {

            _coroutine = EditorCoroutineUtility.StartCoroutine(UpdateCoroutine(), this);

        }

        private void OnDisable()
        {

            EditorCoroutineUtility.StopCoroutine(_coroutine);

            _coroutine = null;

        }

    }

}

#endif
