using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MoverReset
{
    public class MoverTable
    {
        List<Mover> _moverList;
        public static int TrackLength;

        public MoverTable(int numberMovers, int trackLength)
        {
            TrackLength = trackLength;
            _moverList = new List<Mover>(numberMovers);

            for (int i = 0; i < numberMovers; i++)
            {
                var mover = new Mover(i);
                _moverList.Add(mover);
            }
        }

        public List<Mover> MoverList
        {
            get { return _moverList; }
        }
    }
}
