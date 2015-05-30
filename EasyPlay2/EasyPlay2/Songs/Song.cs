/*
 **********************************************************
 * Autor:       Köchli Oliver
 * Date:        30.05.2015
 * Copyright:   All rights reserved (c) Köchli Oliver
 * Funktion:    Saving MP3-Files for the MP3-Player
 *              EasyPlay
 * Version:     0.1
 **********************************************************
 */

using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ID3TagLib;

namespace EasyPlay2.Songs {
    class Song {
        private static int id = 0;

        private int ID;
        private string Path;
        public string Title { get; set; }
        private int Length;
        private Artist Artist;
        private Album Album;

        public Song(string path, Artist artist, Album album) {
            //Check if Artist or Album are not null
            if (artist != null || album != null) {
                //Save the Filepath
                Path = path;
                //Define SongID
                id++;
                ID = id;
                //Save Artist and Album
                Artist = artist;
                Album = album;
                //Definition for reading ID3Tags
                ID3File tag = new ID3File(Path);
                ID3v2Tag v2Tag = tag.ID3v2Tag;
                //Define Title and save it
                TextFrame f = v2Tag.Frames[FrameFactory.TitleFrameId] as TextFrame;
                if (f != null)
                    Title = f.Text;
                else 
                    Title = System.IO.Path.GetFileName(Path);
            } else {
                //Artist or Album are null: throw Exception
                throw new NullReferenceException("Artist and Album must be filled with objects");
            }
        }
    }
}
