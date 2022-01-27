using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace ProjectM32.Models.Db
{
    /// <summary>
    /// модель пользователя в блоге
    /// </summary>
    public class User
    {
        // Уникальный идентификатор сущности в базе
        public Guid Id { get; set; }

        [Display(Name = "Имя")]
        public string FirstName { get; set; }

        [Display(Name = "Фамилия")]
        public string LastName { get; set; }

        [Display(Name = "Дата")]
        public DateTime JoinDate { get; set; }
    }
}
