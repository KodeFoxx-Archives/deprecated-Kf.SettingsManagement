using System.Collections.Generic;
using Newtonsoft.Json;

namespace Kf.SettingsManagement.Json
{
    /// <summary>
    /// Json based <see cref="ISettingsWriter"/>.
    /// </summary>
    public abstract class JsonSettingsWriter : ISettingsWriter
    {
        /// <summary>
        /// Writes the settings.
        /// </summary>
        /// <param name="settings">The settings to write.</param>
        public void Write(IEnumerable<Setting> settings) {
            var jsonString = JsonConvert.SerializeObject(settings, Formatting.None);
            SaveJsonString(jsonString);
        }

        /// <summary>
        /// Saves the json string.
        /// </summary>        
        protected abstract void SaveJsonString(string jsonString);
    }
}
