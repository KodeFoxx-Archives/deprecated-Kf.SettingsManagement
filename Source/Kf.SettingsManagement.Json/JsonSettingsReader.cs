using System.Collections.Generic;
using Newtonsoft.Json;

namespace Kf.SettingsManagement.Json
{
    /// <summary>
    /// Json based <see cref="ISettingsReader"/>.
    /// </summary>
    public abstract class JsonSettingsReader : ISettingsReader
    {        
        /// <summary>
        /// Reads the settings.
        /// </summary>
        /// <returns>An enumerable of <see cref="Setting"/>.</returns>
        public IEnumerable<Setting> Read() {
            var jsonString = LoadJsonString();
            var settings = JsonConvert.DeserializeObject<IEnumerable<Setting>>(jsonString);
            return settings;
        }

        /// <summary>
        /// Loads the json string.
        /// </summary>        
        protected abstract string LoadJsonString();        
    }
}
