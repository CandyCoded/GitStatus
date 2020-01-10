// Copyright (c) Scott Doxey. All Rights Reserved. Licensed under the MIT License. See LICENSE in the project root for license information.

#if UNITY_EDITOR
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Threading.Tasks;

namespace CandyCoded.GitStatus
{

    public static class Git
    {

#if UNITY_EDITOR_WIN
        public static string GitPath => "C:\\Program Files\\Git\\cmd\\git.exe";
#else
        public static string GitPath => "/usr/local/bin/git";
#endif

        private static Task<Process> GenerateProcess(string path, string arguments)
        {

            return Task.Run(() => Process.Start(new ProcessStartInfo
            {
                FileName = path,
                Arguments = arguments,
                UseShellExecute = false,
                RedirectStandardOutput = true,
                RedirectStandardError = true,
                CreateNoWindow = true
            }));

        }

        public static async Task<string> Branch()
        {

            var process = await GenerateProcess(GitPath, "rev-parse --abbrev-ref HEAD");

            return process?.StandardOutput.ReadLine();

        }

        public static async Task<string[]> Branches()
        {

            var process = await GenerateProcess(GitPath, "for-each-ref --format='%(refname:short)' refs/heads");

            var branches = new List<string>();

            while (process?.StandardOutput.ReadLine() is string line)
            {

                branches.Add(line.Trim('\''));

            }

            return branches.ToArray();

        }

        public static async Task<string[]> ChangedFiles()
        {

            var process = await GenerateProcess(GitPath, "status --short --untracked-files=no --porcelain");

            var changes = new List<string>();

            while (process?.StandardOutput.ReadLine() is string line)
            {

                changes.Add(line.Trim().TrimStart('M', ' '));

            }

            return changes.ToArray();

        }

        public static void CheckoutBranch(string branch)
        {

            GenerateProcess(GitPath, $"checkout {branch}");

        }

        public static async Task DiscardChanges(string path)
        {

            var process = await GenerateProcess(GitPath, $@"checkout ""{path}""");

            if (process?.StandardError.ReadLine() is string line && line.StartsWith("error: pathspec"))
            {

                throw new Exception("File not tracked by git.");

            }

        }

        public static async Task<string[]> UntrackedFiles()
        {

            var process = await GenerateProcess(GitPath, "ls-files --others --exclude-standard");

            var changes = new List<string>();

            while (process?.StandardOutput.ReadLine() is string line)
            {

                changes.Add(line.Trim());

            }

            return changes.ToArray();

        }

    }

}
#endif
