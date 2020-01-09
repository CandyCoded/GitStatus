// Copyright (c) Scott Doxey. All Rights Reserved. Licensed under the MIT License. See LICENSE in the project root for license information.

#if UNITY_EDITOR
using System;
using UnityEditor;

namespace CandyCoded.GitStatus
{

    [InitializeOnLoad]
    public static class GitStatus
    {

        public static string branch = "HEAD";

        public static string[] branches = { };

        public static string[] changedFiles = { };

        public static string[] untrackedFiles = { };

        public static DateTime lastUpdated = DateTime.Now;

        static GitStatus()
        {

            FileWatcher.UpdateEvent -= Update;
            FileWatcher.UpdateEvent += Update;

            Update();

        }

        public static void Update()
        {

            branch = Git.Branch();

            branches = Git.Branches();

            changedFiles = Git.ChangedFiles();

            untrackedFiles = Git.UntrackedFiles();

            lastUpdated = DateTime.Now;

        }

    }

}
#endif
