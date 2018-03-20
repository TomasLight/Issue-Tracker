﻿using System.ComponentModel.DataAnnotations;

namespace DataLayer.Enums
{
    /// <summary>
    /// Срочность исправления ошибки
    /// </summary>
    public enum Urgency
    {
        [Display(Name = "Очень Срочно")]
        /// <summary>
        /// Очень Срочно
        /// </summary>        
        First = 1,

        [Display(Name = "Срочно")]
        /// <summary>
        /// Срочно
        /// </summary>
        Second = 2,

        [Display(Name = "Несрочно")]
        /// <summary>
        /// Несрочно
        /// </summary>
        Third = 3,

        [Display(Name = "Совсем несрочно")]
        /// <summary>
        /// Совсем несрочно
        /// </summary>
        Fourth = 4
    }
}