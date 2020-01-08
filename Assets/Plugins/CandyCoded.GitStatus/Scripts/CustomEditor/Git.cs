// Copyright (c) Scott Doxey. All Rights Reserved. Licensed under the MIT License. See LICENSE in the project root for license information.

#if UNITY_EDITOR
using System.Collections.Generic;
using System.Diagnostics;
using Debug = UnityEngine.Debug;

namespace CandyCoded.GitStatus
{

    public static class Git
    {

#if UNITY_EDITOR_WIN
        public static string GitPath => "C:\\Program Files\\Git\\cmd\\git.exe";
#else
        public static string GitPath => "/usr/local/bin/git";
#endif

        public static Process GenerateProcess(string path, string arguments)
        {

            return Process.Start(new ProcessStartInfo
            {
                FileName = path,
                Arguments = arguments,
                UseShellExecute = false,
                RedirectStandardOutput = true,
                RedirectStandardError = true,
                CreateNoWindow = true
            });

        }

        public static string Branch()
        {

            var process = GenerateProcess(GitPath, "rev-parse --abbrev-ref HEAD");

            return process?.StandardOutput.ReadLine();

        }

        public static string[] Branches()
        {

            var process = GenerateProcess(GitPath, "for-each-ref --format='%(refname:short)' refs/heads");

            var branches = new List<string>();

            while (process?.StandardOutput.ReadLine() is string line)
            {

                branches.Add(line.Trim('\''));

            }

            return branches.ToArray();

        }

        public static void CheckoutBranch(string branch)
        {

            GenerateProcess(GitPath, $"checkout {branch}");

        }

        public static string[] ChangedFiles()
        {

            var process = GenerateProcess(GitPath, "status --short --untracked-files=no --porcelain");

            var changes = new List<string>();

            while (process?.StandardOutput.ReadLine() is string line)
            {

                changes.Add(line.Trim().TrimStart('M', ' '));

            }

            return changes.ToArray();

        }

        public static string[] UntrackedFiles()
        {

            var process = GenerateProcess(GitPath, "ls-files --others --exclude-standard");

            var changes = new List<string>();

            while (process?.StandardOutput.ReadLine() is string line)
            {

                changes.Add(line.Trim());

            }

            return changes.ToArray();

        }

        public static void DiscardChanges(string path)
        {

            var process = GenerateProcess(GitPath, $@"checkout ""{path}""");

            if (process?.StandardError.ReadLine() is string line && line.StartsWith("error: pathspec"))
            {

                Debug.LogError("File not tracked by git.");

            }

        }

    }

}
#endif
