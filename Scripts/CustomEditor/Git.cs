// Copyright (c) Scott Doxey. All Rights Reserved. Licensed under the MIT License. See LICENSE in the project root for license information.

#if UNITY_EDITOR
using System;
using System.Diagnostics;
using System.Linq;

namespace CandyCoded.GitStatus
{

    public static class Git
    {

        public static string Branch()
        {

            var process = Process.Start(new ProcessStartInfo
            {
                FileName = "/usr/local/bin/git",
                Arguments = "rev-parse --abbrev-ref HEAD",
                UseShellExecute = false,
                RedirectStandardOutput = true,
                RedirectStandardError = true,
                CreateNoWindow = true
            });

            return process?.StandardOutput.ReadLine();

        }

        public static string[] AllChanges()
        {

            var process = Process.Start(new ProcessStartInfo
            {
                FileName = "/usr/local/bin/git",
                Arguments = "status --short --untracked-files --porcelain",
                UseShellExecute = false,
                RedirectStandardOutput = true,
                RedirectStandardError = true,
                CreateNoWindow = true
            });

            return process?.StandardOutput
                .ReadToEnd()
                .Split(new[] { Environment.NewLine }, StringSplitOptions.RemoveEmptyEntries)
                .ToArray();

        }

        public static string[] ChangedFiles()
        {

            return AllChanges().Except(UntrackedFiles()).ToArray();

        }

        public static string[] UntrackedFiles()
        {

            return AllChanges().Where(file => file.StartsWith("??")).ToArray();

        }

    }

}
#endif
