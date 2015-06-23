namespace Kf.SettingsManagement
{
    /// <summary>
    /// Settings manager that read and write.
    /// </summary>
    public interface IReadWriteSettingsManager : IReadOnlySettingsManager
    {
        /// <summary>
        /// Saves the given setting.
        /// </summary>
        /// <param name="setting">The setting to save.</param>
        void Save(Setting setting);
    }
}
