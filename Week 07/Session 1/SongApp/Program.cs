using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SongLib;

namespace SongApp
{
    internal class Program
    {
        struct SongStruct
        {
            public string name;
        }

        static void Main(string[] args)
        {
            // class and interface variables are reference variables which act like pointers
            Song song;
            ISong iSong;
            Object myObject;

            // when creating class objects, we only have as many objects as we have "new" commands
            TapeSong tapeSong = new TapeSong();

            // we have 1 TapeSong object
            tapeSong.artist = "Pharrel Williams";
            tapeSong.Name = "Happy";
            tapeSong.counter = 54;
            tapeSong.side = 1;
            tapeSong.Play();

            // we can use any parent of TapeSong as a handle for it
            // so we can use a Song variable to point to it
            song = tapeSong;

            // we still only have 1 TapeSong object
            // tapeSong and song are pointing to the same object

            // we can use the Song pointer to access any fields, properties or methods defined by the Song class
            // note that we cannot access any fields or methods that are specific to the TapeSong class
            // however calling any overriden methods, WILL call the overriden implementation in the child class
            string artist = song.artist;
            //song.tapeName = "";
            song.Play();

            // I added nCopies to the Song class without saving or recompiling SongLib.dll, yet the code change is immediately available
            song.nCopies = 50;

            // create a TapeSong reference variable
            TapeSong pTapeSong;

            // point it at tapeSong
            // now we have 3 variables pointing at the same TapeSong object: tapeSong, song and pTapeSong
            pTapeSong = tapeSong;

            // because tapeSong inherits from the ISong interface we can set the iSong variable to point to tapeSong and use it to access anything defined in the interface
            // iSong can point to pTapeSong which is pointing to tapeSong
            // therefore iSong is pointing to tapeSong
            iSong = pTapeSong;

            // this line changes tapeSong.Name
            iSong.Name = "Sad";

            // and we can use iSong to Play() the song
            iSong.Play();


            // structures can be created without the new operator
            // and they are value variables
            SongStruct mySong;
            mySong.name = "Happy";

            SongStruct anotherSongStruct;
            anotherSongStruct = mySong;

            // I now have 2 SongStruct variables which are independent of each other
            // changing one will not effect the other
            anotherSongStruct.name = "Sad";

            List<Song> songList = new List<Song>();

            VinylSong vinylSong = new VinylSong();
            vinylSong.Name = "Suite Judy Blue Eyes";

            songList.Add(tapeSong);
            songList.Add(vinylSong);

            songList.Sort();

            Func<Song, string> sortMethod;

            string sortBy = "name";

            if(sortBy == "name" )
            {
                // set the delegate variable dynamically to be used later
                sortMethod = SortByName;

                // or sort based simply using the method directly
                songList = songList.OrderBy(SortByName).ToList();
            }
            else
            {
                // set the delegate variable dynamically to be used later
                sortMethod = SortByArtist;

                // or sort based simply using the method directly
                songList = songList.OrderBy(SortByArtist).ToList();
            }

            // use the delegate method variable
            songList = songList.OrderBy(sortMethod).ToList();

            songList = songList.OrderBy(delegate (Song s) { return s.artist; }).ToList();
            songList = songList.OrderBy((Song s) => { return s.artist; }).ToList();
            songList = songList.OrderBy((s) => { return s.artist; }).ToList();
            songList = songList.OrderBy((s) => s.artist).ToList();
            songList = songList.OrderBy(s => s.artist).ToList();

            List<Song> newList = songList.GetRange(0, songList.Count);

            List<Song> pSongList;
            pSongList = songList;
        }

        static string SortByName(Song s)
        {
            return s.Name;
        }

        static string SortByArtist(Song s)
        {
            return s.artist;
        }


    }
}
