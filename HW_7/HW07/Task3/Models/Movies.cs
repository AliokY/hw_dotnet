using System;

namespace Task3
{
    class Movies : EnyFile
    {
        public string producer { get; set; }
        public string mainActor { get; set; }
        public string mainActress { get; set; }

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

        public Movies(string name, FileType fileType, double fileSize, string producer, string mainActor, string mainActress) :
            base(name, fileType, fileSize)
        {
            this.producer = producer;
            this.mainActor = mainActor;
            this.mainActor = mainActress;

        }

        public Movies(string name, FileType fileType, double fileSize) :
            base(name, fileType, fileSize) {}

        private protected void Play(Movies newMovie)
        {
            Console.WriteLine($"Watching a movie {newMovie.name}");
            Console.ReadKey();
        }

        private protected void RetriveInformation(Movies newMovie)
        {
            Console.WriteLine($"Find information about {newMovie.name}");
        }
    }
}
