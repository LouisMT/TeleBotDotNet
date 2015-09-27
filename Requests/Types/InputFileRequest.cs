using TeleBotDotNet.Http;
using TeleBotDotNet.Requests.Types.Bases;

namespace TeleBotDotNet.Requests.Types
{
    public class InputFileRequest : BaseTypeRequest
    {
        private string _contentType;
        private byte[] _file;
        private string _fileExtension;
        private string _fileId;
        public InputFileType InputFileType { get; private set; }

        public string FileId
        {
            get { return _fileId; }
            set
            {
                _fileId = value;
                _fileExtension = null;
                _file = null;
                _contentType = null;

                InputFileType = InputFileType.String;
            }
        }

        public string ContentType
        {
            get { return string.IsNullOrEmpty(_contentType) ? "application/octet-stream" : _contentType; }
            set
            {
                _fileId = null;
                _contentType = value;

                InputFileType = InputFileType.File;
            }
        }

        public string FileExtension
        {
            get { return _fileExtension; }
            set
            {
                _fileId = null;
                _fileExtension = value;

                InputFileType = InputFileType.File;
            }
        }

        public byte[] File
        {
            get { return _file; }
            set
            {
                _fileId = null;
                _file = value;

                InputFileType = InputFileType.File;
            }
        }

        internal override void Parse(HttpData httpData, string key)
        {
            switch (InputFileType)
            {
                case InputFileType.String:
                    httpData.Parameters.Add(key, FileId);
                    break;

                case InputFileType.File:
                    httpData.Files.Add(key, FileExtension, File, ContentType);
                    break;
            }
        }
    }
}