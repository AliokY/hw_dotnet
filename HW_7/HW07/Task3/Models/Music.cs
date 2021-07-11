
using System;

namespace Task3
{
    class Music : Movies
    {
        public string singer {get; set;}

        public DateTime songDuration { get; set; }
        
        public Music(string name, FileType fileType, double fileSize, string singer, DateTime songDuration) :
            base(name, fileType, fileSize)
        {
            this.songDuration = songDuration;
            this.singer = singer;
        }
    }
}
