namespace ProjeUI.Models
{
    public class ConfirmMailViewModel // bu niew model olduğu için migration filan yapmıyoruz buna 
    {
        public string Mail { get; set; }
        public int ConfirmCode { get; set; }

    }
}
