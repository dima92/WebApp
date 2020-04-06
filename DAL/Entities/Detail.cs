using System;
using System.ComponentModel.DataAnnotations;

namespace DAL.Entities
{
    public class Detail
    {
        public int Id { get; set; }
        [Required(ErrorMessage = "Введите номенклатурный код")]
        [RegularExpression(@"[A-Z]{3}-\d{6}", ErrorMessage = "Номенклатурный код должен иметь вид:XXX-111111")]
        public string NomenclatureCode { get; set; }

        [Required]
        public string Name { get; set; }

        [Required(ErrorMessage = "Введите количество деталей")]
        [Range(0, int.MaxValue, ErrorMessage = "Недопустимое кол-во деталей")]
        public int? Quantity { get; set; }

        public bool? SpecAccount { get; set; }

        public int StorekeeperId { get; set; }
        public Storekeeper Storekeeper { get; set; }

        [Required(ErrorMessage = "Выберите дату")]
        [WeekendDate(ErrorMessage = "Дата не может быть выходным днем")]
        public DateTime Created { get; set; } = DateTime.Today;

        public DateTime? DeleteDate { get; set; }

        public override string ToString()
        {
            return $" №{Id} от {Created:dd.MM.yyyy hh:mm:ss}";
        }
    }

    public class WeekendDateAttribute : RequiredAttribute
    {
        public override bool IsValid(object value)
        {
            if (base.IsValid(value))
            {
                DateTime date = (DateTime)value;
                return date.DayOfWeek != DayOfWeek.Saturday && date.DayOfWeek != DayOfWeek.Sunday;
            }

            return false;
        }
    }
}
