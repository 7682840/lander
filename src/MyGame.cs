using System;
using SwinGameSDK;

namespace lander
{
    public class MyGame
    {
        public static void Main()
        {
            //Open the game window
            SwinGame.OpenGraphicsWindow("GameMain", 1600, 900);
            SwinGame.ShowSwinGameSplashScreen();

            Lander l = new Lander((SwinGame.ScreenWidth() / 2) - (30 / 2), 10); // 30 is lander bitmap width hardcoded

            //Run the game loop
            while(false == SwinGame.WindowCloseRequested())
            {
                //Fetch the next batch of UI interaction
                SwinGame.ProcessEvents();
                
                //Clear the screen and draw the framerate
                SwinGame.ClearScreen(Color.White);
                SwinGame.DrawFramerate(0,0);

                l.CalculatePosition(); // Move the lander
                l.DrawLander(); // Draw the lander

                //Draw onto the screen
                SwinGame.RefreshScreen(60);
            }
            SwinGame.ReleaseAllResources();
            SwinGame.ReleaseAllSprites();
        }
    }
}