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
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ID3TagLib;

namespace EasyPlay2.Songs {
    class Song {
        //Definition
        #region static
        private static int id = 0;
        #endregion static

        #region member
        private int ID;
        private string Path;
        public string Title { get; set; }
        private string Length;
        private Artist Artist;
        private Album Album;
        private int NumPlayed;
        public bool Playing { get; set; }
        #endregion member

        #region constructor
        public Song(string path, Artist artist, Album album) {
            //Check if Artist and Album are not null
            if (artist != null && album != null && !String.IsNullOrWhiteSpace(path)) {
                //Save the Filepath
                Path = path;
                //Define SongID
                id++;
                ID = id;
                NumPlayed = 0;
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
                //Length definition
                System.Windows.Media.MediaPlayer player = new System.Windows.Media.MediaPlayer();
                player.Open(new Uri(Path));
                while (!player.NaturalDuration.HasTimeSpan) {

                }
                System.Windows.Duration d = player.NaturalDuration;
                string Splittit = d.ToString();
                string[] splitD = Splittit.Split(new char[] { ':', '.' });
                int h = Convert.ToInt16(splitD[0]);
                int min = Convert.ToInt16(splitD[1]);
                int sec = Convert.ToInt16(splitD[2]);
                Length = h + ":" + min + ":" + sec;
            } else {
                //Artist or Album are null: throw Exception
                throw new NullReferenceException("Artist and Album must be filled with objects");
            }
        }
        #endregion constructor

        //Methods
        #region getMethods
        public int getID() {
            return ID;
        }

        public string getPath() {
            return Path;
        }

        public string getLength() {
            return Length;
        }

        public Artist getArtist() {
            return Artist;
        }

        public Album getAlbum() {
            return Album;
        }

        public int getNumPlayed() {
            return NumPlayed;
        }

        public void addNumPlayed() {
            NumPlayed++;
        }
        #endregion getMethods
    }
}
