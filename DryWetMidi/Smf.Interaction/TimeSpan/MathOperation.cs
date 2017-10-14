﻿namespace Melanchall.DryWetMidi.Smf.Interaction
{
    /// <summary>
    /// Represents a simple math operation used by the <see cref="MathTime"/> and the <see cref="MathLength"/>.
    /// The default is <see cref="Add"/>.
    /// </summary>
    public enum MathOperation
    {
        /// <summary>
        /// Addition.
        /// </summary>
        Add = 0,

        /// <summary>
        /// Subtraction.
        /// </summary>
        Subtract
    }
}