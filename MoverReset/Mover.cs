using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MoverReset
{
    public class Mover
    {
        private int _id;
        private int _targetPosition;
        private int _currentPositionAbsolute;

        public Mover(int id)
        {
            _id = id;
            _targetPosition = id;
            _currentPositionAbsolute = id;
        }


        public int Id
        {
            get { return _id; }
        }

        public int CurrentPosition
        {
            get { return _currentPositionAbsolute%MoverTable.TrackLength; }
        }

        public int CurrentPositionAbsolute
        {
            get { return _currentPositionAbsolute; }
        }

        public int TargetPosition
        {
            get { return _targetPosition; }
            set { _targetPosition = value; }
        }

        public void Move(int distance)
        {
            _currentPositionAbsolute += distance;
        }

        public void StorePositions()
        {
            _targetPosition = _currentPositionAbsolute;
        }
    }
}
