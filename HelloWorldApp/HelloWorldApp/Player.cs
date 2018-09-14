/*
 * Created by SharpDevelop.
 * User: m543015
 * Date: 9/14/2018
 * Time: 2:31 PM
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */
using System;

namespace HelloWorldApp
{
	/// <summary>
	/// Description of Player.
	/// </summary>
	public sealed class Player
	{
		public int x {get; set;}
		public int y {get; set;}
		
		private static Player instance = new Player();
		
		public static Player Instance {
			get {
				return instance;
			}
		}
		
		private Player()
		{
			x = 1;
			y = 1;
		}
	}
}
