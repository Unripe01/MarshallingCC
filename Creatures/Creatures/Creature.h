typedef unsigned char       BYTE;
typedef unsigned short      WORD;
typedef long LONG;

#define Creatures_export __declspec(dllexport)

namespace Creatures {
	class Creatures_export Creature  {
	public:

		//�X�e�[�^�X�\���� �itypedef unsigned char       BYTE;�j
		typedef struct {
			long		Hp;					// 4b
			long		Power;				// 4b
			BYTE	Sex;					// 1b
			BYTE	Weakness[7];	//���E�E��E����E���E���E�E���E���� (7b)
		} Status ;	// total=16b

		typedef struct {
			Status Header[7];
		} CerberusHeads;

		static long __stdcall RedGoblin(  char **name );
		static long __stdcall BlueGoblin(  wchar_t *name );
		static long __stdcall Golem(  wchar_t *name,  Status *lpStatus);
		static long __stdcall Cerberus(  wchar_t *name,  CerberusHeads *lpStatus);
		
	};
}
