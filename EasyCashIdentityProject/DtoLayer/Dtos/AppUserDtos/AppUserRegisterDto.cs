﻿


namespace DtoLayer.Dtos.AppUserDtos
{
    public class AppUserRegisterDto
    {
        //[Required(ErrorMessage ="Ad alanı zorunludur")]
        //[Display(Name="İsim:")]
        //[MaxLength(30,ErrorMessage ="En Fazla 30 karekter girrebilirsiniz")]
        public string Name { get; set; }
        public string Surname { get; set; }

        public string Email { get; set; }
        public string UserName { get; set; }
        public string Password { get; set; }
        public string ConfirmPassword { get; set; }
    }
}
