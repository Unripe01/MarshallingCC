#include "Creature.h"
#include <stdexcept>//おまじない的な何か。例外関連が定義されてるようだ
//#include <tchar.h>//_TCHAR型便利っす。でも今回は使わない。

//__stdcall を付けないと、C#側で扱える宣言なしでエラーになる。
namespace Creatures
{
		//レッドゴブリン（ANSI）
		 long Creature::RedGoblin(  char**  name ) {
		   strcpy( *name, "レッド・ゴブリン" );
			return 0;
		}	

		//ブルーゴブリン（UNI）
		long Creature::BlueGoblin(  wchar_t *name ) {
			wcscpy_s( name, 1024, L"ブルー・ゴブリン" );
			return 0;
		}

		//ゴーレム
		long Creature::Golem(  wchar_t *name,  Status *spStatus){
			wcscpy_s( name, 1024, L"ゴーレム" );
			spStatus->Hp = 1000;
			spStatus->Power = 500;
			spStatus->Sex = 1;
			spStatus->Weakness[0] = 0;
			spStatus->Weakness[1] = 1;
			spStatus->Weakness[2] = 0;
			spStatus->Weakness[3] = 1;
			spStatus->Weakness[4] = 0;
			spStatus->Weakness[5] = 1;
			spStatus->Weakness[6] = 1;
			return 0;
		}

		//Dragon
		long Creature::Dragon(  wchar_t *name,  DragonHeads *cerberusHeads){
			wcscpy_s( name, 1024, L"ドラゴン" );

			for ( int idx = 0 ; idx < 7 ; idx++ ) {
				cerberusHeads->Header[idx].Hp = ( idx + 1 ) * 1000;
				cerberusHeads->Header[idx].Power = ( idx + 1 ) * 500;
				cerberusHeads->Header[idx].Sex = idx % 2;
				cerberusHeads->Header[idx].Weakness[0] = 1;
				cerberusHeads->Header[idx].Weakness[1] = 0;
				cerberusHeads->Header[idx].Weakness[2] = 1;
				cerberusHeads->Header[idx].Weakness[3] = 0;
				cerberusHeads->Header[idx].Weakness[4] = 1;
				cerberusHeads->Header[idx].Weakness[5] = 0;
				cerberusHeads->Header[idx].Weakness[6] = 1;
			}
			return 0;
		}


}
