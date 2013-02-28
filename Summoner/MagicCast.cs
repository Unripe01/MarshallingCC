using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Runtime.InteropServices;//DLL呼び出しに必要

///詠唱系
namespace MarshallingCC
{
	/// <summary>
	/// DLL呼び出しラッパークラス
	/// </summary>
	class MagicCast
	{
		//C++ LONG = C#:int
		/// <summary>
		/// レッドゴブリンの召喚
		/// </summary>
		[DllImport( "Creatures.dll", EntryPoint="RedGoblin", CharSet=CharSet.Ansi)]
		public static extern int RedGoblin( [In,Out] ref string name);

		/// <summary>
		/// ブルーゴブリンの召喚（ Unicode ）
		/// </summary>
		/// <param name="str"></param>
		/// <returns></returns>
		[DllImport( "Creatures.dll", EntryPoint="BlueGoblin", CharSet=CharSet.Unicode )]
		public static extern int BlueGoblin( [MarshalAs( UnmanagedType.LPWStr )]StringBuilder str );

		/// <summary>
		/// ゴーレムの召喚
		/// </summary>
		[DllImport( "Creatures.dll", EntryPoint="Golem", CharSet=CharSet.Unicode )]
		public static extern int Golem( [MarshalAs( UnmanagedType.LPWStr )]StringBuilder str, [Out] out Status status );

		/// <summary>
		/// ケルベロスの召喚
		/// </summary>
		[DllImport( "Creatures.dll", EntryPoint="Cerberus", CharSet=CharSet.Unicode )]
		public static extern int Cerberus( [MarshalAs( UnmanagedType.LPWStr )]StringBuilder str, [Out] out CerberusHeads status );

		/// <summary>
		/// ケルベロスの召喚
		/// </summary>
		[DllImport( "Creatures.dll", EntryPoint="Cerberus", CharSet=CharSet.Unicode )]
		public static extern unsafe int CerberusUnsafe( [MarshalAs( UnmanagedType.LPWStr )]StringBuilder str, StatusUnsafe* pointer );

		/// <summary>
		/// ケルベロス ステータス構造体
		/// </summary>
		[StructLayout( LayoutKind.Sequential )]
		public struct CerberusHeads
		{
			[MarshalAs( UnmanagedType.ByValArray, SizeConst=128 )]
			public Status[] head; //16b* 7
		}

		/// <summary>
		/// ステータス構造体(アラインメントの考慮不要)
		/// </summary>
		[StructLayout( LayoutKind.Sequential ) ]
		public struct Status
		{
			public int Hp;                    //4b
			public int Power;               //4b
			public byte Sex;                //1b
			[MarshalAs( UnmanagedType.ByValArray, SizeConst=7 )]
			/// <summary>頭・右手・左手・胸・腰・右足・左足 (7b)</summary>
			public byte[] Weakness;
			// total=16b
		}

		/// <summary>
		/// ステータス構造体
		/// </summary>
		[StructLayout( LayoutKind.Sequential )]
		public unsafe struct StatusUnsafe
		{
			public int Hp;                    //4b
			public int Power;               //4b
			public byte Sex;                //1b
			/// <summary>頭・右手・左手・胸・腰・右足・左足 (7b)</summary>
			public fixed byte Weakness[7];
			// total=16b
		}

		/// <summary>
		/// NG　ケルベロス ステータス構造体
		/// </summary>
		[StructLayout( LayoutKind.Sequential )]
		public unsafe struct CerberusHeadsUnsafe
		{
			//エラー	1	固定サイズ バッファーの型は次のうちの 1 つでなければなりません
			//: bool、byte、short、int、long、char、sbyte、ushort、uint、ulong、float または double
			//エラーが出るためダメ。Blittableではない。
			//public fixed Status head[7]; //16b* 7 
		}


	}
}
