using System;
using System.IO;

namespace Kf.SettingsManagement.Json
{
    public sealed class StreamJsonSettingsWriter : JsonSettingsWriter
    {
        private readonly Func<Stream> _getStreamFunction;

        public StreamJsonSettingsWriter(Func<Stream> getStreamFunction) {
            if (getStreamFunction == null) {
                throw new ArgumentNullException(nameof(getStreamFunction));
            }

            _getStreamFunction = getStreamFunction;
        }

        protected override void SaveJsonString(string jsonString) {
            using (var stream = _getStreamFunction()) {
                using (var streamWriter = new StreamWriter(stream)) {
                    streamWriter.Write(jsonString);
                }
            }
        }
    }
}
