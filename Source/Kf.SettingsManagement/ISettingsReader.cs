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

        /// <summary>
        /// Gets a setting by it's key.
        /// </summary>
        /// <param name="key">The setting's key.</param>
        /// <returns>The <see cref="Setting"/>, or null.</returns>
        Setting GetByKey(string key);
    }
}
