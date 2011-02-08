using System;

namespace Radar.Utilities
{
    internal static class Tracking
    {
        /// <summary>
        /// Gets if a string matches a wildcard pattern.
        /// </summary>
        /// <param name="check">String to check against a patternd.</param>
        /// <param name="pattern">Pattern containing wildcards.</param>
        /// <returns><c>TRUE</c> if check patches the supplied pattern.</returns>
        public static bool WildCardMatches(string check, string pattern)
        {
            // Do not waste our time with empties.
            if (String.IsNullOrEmpty(pattern))
            {
                throw new ArgumentNullException("pattern");
            }

            if (String.IsNullOrEmpty(check))
            {
                return false;
            }

            // Equalize capitalization.
            check = check.ToUpperInvariant();
            pattern = pattern.ToUpperInvariant();

            // Indexes for each string.
            var patternIx = 0;

            var lastWild = -1;// Index of the last wild card in pattern

            foreach (var cChar in check)
            {
                // If we've reached the end of the pattern but not the end of the end of the
                // string being checked, then the pattern does not match.
                if (!(patternIx < pattern.Length))
                {
                    return false;
                }

                var pChar = pattern[patternIx]; // Current character of the pattern.

                // Set the last lastWild index and get the first non-wild character in the pattern.
                while (pChar == '*' && patternIx < pattern.Length - 1)
                {
                    lastWild = patternIx;
                    pChar = pattern[++patternIx];
                }

                if (pChar == '*') return true; // We've reached the end of the pattern and it's a wildcard.

                // If our current pattern character is not a single-wild (?) or match our current check
                // character, go back to the index of the last wild.
                if (pChar != cChar && pChar != '?')
                {
                    patternIx = lastWild;
                }

                patternIx++;
            }

            return patternIx == pattern.Length;
        }
    }
}
