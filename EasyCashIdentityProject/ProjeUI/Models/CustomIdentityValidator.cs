using Microsoft.AspNetCore.Identity;

namespace ProjeUI.Models
{
	//bunu bide siteme tanıtmanlazım program.cs e 
	public class CustomIdentityValidator:IdentityErrorDescriber // registerde kayıt olurken ingilizce gelen hatalrı türkçeleştirdik.
	{
		//override: metodun işeyişini aynı şkilde bıraıyor ama içeriği özeleştiriyoe.
		public override IdentityError PasswordTooShort(int length) //bu parola en az kaç karekter olduğu mesajı türkçeleştirdik 
		{
			return new IdentityError() // yeni hata mesajı, bunun iki paremtresi var code metodun key değeridir.o da metodun ismidir.
			{
				Code = "PasswordTooShort",
				Description=$"Parola en az {length} karekter olmalıdır. " //dolar işareti varsa paremetre alır.

			};


		}

		public override IdentityError PasswordRequiresUpper() //parolada en az bir buyuk harf mesajı
		{
			return new IdentityError() // yeni hata mesajı 
			{
				Code = "PasswordRequiresUpper",
				Description = $"Lütfen en az 1 büyük harf giriniz. " //dolar işareti varsa paremetre alır.

			};
		}

		public override IdentityError PasswordRequiresLower()
		{
			return new IdentityError()
			{
				Code= "PasswordRequiresLower",
				Description="lütfen en az 1 küçük harf giriniz"
			};
		}

		public override IdentityError PasswordRequiresDigit()
		{
			return new IdentityError()
			{
				Code= "PasswordRequiresDigit",
				Description="lütfen en az 1 tane rakam giriniz."
			};
		}

		public override IdentityError PasswordRequiresNonAlphanumeric()
		{
			return new IdentityError()
			{
				Code = "PasswordRequiresNonAlphanumeric",
				Description = "lütfen en az 1 tane sembol giriniz."
			};
		}


	}
}
