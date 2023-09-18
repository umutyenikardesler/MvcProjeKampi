using EntityLayer.Concrete;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.ValidationRules
{
    public class WriterValidator:AbstractValidator<Writer>
    {
        public WriterValidator() 
        {
            RuleFor(x => x.WriterTitle).NotEmpty().WithMessage("Yazar Ünvanı Boş Geçilemez");
            RuleFor(x => x.WriterName).NotEmpty().WithMessage("Yazar Adı Boş Geçemezsiniz");
            RuleFor(x => x.WriterSurName).NotEmpty().WithMessage("Yazar Soyadını Boş Geçemezsiniz.");
            RuleFor(x => x.WriterAbout).MinimumLength(3).WithMessage("Lütfen hakkında kısmına en az 3 karakter girişi yapın.");
            RuleFor(x => x.WriterMail).NotEmpty().WithMessage("Yazar Mailini Boş Geçemezsiniz.");
        }
    }
}
