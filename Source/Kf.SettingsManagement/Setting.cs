namespace Kf.SettingsManagement
{
    /// <summary>
    /// Defines a setting.
    /// </summary>
    public class Setting
    {
        /// <summary>
        /// Gets the setting's key.
        /// </summary>
        public string Key { get; set; }

        /// <summary>
        /// Gets/sets the setting's type.
        /// </summary>
        public ValueType Type { get; set; }

        /// <summary>
        /// Gets/sets the setting's value as a string.
        /// </summary>
        public string Value { get; set; }

        /// <summary>
        /// Creates a new <see cref="Setting"/>.
        /// </summary>
        public Setting() {
        }

        /// <summary>
        /// String representation this object.
        /// </summary>        
        public override string ToString() {
            return this.ToDebugString();
        }
    }
}
