/*
 **********************************************************
 * Autor:       Köchli Oliver
 * Date:        30.05.2015
 * Copyright:   All rights reserved (c) Köchli Oliver
 * Funktion:    Saving the all Albums for EasyPlay
 * Version:     0.1
 **********************************************************
 */

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EasyPlay2.Songs {
    class Album {
        #region static
        private static int id;
        #endregion static

        #region member
        private int ID;
        public string Name { get; set; }
        private Artist Artist;
        #endregion member

        #region constructor
        public Album(string name, Artist artist) {
            //Check if name has content and artist isn't null
            if (!String.IsNullOrWhiteSpace(name) && artist != null) {
                Name = name;
                Artist = artist;
                id++;
                ID = id;
            } else
                throw new NullReferenceException("Artist and Name must have a content");
        }
        #endregion constructor

        #region methods
        public int getID() {
            return ID;
        }

        public Artist getArtist() {
            return Artist;
        }
        #endregion methods
    }
}
