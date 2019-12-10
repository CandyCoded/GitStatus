// Copyright (c) Scott Doxey. All Rights Reserved. Licensed under the MIT License. See LICENSE in the project root for license information.

#if UNITY_EDITOR
using System.Linq;
using UnityEditor;
using UnityEngine;

namespace CandyCoded.GitStatus
{

    [InitializeOnLoad]
    public class ProjectPanel : AssetPostprocessor
    {

        private const float ICON_SCALE = 0.25f;

        private const float ICON_PADDING = 2;

        private static string[] _changedFiles;

        private static string[] _untrackedFiles;

        static ProjectPanel()
        {

            EditorApplication.projectWindowItemOnGUI -= ProjectWindowItemOnGui;
            EditorApplication.projectWindowItemOnGUI += ProjectWindowItemOnGui;

            _changedFiles = Git.ChangedFiles();

            _untrackedFiles = Git.UntrackedFiles();

        }

        private static void ProjectWindowItemOnGui(string guid, Rect selectionRect)
        {

            if (!Event.current.type.Equals(EventType.Repaint))
            {

                return;

            }

            if (string.IsNullOrEmpty(guid))
            {

                return;

            }

            var path = AssetDatabase.GUIDToAssetPath(guid);

            var iconSize = Mathf.Max(selectionRect.height * ICON_SCALE, EditorGUIUtility.singleLineHeight);

            var rect = new Rect(
                selectionRect.xMax - iconSize - ICON_PADDING,
                selectionRect.y + ICON_PADDING,
                iconSize - ICON_PADDING,
                iconSize - ICON_PADDING);

            if (_changedFiles.Contains(path))
            {

                GUI.DrawTexture(rect, GitIcons.Changed, ScaleMode.ScaleToFit);

            }
            else if (_untrackedFiles.Contains(path))
            {

                GUI.DrawTexture(rect, GitIcons.Untracked, ScaleMode.ScaleToFit);

            }

        }

        private static void OnPostprocessAllAssets(
            string[] importedAssets,
            string[] deletedAssets,
            string[] movedAssets,
            string[] movedFromAssetPaths)
        {

            _changedFiles = Git.ChangedFiles();

            _untrackedFiles = Git.UntrackedFiles();

        }

    }

}
#endif
