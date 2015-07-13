using TeleBotDotNet.Http;
using TeleBotDotNet.Requests.Types.Bases;

namespace TeleBotDotNet.Requests.Types
{
    public class InputFileRequest : BaseTypeRequest
    {
        public enum InputFileTypes
        {
            String,
            File
        }

        private string _contentType;
        private byte[] _file;
        private string _fileExtension;
        private string _fileId;
        public InputFileTypes InputFileType { get; private set; }

        public string FileId
        {
            get { return _fileId; }
            set
            {
                _fileId = value;
                _fileExtension = null;
                _file = null;
                _contentType = null;

                InputFileType = InputFileTypes.String;
            }
        }

        public string ContentType
        {
            get { return string.IsNullOrEmpty(_contentType) ? "application/octet-stream" : _contentType; }
            set
            {
                _fileId = null;
                _contentType = value;

                InputFileType = InputFileTypes.File;
            }
        }

        public string FileExtension
        {
            get { return _fileExtension; }
            set
            {
                _fileId = null;
                _fileExtension = value;

                InputFileType = InputFileTypes.File;
            }
        }

        public byte[] File
        {
            get { return _file; }
            set
            {
                _fileId = null;
                _file = value;

                InputFileType = InputFileTypes.File;
            }
        }

        internal override void Parse(HttpData httpData, string key)
        {
            switch (InputFileType)
            {
                case InputFileTypes.String:
                    httpData.Parameters.Add(key, FileId);
                    break;

                case InputFileTypes.File:
                    httpData.Files.Add(key, FileExtension, File, ContentType);
                    break;
            }
        }
    }
}