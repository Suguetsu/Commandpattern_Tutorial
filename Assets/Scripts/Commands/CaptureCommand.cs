
using UnityEngine;

namespace Sugue //<<<  Rodrigo Sugue
{
    public class CaptureCommand : CommandManager.ICommand2
    {

        private Unit captureUnit;
        private Vector3Int fromCapture;


        public CaptureCommand(Unit captured, Vector3Int fromWhere)
        {
            captureUnit = captured;
            fromCapture = fromWhere;
        }



        public void Undo()
        {

            var unit = captureUnit;

            if (unit != null)
            {
                Gameboard.Instance.MoveUnit(unit, fromCapture);
            }

            Gameboard.Instance.SwitchTeam();
        }

        public void Capture()
        {
            if (captureUnit != null)
            {

                Gameboard.Instance.TakeOutUnit(captureUnit);

            }



        }

    }
}