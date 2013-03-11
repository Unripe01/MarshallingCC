using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Runtime.InteropServices;

///召喚士クラス　クリーチャーを呼び出すとか厨２的な発想でコーディング中
namespace Summoner
{
	/// <summary>
	/// サモナー
	/// </summary>
	class Summoner
	{
		//Stopwatch
		static System.Diagnostics.Stopwatch sw = new System.Diagnostics.Stopwatch();

		static void Main( string[] args )
		{
			Console.WriteLine("～～戦いの記録的な何か～～");
			Console.WriteLine( "" );
			Console.WriteLine( "召喚士です" );

			//レッドゴブリン
			CastRedGoblin();

			//ブルーゴブリン
			CastBlueGoblin();

			//ゴーレム
			CastGolem();

			//ドラゴン
			CastDragon(true);

			//ドラゴン（高速詠唱）
			Console.WriteLine( "高速詠唱" );
			FastCastDragon( true );

			const int count = 100000;
			//ドラゴン10000体の召喚
			Console.WriteLine( "ドラゴン10000体の召喚" );
			sw.Start();
			for( int i = 0; i < count; i++ )
			{
				//ドラゴン
				CastDragon( false );
			}
			sw.Stop();
			Console.WriteLine( string.Format( "詠唱時間：{0}", ( (decimal)sw.Elapsed.TotalSeconds ).ToString() ) );

			//ドラゴン10000体の召喚（ポインタ版）
			Console.WriteLine( "" );
			Console.WriteLine( "ドラゴン10000体の高速召喚" );
			sw.Restart();
			for( int i = 0; i < count; i++ )
			{
				//Dragon
				FastCastDragon( false );
			}
			sw.Stop();
			Console.WriteLine( string.Format( "詠唱時間：{0}", ( (decimal)sw.Elapsed.TotalSeconds ).ToString() ) );
			Console.WriteLine( "" );
			Console.ReadLine();
		}

		/// <summary>
		/// Dragon
		/// </summary>
		private static unsafe void FastCastDragon( bool consoleWeite )
		{
			StringBuilder csb = new StringBuilder( 1024 );
			MagicCast.StatusUnsafe[] cerberusHeads = new MagicCast.StatusUnsafe[7];
			fixed( MagicCast.StatusUnsafe* ptr = cerberusHeads )
			{
				MagicCast.DragonUnsafe( csb, ptr );
			}

			if( consoleWeite == false )
			{
				return;
			}

			Console.WriteLine( csb.ToString() + "を召喚した！" );
			for( int idx = 0; idx < 7; idx++ )
			{
				byte[] btemp =  new byte[7];
				fixed( byte* plb = cerberusHeads[idx].Weakness ) {
					Marshal.Copy( (IntPtr)plb, btemp, 0, 7 );
				}
				string sWeakness = "";
				foreach ( byte b in btemp )
				{
					sWeakness += b.ToString();
				}
				if( consoleWeite )
				{
					Console.WriteLine(
		string.Format( @"-------{1}{0}のステータス-----
Hp:{2}
Power:{3}
Sex:{4}
Weakness:{5}
"
		, idx+1
		, csb.ToString()
		 , cerberusHeads[idx].Hp.ToString()
		 , cerberusHeads[idx].Power.ToString()
		 , cerberusHeads[idx].Sex.ToString()
		 , sWeakness
		 ) );
				}
			}
		}

		/// <summary>
		/// Dragon
		/// </summary>
		private static void CastDragon( bool consoleWeite )
		{
			StringBuilder csb = new StringBuilder( 1024 );
			MagicCast.CerberusHeads cerberusHeads;
			MagicCast.Dragon( csb, out cerberusHeads );

			if( consoleWeite == false )
			{
				return;
			}

			Console.WriteLine( csb.ToString() + "を召喚した！" );
			for( int idx = 0; idx < 7; idx++ )
			{
				string sWeakness = "";
				foreach( byte b in cerberusHeads.head[idx].Weakness )
				{
					sWeakness += b.ToString();
				}
					Console.WriteLine(
		string.Format( @"-------{1}{0}のステータス-----
Hp:{2}
Power:{3}
Sex:{4}
Weakness:{5}
"
		, idx+1
		, csb.ToString()
		 , cerberusHeads.head[idx].Hp.ToString()
		 , cerberusHeads.head[idx].Power.ToString()
		 , cerberusHeads.head[idx].Sex.ToString()
		 , sWeakness
		 ) );
				}
		}

		/// <summary>
		/// ゴーレム
		/// </summary>
		private static void CastGolem()
		{
			StringBuilder gsb = new StringBuilder( 1024 );
			MagicCast.Status golemStatus;
			MagicCast.Golem( gsb, out golemStatus );
			Console.WriteLine( gsb.ToString() + "を召喚した！" );

			string sWeakness = "";
			foreach( byte b in golemStatus.Weakness )
			{
				sWeakness += b.ToString();
			}
			Console.WriteLine(
string.Format( @"-------{0}のステータス-----
Hp:{1}
Power:{2}
Sex:{3}
Weakness:{4}
", gsb.ToString()
 , golemStatus.Hp.ToString()
 , golemStatus.Power.ToString()
 , golemStatus.Sex.ToString()
 , sWeakness
 ) );
		}

		/// <summary>
		/// ブルーゴブリン
		/// </summary>
		private static void CastBlueGoblin()
		{
			//ブルーゴブリン(Unicode)
			StringBuilder bsb = new StringBuilder( 1024 );
			MagicCast.BlueGoblin( bsb );
			Console.WriteLine( bsb.ToString() + "を召喚した！" );
		}

		/// <summary>
		/// レッドゴブリン（Ansi）
		/// </summary>
		private static void CastRedGoblin()
		{
			//レッドゴブリン（Ansi）
			string goblinName = "";
			MagicCast.RedGoblin( ref goblinName );
			Console.WriteLine( goblinName + "を召喚した！" );
		}

	}
}
