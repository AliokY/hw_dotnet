using System;

namespace Task3
{
    class Programs : EnyFile
    {
        private string _name;
        public override string name
        {
            get
            {
                return _name;
            }
            set
            {
                _name = value;
            }
        }

        private double _fileSize;
        public override double fileSize
        {
            get
            {
                return _fileSize;
            }
            set
            {
                _fileSize = value;
            }
        }

        private Guid _id;
        public override Guid id
        {
            get
            {
                return _id;
            }
            set
            {
                _id = value;
            }
        }

        private FileType _fileType;
        public override FileType fileType
        {
            get
            {
                return _fileType;
            }
            set
            {
                _fileType = value;
            }
        }
        public Programs(string name, FileType fileType, double fileSize) :
            base(name, fileType, fileSize)
        { }
    }
}
