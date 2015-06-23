using System;
using System.Collections.Generic;

namespace Kf.SettingsManagement
{
    /// <summary>
    /// Default implementation of an <see cref="IReadOnlySettingsManager"/>.
    /// </summary>
    public class ReadOnlySettingsManager : IReadOnlySettingsManager
    {
        /// <summary>
        /// Holds a reference to the settings reader used.
        /// </summary>
        private readonly ISettingsReader _settingsReader;

        /// <summary>
        /// Gets hold of the settings.
        /// </summary>        
        protected IDictionary<string, Setting> _settings;

        /// <summary>
        /// Creates a new <see cref="ReadOnlySettingsManager"/>.
        /// </summary>
        /// <param name="settingsReader">The settings reader to use.</param>
        public ReadOnlySettingsManager(ISettingsReader settingsReader) {
            if (settingsReader == null) {
                throw new ArgumentNullException(nameof(settingsReader));
            }

            _settingsReader = settingsReader;
        }

        /// <summary>
        /// Gets a setting by it's key.
        /// </summary>
        /// <param name="key">The setting's key.</param>
        /// <returns>The <see cref="Setting"/>, or null.</returns>
        public virtual Setting GetByKey(string key) {
            if (_settings == null) {
                LoadSettings();
            }

            var formattedKey = FormatKey(key);

            if (!CheckIfKeyExists(formattedKey)) {
                var keyNotFoundMessage = $"The given key '{formattedKey}' is not found.";
                var keyNotFoundException = new SettingsException(keyNotFoundMessage);                
                throw keyNotFoundException;
            } else {
                return _settings[key];
            }
        }

        /// <summary>
        /// Loads the settings.
        /// </summary>
        public virtual IEnumerable<Setting> LoadSettings() {
            try {
                var settings = _settingsReader.Read();
                var settingsDictionary = new Dictionary<string, Setting>();

                foreach (var setting in settings) {
                    var formattedKey = FormatKey(setting.Key);
                    settingsDictionary.Add(formattedKey, setting);
                }

                _settings = settingsDictionary;
                return _settings.Values;
            } catch (Exception ex) {
                string exceptionMessage = $"Exception '{ex.ToFriendlyNameOfType()}' occurred while loading settings.";                                                
                throw new SettingsException(exceptionMessage, ex);
            }
        }

        /// <summary>
        /// Formats the key.
        /// </summary>
        /// <param name="key">The key to format.</param>
        /// <returns>The key formatted.</returns>
        protected virtual string FormatKey(string key) {
            if (String.IsNullOrWhiteSpace(key)) {
                return String.Empty;
            }

            return key
                .Trim()
                .ToLower();
        }

        /// <summary>
        /// Checks whether a given key exists.
        /// </summary>
        /// <param name="key">The key to check.</param>
        /// <returns>True when exists, false when not.</returns>
        protected bool CheckIfKeyExists(string key) {
            return _settings.ContainsKey(key);
        }
    }
}
