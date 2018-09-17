using RLNET;
using System;
 
namespace Roguelike
{
  public class Game
  {
  	private static readonly int WIDTH = 25;
  	private static readonly int HEIGHT = 25;
  	private static int[,] grid = new int[25,25];
  	
    // The screen height and width are in number of tiles
    private static RLRootConsole rlRoot;
    private static bool _renderRequired = true;
    
    public static void Main()
    {
    	for (int i=0; i<WIDTH; i++) {
    		for (int j=0; j<HEIGHT; j++) {
    			if (i==0 || j==0 || i==WIDTH-1 || j==HEIGHT-1) {
    				grid[i,j] = 1;
    			} else {
    				grid[i,j] = 0;
    			}
    		}
    	}
    	
    	_renderRequired = true;
      // This must be the exact name of the bitmap font file we are using or it will error.
      string fontFileName = "terminal8x8.png";
      // The title will appear at the top of the console window
      string consoleTitle = "roguelike";
      // Tell RLNet to use the bitmap font that we specified and that each tile is 8 x 8 pixels
      rlRoot = new RLRootConsole(fontFileName, WIDTH, HEIGHT, 8, 8, 1f, consoleTitle);
      // Set up a handler for RLNET's Update event
      rlRoot.Update += OnRootConsoleUpdate;
      // Set up a handler for RLNET's Render event
      rlRoot.Render += OnRootConsoleRender;
      // Begin RLNET's game loop
      rlRoot.Run();
    }
 
    // Event handler for RLNET's Update event
    private static void OnRootConsoleUpdate( object sender, UpdateEventArgs e )
    {
    	RLKeyPress keyPress = rlRoot.Keyboard.GetKeyPress();
    	bool didPlayerAct = false;
		if ( keyPress != null )
		  {
		    if ( keyPress.Key == RLKey.Up )
		    {
		    	Player.Instance.y = Math.Max(1, Player.Instance.y-1);
		    	didPlayerAct = true;
		    }
		    else if ( keyPress.Key == RLKey.Down )
		    {
		    	Player.Instance.y = Math.Min(HEIGHT-2, Player.Instance.y+1);
		    	didPlayerAct = true;
		    }
		    else if ( keyPress.Key == RLKey.Left )
		    {
		    	Player.Instance.x = Math.Max(1, Player.Instance.x-1);
		    	didPlayerAct = true;
		    }
		    else if ( keyPress.Key == RLKey.Right )
		    {
		    	Player.Instance.x = Math.Min(WIDTH-2, Player.Instance.x+1);
		    	didPlayerAct = true;
		    }
		  }
		 
		  if (didPlayerAct)
		  {
		    _renderRequired = true;
 		 }
    	for (int i=0; i<WIDTH; i++) {
    		for (int j=0; j<HEIGHT; j++) {
    			if (Player.Instance.x==i && Player.Instance.y==j) {
    				rlRoot.Print(i, j, "@", RLColor.White);
    			} else if (grid[i,j]==0) {
    				rlRoot.Print(i, j, ".", RLColor.White);
    			} else {
    				rlRoot.Print(i, j, "#", RLColor.White);
    			}
    		}
    	}
    }
 
    // Event handler for RLNET's Render event
    private static void OnRootConsoleRender( object sender, UpdateEventArgs e )
    {
      // Tell RLNET to draw the console that we set
//      if ( _renderRequired ) {
      	rlRoot.Draw();
//      	_renderRequired = false;
//      }
    }
  }
}