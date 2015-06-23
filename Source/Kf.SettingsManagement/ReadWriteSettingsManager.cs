using System;

namespace Kf.SettingsManagement
{
    public class ReadWriteSettingsManager : ReadOnlySettingsManager, IReadWriteSettingsManager
    {
        /// <summary>
        /// Holds a reference to the settings writer used.
        /// </summary>
        private readonly ISettingsWriter _settingsWriter;

        /// <summary>
        /// Creates a new <see cref="SettingsReadWriteManager"/>.
        /// </summary>
        /// <param name="settingsReader">The settings reader to use.</param>
        /// <param name="settingsWriter">The settings writer to use.</param>
        public ReadWriteSettingsManager(ISettingsReader settingsReader, ISettingsWriter settingsWriter)
            : base(settingsReader)
        {
            if (settingsWriter == null) {
                throw new ArgumentNullException(nameof(settingsWriter));
            }

            _settingsWriter = settingsWriter;
        }

        /// <summary>
        /// Saves the given setting.
        /// </summary>
        /// <param name="setting">The setting to save.</param>
        public void Save(Setting setting) {
            var formattedKey = FormatKey(setting.Key);

            if (!CheckIfKeyExists(formattedKey)) {
                _settings.Add(formattedKey, setting);
            } else {
                _settings[formattedKey] = setting;
            }

            SaveSettings();
        }

        /// <summary>
        /// Saves the settings.
        /// </summary>
        protected virtual void SaveSettings() {
            try {
                _settingsWriter.Write(_settings.Values);
            } catch (Exception ex) {
                string exceptionMessage = $"Exception '{ex.ToFriendlyNameOfType()}' occurred while saving settings.";                                
                throw new SettingsException(exceptionMessage, ex);
            }
        }
    }
}
