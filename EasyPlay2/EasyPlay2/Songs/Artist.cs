/*
 **********************************************************
 * Autor:       Köchli Oliver
 * Date:        30.05.2015
 * Copyright:   All rights reserved (c) Köchli Oliver
 * Funktion:    Saving the all Artits for EasyPlay
 * Version:     0.1
 **********************************************************
 */

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EasyPlay2.Songs {
    class Artist {
        #region static
        private static int id;
        #endregion endstatic

        #region member
        private int ID;
        public string Name { get; set; }
        #endregion member

        #region constructor
        public Artist(string name) {
            //check if name has content
            if (!String.IsNullOrWhiteSpace(name)) {
                Name = name;
                id++;
                ID = id;
            } else
                throw new NullReferenceException("Name must have a content");
        }
        #endregion constructor

        #region methods
        public int getID() {
            return ID;
        }
        #endregion methods
    }
}
