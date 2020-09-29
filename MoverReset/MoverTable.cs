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

        public void Move(int moverId, int distance)
        {
            _moverList[moverId].Move(distance);
        }

        /// <summary>
        /// Wenn zwischen der aktuellen Position und der Ziel Position kein anderer Mover steht dann kann kann der Mover sich bewegen
        /// </summary>
        /// <param name="moverId"></param>
        /// <returns></returns>
        public bool CanMove(int moverId)
        {
            var result = false;

            var currentPos = _moverList[moverId].CurrentPositionAbsolute;
            var targetPos = _moverList[moverId].TargetPosition;

            var difference = currentPos - targetPos;

            if (difference == 0)
            {
                result = false;
            } 
            else if (difference < 0)
            {
                //Negative difference means forward
                //Check next mover position

                var currentPosNextMover = _moverList[(moverId + 1) % _moverList.Count].CurrentPositionAbsolute;

                if (currentPosNextMover > targetPos)
                {
                    result = true;
                }
            }
            else if(difference > 0)
            {
                //Negative difference means forward
                //Check previous mover position

                var currentPosPreviousMover = _moverList[(moverId - 1)%_moverList.Count].CurrentPositionAbsolute;
                if (currentPosPreviousMover < targetPos)
                {
                    result = true;
                }
            }

            return result;
        }

        public void StorePositions()
        {
            foreach (var mover in _moverList)
            {
                mover.StorePositions();
            }
        }
    }
}
