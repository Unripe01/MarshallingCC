typedef unsigned char       BYTE;
typedef unsigned short      WORD;
typedef long LONG;

//DLLエクスポート用宣言
#define Creatures_export __declspec(dllexport)

namespace Creatures {
	class Creatures_export Creature  {
	public:

		//ステータス構造体 （typedef unsigned char       BYTE;）
		typedef struct {
			long		Hp;					// 4b
			long		Power;				// 4b
			BYTE	Sex;					// 1b
			BYTE	Weakness[7];	//頭・右手・左手・胸・腰・右足・左足 (7b)
		} Status ;	// total=16b

		//ステータスを７つ保持する構造体
		typedef struct {
			Status Header[7];
		} DragonHeads;

		//レッドゴブリン
		static long __stdcall RedGoblin(  char **name );
		//ブルーゴブリン
		static long __stdcall BlueGoblin(  wchar_t *name );
		//ゴーレム
		static long __stdcall Golem(  wchar_t *name,  Status *lpStatus);
		//ドラゴン
		static long __stdcall Dragon(  wchar_t *name,  DragonHeads *lpStatus);
	};
}
