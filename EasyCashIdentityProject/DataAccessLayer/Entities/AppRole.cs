using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.Entities
{
    public class AppRole:IdentityRole<int> //<int>  burda id primary ni string ten int e cevirdik ,IdentityRole bu veritabanındaki role ilgili olan tabloyu temsil ediyor o tabloda eklemeler yapacağımız kısım bu modeldir
    {


    }
}
