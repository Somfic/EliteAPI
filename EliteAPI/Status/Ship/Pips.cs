using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace EliteAPI.Status.Ship
{
    public class Pips
    {
        internal Pips(IReadOnlyList<int> pips)
        {
            Systems = pips[0] / 8f;
            Engines = pips[1] / 8f;
            Weapons = pips[2] / 8f;
        }

        /// <summary>
        /// Value from 0-1.
        /// </summary>
        [Range(0f, 1f)]
        public double Systems { get; }

        /// <summary>
        /// Value from 0-1.
        /// </summary>
        [Range(0f, 1f)]
        public double Engines { get; }

        /// <summary>
        /// Value from 0-1.
        /// </summary>
        [Range(0f, 1f)]
        public double Weapons { get; }
    }
}