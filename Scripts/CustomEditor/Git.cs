// Copyright (c) Scott Doxey. All Rights Reserved. Licensed under the MIT License. See LICENSE in the project root for license information.

#if UNITY_EDITOR
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Threading.Tasks;

namespace CandyCoded.GitStatus
{

    public static class Git
    {

#if UNITY_EDITOR_WIN
        private static string GitPath => @"C:\Program Files\Git\bin\git.exe";
#else
        private static string GitPath => "/usr/local/bin/git";
#endif

        private static string RepoPath => $"{Environment.CurrentDirectory}{Path.DirectorySeparatorChar}";

        public static Process GenerateProcess(string path, string arguments)
        {

            return Process.Start(new ProcessStartInfo
            {
                FileName = path,
                Arguments = arguments,
                WorkingDirectory = RepoPath,
                UseShellExecute = false,
                RedirectStandardOutput = true,
                RedirectStandardError = true,
                CreateNoWindow = true
            });

        }

        public static Task<Process> GenerateProcessAsync(string path, string arguments)
        {

            return Task.Run(() => GenerateProcess(path, arguments));

        }

        public static async Task<string> Branch()
        {

            var process = await GenerateProcessAsync(GitPath, "rev-parse --abbrev-ref HEAD");

            return process?.StandardOutput.ReadLine();

        }

        public static async Task<string[]> Branches()
        {

            var process = await GenerateProcessAsync(GitPath, "for-each-ref --format='%(refname:short)' refs/heads");

            var branches = new List<string>();

            while (process?.StandardOutput.ReadLine() is string line)
            {

                branches.Add(line.Trim('\''));

            }

            return branches.ToArray();

        }

        public static async Task<string[]> ChangedFiles()
        {

            var process = await GenerateProcessAsync(GitPath, "status --short --untracked-files=no --porcelain");

            var changes = new List<string>();

            while (process?.StandardOutput.ReadLine() is string line)
            {

                changes.Add(line.Trim().TrimStart('M', ' '));

            }

            return changes.ToArray();

        }

        public static async Task CheckoutBranch(string branch)
        {

            await GenerateProcessAsync(GitPath, $"checkout {branch}");

        }

        public static async Task DiscardChanges(string path)
        {

            var process = await GenerateProcessAsync(GitPath, $@"checkout ""{path}""");

            if (process?.StandardError.ReadLine() is string line && line.StartsWith("error: pathspec"))
            {

                throw new Exception("File not tracked by git.");

            }

        }

        public static async Task Init()
        {

            await GenerateProcessAsync(GitPath, "init");

        }

        public static async Task<string> Status()
        {

            var process = await GenerateProcessAsync(GitPath, "status");

            if (process?.StandardError.ReadLine() is string line && line.StartsWith("fatal: not a git repository"))
            {

                throw new Exception("Path is not a git repository.");

            }

            return process?.StandardOutput.ReadToEnd();

        }

        public static async Task<string[]> UntrackedFiles()
        {

            var process = await GenerateProcessAsync(GitPath, "ls-files --others --exclude-standard");

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
