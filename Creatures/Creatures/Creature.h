typedef unsigned char       BYTE;
typedef unsigned short      WORD;
typedef long LONG;

//DLL�G�N�X�|�[�g�p�錾
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

		//�X�e�[�^�X���V�ێ�����\����
		typedef struct {
			Status Header[7];
		} DragonHeads;

		//���b�h�S�u����
		static long __stdcall RedGoblin(  char **name );
		//�u���[�S�u����
		static long __stdcall BlueGoblin(  wchar_t *name );
		//�S�[����
		static long __stdcall Golem(  wchar_t *name,  Status *lpStatus);
		//�h���S��
		static long __stdcall Dragon(  wchar_t *name,  DragonHeads *lpStatus);
	};
}
