using System;

namespace Kf.SettingsManagement.Json
{
    public sealed class LambdaJsonSettingsReader : JsonSettingsReader
    {
        private readonly Func<string> _stringLoaderFunction;

        public LambdaJsonSettingsReader(Func<string> stringLoaderFunction) {
            if(_stringLoaderFunction == null) {
                throw new ArgumentNullException(nameof(stringLoaderFunction));
            }

            _stringLoaderFunction = stringLoaderFunction;
        }

        protected override string LoadJsonString() {
            return _stringLoaderFunction();
        }
    }
}
