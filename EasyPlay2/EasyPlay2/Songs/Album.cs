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
        private static int id;

        private int ID;
        public int Name { get; set; }
        private Artist Artist;
    }
}
