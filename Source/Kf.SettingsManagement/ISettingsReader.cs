using System.Collections.Generic;

namespace Kf.SettingsManagement
{
    /// <summary>
    /// Defines an object that can read settings.
    /// </summary>
    public interface ISettingsReader
    {
        /// <summary>
        /// Reads the settings.
        /// </summary>
        /// <returns>An enumerable of <see cref="Setting"/>.</returns>
        IEnumerable<Setting> Read();
    }
}
