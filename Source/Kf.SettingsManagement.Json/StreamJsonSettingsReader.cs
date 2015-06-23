using System;
using System.IO;

namespace Kf.SettingsManagement.Json
{
    public sealed class StreamJsonSettingsReader : JsonSettingsReader
    {
        private readonly Func<Stream> _getStreamFunction;

        public StreamJsonSettingsReader(Func<Stream> getStreamFunction) {
            if(getStreamFunction == null) {
                throw new ArgumentNullException(nameof(getStreamFunction));
            }

            _getStreamFunction = getStreamFunction;
        }

        protected override string LoadJsonString() {
            using (var stream = _getStreamFunction()) {
                using (var streamReader = new StreamReader(stream)) {
                    return streamReader.ReadToEnd();
                }
            }
        }
    }
}
