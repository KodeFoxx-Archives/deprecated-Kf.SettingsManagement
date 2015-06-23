using System;

namespace Kf.SettingsManagement
{
    /// <summary>
    /// Defines a Setting exception.
    /// </summary>
    public class SettingsManagementException : Exception
    {
        /// <summary>
        /// Creates a new <see cref="SettingsManagementException"/>.
        /// </summary>
        /// <param name="message">The message describing the error.</param>
        /// <param name="innerException">The exception that triggered this exception.</param>
        public SettingsManagementException(string message, Exception innerException = null)
            : base(message, innerException) { }
    }
}
