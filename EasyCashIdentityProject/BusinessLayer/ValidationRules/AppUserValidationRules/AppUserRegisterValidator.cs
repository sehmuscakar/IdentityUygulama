using DataAccessLayer.Dtos.AppUserDtos;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.ValidationRules
{// Validation Rules :Doğrulama Kuralları , nu validayomlar için fluent kütüphanesi ve başka bi fluen ile ilgili iki kütüphane lazım yuklenen kütüphanelere bak burdakielere business dakilere 
    public class AppUserRegisterValidator:AbstractValidator<AppUserRegisterDto>

    {
        // ctor
        public AppUserRegisterValidator()
        {
            RuleFor(x => x.Name).NotEmpty().WithMessage("Ad alanı boş geçilmez");
            RuleFor(x => x.Surname).NotEmpty().WithMessage("Soyad alanı boş geçilmez");
            RuleFor(x => x.UserName).NotEmpty().WithMessage("Kullanıcı adı alanı boş geçilmez");
            RuleFor(x => x.Email).NotEmpty().WithMessage("Email alanı boş geçilmez");
            RuleFor(x => x.Password).NotEmpty().WithMessage("Şİfre alanı boş geçilmez");
            RuleFor(x => x.Name).MaximumLength(30).WithMessage("Lütfen en fazla 30 karekter girişi yapın");
            RuleFor(x => x.Name).MinimumLength(2).WithMessage("Lütfen en az 2 karekter veri girişi yapın");
            RuleFor(x => x.ConfirmPassword).Equal(y=>y.Password).WithMessage("parolarınız eşleşmiyor");
            RuleFor(x => x.ConfirmPassword).EmailAddress().WithMessage("Lütfen geçerli bir mail adresi giriniz");
 
        }

    }
}
