// Copyright (c) Scott Doxey. All Rights Reserved. Licensed under the MIT License. See LICENSE in the project root for license information.

#if UNITY_EDITOR
using System;

namespace CandyCoded.GitStatus
{

    public struct Locks
    {

        public Lock[] locks;

    }

    [Serializable]
    public struct Lock
    {

        [Serializable]
        public struct Owner
        {

            public string name;

        }

        public long id;

        public string path;

        public Owner owner;

        public string locked_at;

    }

}
#endif
