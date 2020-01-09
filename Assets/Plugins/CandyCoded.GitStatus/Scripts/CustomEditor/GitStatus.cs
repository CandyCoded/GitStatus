// Copyright (c) Scott Doxey. All Rights Reserved. Licensed under the MIT License. See LICENSE in the project root for license information.

#if UNITY_EDITOR
using System;
using System.Threading.Tasks;
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

            Task.Run(UpdateAsync);

        }

        public static async void UpdateAsync()
        {

            branch = await Git.Branch();
            branches = await Git.Branches();
            changedFiles = await Git.ChangedFiles();
            untrackedFiles = await Git.UntrackedFiles();

            lastUpdated = DateTime.Now;

        }

    }

}
#endif
