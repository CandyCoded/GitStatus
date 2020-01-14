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
                    "iVBORw0KGgoAAAANSUhEUgAAAIAAAACACAMAAAD04JH5AAAAbFBMVEUtlUA0mEZgrm6Bv42h0KrC4MfZ7N3k8efv9/D6/PpZq2iVyZ/L5dD///9HoleTyJzf7+JVqWS63MD9/v1UqGM5m0ul0a38/fxvtnzr9e0xl0RGoVfV6dhSp2Hp9Otfrm3x+PP3+/j+/v5gr28AZHVNAAABiklEQVR4Ae3aBXbkQAwE0OpZ9lhmhsH7H2mT3KTzIMxRy6OA/gnqma0SjDHGGGOMMebbc+Bx1+Cv4XSidfyPHvgXryOcRJJm9IwsTbC0vCjpBWWRY0nVL3rVrwpLqZuW3qBtaiyi6+mN+g7yhobeoRkgbJzoXaYRouYNvdNmhqDtjt5tt4WY7Z4Y9mIJ5h2x7GaIGDfEtBkhYJiIbRoQrqEADYJ1FKRDoLqnIH0tewLkT8IKL6ocArkKIX5RsF8IkJOAPOAUOAhwYEsOJKBMwJWSiJR9Chygeg4iEhIxj4CDEKcfgMX9IyH/HDiOJObIOgUXEHPBCuAgxlkAC/A5A8hiBPAQ4y2ABdAPoPw6Xul/kLDEJCRmfhN6CPH6AZgyEpGx/4y88gHQ/zlFQQKKgPmAhwCvP6IJGFKlEQJFqf6YTn9QqT+q1R9W64/r9QsL/cpGv7TSr+30i0v96la/vNav73UXGBRWOOTlxUFziUV/jUd+kcmBxx0u7q1y7c48jDHGGGOMMcawXALKIb4v/YRInAAAAABJRU5ErkJggg=="
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
                    "iVBORw0KGgoAAAANSUhEUgAAAIAAAACAAQMAAAD58POIAAAABlBMVEUtlUD///+cGXloAAAAJ0lEQVR4AWMY2mAUMP7/3zASBEYF7P9DwR8CAqMCIyZ9jAoMaTAKAPXENmxcOQjOAAAAAElFTkSuQmCC"
                ));

                return _untracked;
            }

        }

        private static Texture2D _locked;

        public static Texture2D Locked
        {

            get
            {
                if (_locked != null)
                {

                    return _locked;

                }

                _locked = new Texture2D(SIZE, SIZE);

                _locked.LoadImage(Convert.FromBase64String(
                    "iVBORw0KGgoAAAANSUhEUgAAAIAAAACACAMAAAD04JH5AAAAyVBMVEUtQZU6TJtte7WapMy6wdzZ3Ovq7PT19vr8/P0/UZ6GksLQ1ef9/f7///9BU5+psdP6+/ybpMz29/qAjL7x8vcxRZers9Q/Up7O0+ZSYqfo6vPn6vNAUp7n6fI0R5jS1ui4vtvb3u2cpc1qeLRWZqmPmcb5+fyiq9BIWaKvt9dEVqGrs9X3+Pt3hLpQYaZVZanp6/TCx+BUZKhMXaRserWkrdHj5fDx8/g8T5yMl8V/i749T52mrtLJzuPHzOKHksJjcrDv8PdNXqVWCyDhAAABVUlEQVR4AezS1YFbMQAEwDXjHp+Z8ZljZuy/qHxJZpaCmhoGfy/DMAzDMAzDsNkdTpfb4/W4XU6H3YZfy+cPBLkrGPD78Mu8vL7x2NvrC34J2/sHT/t4t0G/zy+e9/UJzb5DvCz0DZ3CEV4TCUOfaIzXxaPQJZHkLZIJ6JFK8zbpFLTIcF82ly+8fL8U8rks92WgQ5G7SmULW1a5xF1FqJfwcEelin3VCnd4ElCuxq16A8cadW7VoFrTSynWwimtH5S8TSjWpuTp4LSOh1IbanUpBXs4pxek1IVS75T6OK9PyQGlBhSGI5w3GlIYQCWL0hiXjClZUGhCwTvFJVMvhQkUmlGY47I5hRkUWlDw47IlhYWegytcttKzcE1hg8s2FNZQgAr8bHeOBQAAAAAG+VtPY0cRJCAgICAgICAgICAgICAgICAgICAgICAgICAgMA8AAAAQnY7wX9sqolIAAAAASUVORK5CYII="
                ));

                return _locked;
            }

        }

    }

}
#endif
