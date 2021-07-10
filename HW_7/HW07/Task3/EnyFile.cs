using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task3
{
    abstract class EnyFile
    {
        public abstract string name { get; set; }

        public abstract Guid id { get; set; }

        public abstract FileType fileType { get; set; }

        public abstract int fileSize { get; set; }

        public EnyFile(string name, FileType fileType, int fileSize)
        {
            id = Guid.NewGuid();

            this.name = name;
            this.fileType =fileType;
            this.fileSize = fileSize;
        }

        public enum FileType
        {
            Music = 1,
            Movie,
            Program
        }
    }
}
