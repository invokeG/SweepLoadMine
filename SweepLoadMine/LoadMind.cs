using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SweepLoadMine
{
    class LoadMind
    {
       
        int x;
        int y;
        /// <summary>
        ///是否有雷 false没有 true 有雷
        /// </summary>
        bool ismind=false;
        /// <summary>
        /// 插旗子  false 有  true 没有
        /// </summary>
        bool isflag = false;
        int count;
        bool mind;
        /// <summary>
        /// 是否点击过雷数量
        /// </summary>
        bool iskey;
    
        public int X { get => x; set => x = value; }
        public int Y { get => y; set => y = value; }
        public bool Ismind { get => ismind; set => ismind = value; }
        public bool Isflag { get => isflag; set => isflag = value; }
        public int Count { get => count; set => count = value; }
        public bool Mind { get => mind; set => mind = value; }
        //判断是否点击过
        public bool Iskey { get => iskey; set => iskey = value; }
        
    }
}
