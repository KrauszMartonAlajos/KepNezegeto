﻿using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _2024_02_24_Kepnezegeto
{
    class Photos : ObservableCollection<FileInfo>
    //class Photos : Collection<FileInfo>
    {
        public Photos(List<FileInfo> files) : base(files)
        { 
        
        }
    }
}
