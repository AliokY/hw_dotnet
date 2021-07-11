using System;

namespace Task3
{
    class Program
    {
        static void Main(string[] args)
        {
            Movies movie1 = new("The Shawshank Redemption", EnyFile.FileType.Movie,
                2.2, "Liz Glotzer", "Tim Robbins", "absent");
            Movies movie2 = new("Interstellar", EnyFile.FileType.Movie,
               3.5, "Christopher Nolan", "Matthew McConaughey", "Anne Hathaway");
            Movies movie3 = new("Intouchables", EnyFile.FileType.Movie,
               3.1, "Nicolas Duval Adassovsky", "François Cluzet", "Anne Le Ny");

            Movies[] movies = new Movies[3] { movie1, movie2, movie3 };

            Music song1 = new("Nothing Else Matters",  EnyFile.FileType.Music, 0.02, "Metallica", DateTime.Parse("6:25"));
            Music song2 = new("Stairway to Heaven Live", EnyFile.FileType.Music, 0.04, "Led Zeppelin", DateTime.Parse("10:39"));
            Music song3 = new("Another Brick In The Walld", EnyFile.FileType.Music, 0.015, "Pink Floyd", DateTime.Parse("6:00"));

            Music[] music = new Music[3] { song1, song2, song3 };

            Programs program1 = new("Visual Studio 2019", EnyFile.FileType.Program, 2.55);
            Programs program2 = new("Slack", EnyFile.FileType.Program, 0.29);
            Programs program3 = new("Evernote", EnyFile.FileType.Program, 0.49);

            Programs[] programs = new Programs[3] { program1, program2, program3 };
        }
    }
}
