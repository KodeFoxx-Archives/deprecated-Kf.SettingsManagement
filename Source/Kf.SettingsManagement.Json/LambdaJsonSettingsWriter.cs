using System;

namespace Kf.SettingsManagement.Json
{
    public sealed class LambdaJsonSettingsWriter : JsonSettingsWriter
    {
        private readonly Action<string> _stringSaverFunction;

        public LambdaJsonSettingsWriter(Action<string> stringSaverFunction) {
            if (_stringSaverFunction == null) {
                throw new ArgumentNullException(nameof(stringSaverFunction));
            }

            _stringSaverFunction = stringSaverFunction;
        }

        protected override void SaveJsonString(string jsonString) {
            _stringSaverFunction(jsonString);
        }
    }
}
