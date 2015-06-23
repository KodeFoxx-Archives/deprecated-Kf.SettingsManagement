using System;

namespace Kf.SettingsManagement
{
    /// <summary>
    /// Defines a Setting exception.
    /// </summary>
    public class SettingsException : Exception
    {
        /// <summary>
        /// Creates a new <see cref="SettingsException"/>.
        /// </summary>
        /// <param name="message">The message describing the error.</param>
        /// <param name="innerException">The exception that triggered this exception.</param>
        public SettingsException(string message, Exception innerException = null)
            : base(message, innerException) { }
    }
}
