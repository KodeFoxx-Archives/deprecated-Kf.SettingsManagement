using System.Collections.Generic;

namespace Kf.SettingsManagement
{
    /// <summary>
    /// Defines an object that can write settings.
    /// </summary>
    public interface ISettingsWriter
    {
        /// <summary>
        /// Writes the settings.
        /// </summary>
        /// <param name="settings">The settings to write.</param>
        void Write(IEnumerable<Setting> settings);

        /// <summary>
        /// Saves the given setting.
        /// </summary>
        /// <param name="setting">The setting to save.</param>
        void Save(Setting setting);
    }
}
