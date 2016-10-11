using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SwinGameSDK;
using System.Diagnostics;

namespace lander
{
    /// <summary>
    /// This lander class is responsible for all aspects of the lander such as its movement and behaviour.
    /// </summary>
    class Lander
    {
        Sprite _lander = SwinGame.CreateSprite(SwinGame.LoadBitmapNamed("lander", "Resources/images/lander.png"));

        public Lander(int x, int y)
        {
            _lander.X = x;
            _lander.Y = y;
        }

        /// <summary>
        /// Draw the lander on the screen.
        /// </summary>
        /// <param name="x">Set X position for lander to be drawn.</param>
        /// <param name="y">Set Y position for lander to be drawn.</param>
        public void DrawLander(int x, int y)
        {
            SwinGame.SpriteSetX(_lander, x);
            SwinGame.SpriteSetY(_lander, y);

            SwinGame.UpdateSprite(_lander);
            SwinGame.DrawSprite(_lander);
        }

        /// <summary>
        /// Draw the lander on the screen.
        /// </summary>
        public void DrawLander()
        {
            SwinGame.UpdateSprite(_lander);
            SwinGame.DrawSprite(_lander);
        }

        /// <summary>
        /// Read input from user and update lander position accordingly.
        /// </summary>
        public void CalculatePosition()
        {
            Vector thrustVector = new Vector();
            Vector gravityVector = new Vector();
            thrustVector.Y = (float)-0.1;
            gravityVector.Y = (float)0.05;

            if (SwinGame.KeyDown(KeyCode.vk_LEFT))
            {
                thrustVector.X = -1;
                _lander.AddToVelocity(thrustVector);
                _lander.Rotation = thrustVector.X;
            }
            else if (SwinGame.KeyDown(KeyCode.vk_RIGHT))
            {
                thrustVector.X = 1;
                _lander.AddToVelocity(thrustVector);
                _lander.Rotation = thrustVector.X;
            }

            else if (SwinGame.KeyDown(KeyCode.vk_UP))
            {
                _lander.AddToVelocity(thrustVector);
                SwinGame.MoveSprite(_lander);

            }
            _lander.AddToVelocity(gravityVector);
        }
    }
}
