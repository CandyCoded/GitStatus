// Copyright (c) Scott Doxey. All Rights Reserved. Licensed under the MIT License. See LICENSE in the project root for license information.

#if UNITY_EDITOR
using System;
using UnityEngine;

namespace CandyCoded.GitStatus
{

    [Serializable]
    public static class GitIcons
    {

        public const int SIZE = 128;

        private static Texture2D _changed;

        public static Texture2D Changed
        {

            get
            {
                if (_changed != null)
                {
                    return _changed;
                }

                _changed = new Texture2D(SIZE, SIZE);

                _changed.LoadImage(Convert.FromBase64String(
                    "iVBORw0KGgoAAAANSUhEUgAAAIAAAACACAMAAAD04JH5AAAAbFBMVEUA/6sJ/60+/79n/8yO/9m1/+bS//Df//Ts//j5//02/7x//9TB/+r///8g/7V8/9PZ//Ix/7us/+P9//4w/7oP/6+S/9v8//5R/8Xn//cG/6wf/7XM/+4t/7nl//Y9/7/v//n2//z+//4//784jO7vAAABiklEQVR4Ae3aBXbkQAwE0OpZ9lhmhsH7H2mT3KTzIMxRy6OA/gnqma0SjDHGGGOMMebbc+Bx1+Cv4XSidfyPHvgXryOcRJJm9IwsTbC0vCjpBWWRY0nVL3rVrwpLqZuW3qBtaiyi6+mN+g7yhobeoRkgbJzoXaYRouYNvdNmhqDtjt5tt4WY7Z4Y9mIJ5h2x7GaIGDfEtBkhYJiIbRoQrqEADYJ1FKRDoLqnIH0tewLkT8IKL6ocArkKIX5RsF8IkJOAPOAUOAhwYEsOJKBMwJWSiJR9Chygeg4iEhIxj4CDEKcfgMX9IyH/HDiOJObIOgUXEHPBCuAgxlkAC/A5A8hiBPAQ4y2ABdAPoPw6Xul/kLDEJCRmfhN6CPH6AZgyEpGx/4y88gHQ/zlFQQKKgPmAhwCvP6IJGFKlEQJFqf6YTn9QqT+q1R9W64/r9QsL/cpGv7TSr+30i0v96la/vNav73UXGBRWOOTlxUFziUV/jUd+kcmBxx0u7q1y7c48jDHGGGOMMcawXALKIb4v/YRInAAAAABJRU5ErkJggg=="
                ));

                return _changed;
            }

        }

        private static Texture2D _untracked;

        public static Texture2D Untracked
        {

            get
            {
                if (_untracked != null)
                {

                    return _untracked;

                }

                _untracked = new Texture2D(SIZE, SIZE);

                _untracked.LoadImage(Convert.FromBase64String(
                    "iVBORw0KGgoAAAANSUhEUgAAAIAAAACAAQMAAAD58POIAAAABlBMVEUA/6v////118ZVAAAAJ0lEQVR4AWMY2mAUMP7/3zASBEYF7P9DwR8CAqMCIyZ9jAoMaTAKAPXENmxcOQjOAAAAAElFTkSuQmCC"
                ));

                return _untracked;
            }

        }

    }

}
#endif
