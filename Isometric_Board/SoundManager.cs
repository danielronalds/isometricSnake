using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Media;

namespace isometricSnake
{
    class SoundManager
    {
        SoundPlayer apple = new SoundPlayer(Properties.Resources.Pickup_Apple);

        public void Pickup_Apple()
        {
            apple.Play();
        }
    }
}
